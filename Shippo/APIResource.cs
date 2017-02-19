/*
 * Copyright 2011 - 2012 Xamarin, Inc., 2011 - 2012 Joe Dluzen
 *
 * Author(s):
 *  Gonzalo Paniagua Javier (gonzalo@xamarin.com)
 *  Joe Dluzen (jdluzen@gmail.com)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

using Newtonsoft.Json;

namespace Shippo {
    public class APIResource {
        public static readonly string api_endpoint = "https://api.goshippo.com/v1";
        static readonly string user_agent = "Shippo/v1 CSharpBindings/1.0";
        public static readonly int RatesReqTimeout = 25;
        public static readonly int TransactionReqTimeout = 25;
        static readonly Encoding encoding = Encoding.UTF8;
        String accessToken;
        String apiVersion;

        // API Resource Constructor
        public APIResource (string inputToken)
        {
            accessToken = inputToken;
            TimeoutSeconds = 25;
            apiVersion = null;
        }

        public virtual void SetApiVersion(String version) {
            apiVersion = version;
        }

        #region Shared
        // Setup Request handles headers, credentials etc for WebRequests
        protected virtual WebRequest SetupRequest (string method, string url)
        {
            WebRequest req = (WebRequest) WebRequest.Create (url);
            req.Method = method;
            if (req is HttpWebRequest) {
                ((HttpWebRequest) req).UserAgent = user_agent;
            }

            /* ENABLE BLOCK FOR BASIC AUTH
            req.Credentials = credential;
            req.PreAuthenticate = true; */

            // Disable line below for basic auth
            req.Headers.Add ("Authorization", "ShippoToken " + accessToken);
            if (apiVersion != null) {
                req.Headers.Add ("Shippo-API-Version", apiVersion);
            }
            req.Timeout = TimeoutSeconds * 1000;
            // When Performing POST requests it is important that we set the headers to json
            if (method == "POST" || method == "PUT")
                req.ContentType = "application/json";
            return req;
        }
        // Return response as String
        static string GetResponseAsString (WebResponse response)
        {
            using (StreamReader sr = new StreamReader (response.GetResponseStream (), encoding)) {
                return sr.ReadToEnd ();
            }
        }
        // GET Requests
        public virtual T DoRequest<T> (string endpoint, string method = "GET", string body = null)
        {
            var json = DoRequest (endpoint, method, body);
            return JsonConvert.DeserializeObject<T> (json);
        }
        // GET Requests Helper
        public virtual string DoRequest (string endpoint)
        {
            return DoRequest (endpoint, "GET", null);
        }
        // Requests Main Function
        public virtual string DoRequest (string endpoint, string method, string body)
        {
            string result = null;
            WebRequest req = SetupRequest (method, endpoint);
            if (body != null) {
                byte[] bytes = encoding.GetBytes (body.ToString ());
                req.ContentLength = bytes.Length;
                using (Stream st = req.GetRequestStream ()) {
                    st.Write (bytes, 0, bytes.Length);
                }
            }

            try {
                using (WebResponse resp = (WebResponse) req.GetResponse ()) {
                    result = GetResponseAsString (resp);
                }
            } catch (WebException wexc) {
                if (wexc.Response != null) {
                    string json_error = GetResponseAsString (wexc.Response);
                    HttpStatusCode status_code = HttpStatusCode.BadRequest;
                    HttpWebResponse resp = wexc.Response as HttpWebResponse;
                    if (resp != null)
                        status_code = resp.StatusCode;

                    if ((int) status_code <= 500)
                        throw new ShippoException(json_error, wexc);
                }
                throw;
            }
            return result;
        }

        protected virtual StringBuilder UrlEncode (IUrlEncoderInfo infoInstance)
        {
            StringBuilder str = new StringBuilder ();
            infoInstance.UrlEncode (str);
            if (str.Length > 0)
                str.Length--;
            return str;
        }
        // Generate URL Encoded parameters for GET requests
        public String generateURLEncodedFromHashmap (Hashtable propertyMap)
        {
            StringBuilder str = new StringBuilder ();
            foreach (DictionaryEntry pair in propertyMap) {
                str.AppendFormat ("{0}={1}&", pair.Key, pair.Value);
            }
            str.Length--;

            return str.ToString ();
        }
        // Serialize parameters into JSON for POST requests
        public String serialize (Hashtable propertyMap)
        {
            return JsonConvert.SerializeObject (propertyMap);
        }
        // Serialize parameters into JSON for POST requests from List
        public String serializeList<T> (List<T> list)
        {
            return JsonConvert.SerializeObject (list);
        }

        #endregion

        #region Address

        public Address CreateAddress (Hashtable parameters)
        {
            string ep = String.Format ("{0}/addresses", api_endpoint);
            return DoRequest<Address> (ep, "POST", serialize (parameters));
        }

        public Address RetrieveAddress (String id)
        {
            string ep = String.Format ("{0}/addresses/{1}", api_endpoint, id);
            return DoRequest<Address> (ep, "GET");
        }

        public Address ValidateAddress (String id)
        {
            string ep = String.Format ("{0}/addresses/{1}/validate", api_endpoint, id);
            return DoRequest<Address> (ep, "GET");
        }

        public ShippoCollection<Address> AllAddresss (Hashtable parameters)
        {
            string ep = String.Format ("{0}/addresses?{1}", api_endpoint, generateURLEncodedFromHashmap (parameters));
            return DoRequest<ShippoCollection<Address>> (ep);
        }

        #endregion

        #region Parcel

        public Parcel CreateParcel (Hashtable parameters)
        {
            string ep = String.Format ("{0}/parcels", api_endpoint);
            return DoRequest<Parcel> (ep, "POST", serialize (parameters));
        }

        public Parcel RetrieveParcel (String id)
        {
            string ep = String.Format ("{0}/parcels/{1}", api_endpoint, id);
            return DoRequest<Parcel> (ep, "GET");
        }

        public ShippoCollection<Parcel> AllParcels (Hashtable parameters)
        {
            string ep = String.Format ("{0}/parcels?{1}", api_endpoint, generateURLEncodedFromHashmap (parameters));
            return DoRequest<ShippoCollection<Parcel>> (ep);
        }

        #endregion

        #region Shipment

        public Shipment CreateShipment (Hashtable parameters)
        {
            string ep = String.Format ("{0}/shipments", api_endpoint);
            return DoRequest<Shipment> (ep, "POST", serialize (parameters));
        }

        public Shipment RetrieveShipment (String id)
        {
            string ep = String.Format ("{0}/shipments/{1}", api_endpoint, id);
            return DoRequest<Shipment> (ep, "GET");
        }

        public ShippoCollection<Shipment> AllShipments (Hashtable parameters)
        {
            string ep = String.Format ("{0}/shipments?{1}", api_endpoint, generateURLEncodedFromHashmap (parameters));
            return DoRequest<ShippoCollection<Shipment>> (ep);
        }

        #endregion

        #region Rate

        public ShippoCollection<Rate> CreateRate (Hashtable parameters)
        {
            string ep = String.Format ("{0}/shipments/{1}/rates/{2}", api_endpoint, parameters ["id"], parameters ["currency_code"]);
            return DoRequest<ShippoCollection<Rate>> (ep, "GET");
        }

        public ShippoCollection<Rate> GetShippingRatesSync (String objectId)
        {
            Hashtable parameters = new Hashtable ();
            parameters.Add ("id", objectId);
            parameters.Add ("currency_code", "");
            return GetShippingRatesSync (parameters);
        }

        public ShippoCollection<Rate> GetShippingRatesSync (Hashtable parameters)
        {

            String object_id = (String) parameters ["id"];
            Shipment shipment = RetrieveShipment (object_id);
            String object_status = (String) shipment.ObjectStatus;
            long startTime = DateTimeExtensions.UnixTimeNow ();

            while (object_status.Equals ("QUEUED", StringComparison.OrdinalIgnoreCase) || object_status.Equals ("WAITING", StringComparison.OrdinalIgnoreCase)) {
                if (DateTimeExtensions.UnixTimeNow () - startTime > RatesReqTimeout) {
                    throw new RequestTimeoutException (
                        "A timeout has occured while waiting for your rates to generate. Try retreiving the Shipment object again and check if object_status is updated. If this issue persists, please contact support@goshippo.com");
                }
                shipment = RetrieveShipment (object_id);
                object_status = (String) shipment.ObjectStatus;
            }

            return CreateRate(parameters);
        }

        public Rate RetrieveRate (String id)
        {
            string ep = String.Format ("{0}/rates/{1}", api_endpoint, id);
            return DoRequest<Rate> (ep, "GET");
        }

        public ShippoCollection<Rate> AllRates (Hashtable parameters)
        {
            string ep = String.Format ("{0}/rates?{1}", api_endpoint, generateURLEncodedFromHashmap (parameters));
            return DoRequest<ShippoCollection<Rate>> (ep);
        }

        #endregion

        #region Transaction

        public Transaction CreateTransaction (Hashtable parameters)
        {
            string ep = String.Format ("{0}/transactions", api_endpoint);
            return DoRequest<Transaction> (ep, "POST", serialize (parameters));
        }

        public Transaction CreateTransactionSync (Hashtable parameters)
        {
            string ep = String.Format ("{0}/transactions", api_endpoint);
            Transaction transaction = DoRequest<Transaction> (ep, "POST", serialize (parameters));
            String object_id = (String) transaction.ObjectId;
            String object_status = (String) transaction.ObjectStatus;
            long startTime = DateTimeExtensions.UnixTimeNow ();

            while (object_status.Equals ("QUEUED", StringComparison.OrdinalIgnoreCase) || object_status.Equals ("WAITING", StringComparison.OrdinalIgnoreCase)) {
                if (DateTimeExtensions.UnixTimeNow () - startTime > TransactionReqTimeout) {
                    throw new RequestTimeoutException (
                        "A timeout has occured while waiting for your label to generate. Try retreiving the Transaction object again and check if object_status is updated. If this issue persists, please contact support@goshippo.com");
                }
                transaction = RetrieveTransaction (object_id);
                object_status = (String) transaction.ObjectStatus;
            }

            return transaction;
        }

        public Transaction RetrieveTransaction (String id)
        {
            string ep = String.Format ("{0}/transactions/{1}", api_endpoint, id);
            return DoRequest<Transaction> (ep, "GET");
        }

        public ShippoCollection<Transaction> AllTransactions (Hashtable parameters)
        {
            string ep = String.Format ("{0}/transactions?{1}", api_endpoint, generateURLEncodedFromHashmap (parameters));
            return DoRequest<ShippoCollection<Transaction>> (ep);
        }

        #endregion

        #region CustomsItem

        public CustomsItem CreateCustomsItem (Hashtable parameters)
        {
            string ep = String.Format ("{0}/customs/items", api_endpoint);
            return DoRequest<CustomsItem> (ep, "POST", serialize (parameters));
        }

        public CustomsItem RetrieveCustomsItem (String id)
        {
            string ep = String.Format ("{0}/customs/items/{1}", api_endpoint, id);
            return DoRequest<CustomsItem> (ep, "GET");
        }

        public ShippoCollection<CustomsItem> AllCustomsItems (Hashtable parameters)
        {
            string ep = String.Format ("{0}/customs/items?{1}", api_endpoint, generateURLEncodedFromHashmap (parameters));
            return DoRequest<ShippoCollection<CustomsItem>> (ep);
        }

        #endregion

        #region CustomsDeclaration

        public CustomsDeclaration CreateCustomsDeclaration (Hashtable parameters)
        {
            string ep = String.Format ("{0}/customs/declarations", api_endpoint);
            return DoRequest<CustomsDeclaration> (ep, "POST", serialize (parameters));
        }

        public CustomsDeclaration RetrieveCustomsDeclaration (String id)
        {
            string ep = String.Format ("{0}/customs/declarations/{1}", api_endpoint, id);
            return DoRequest<CustomsDeclaration> (ep, "GET");
        }

        public ShippoCollection<CustomsDeclaration> AllCustomsDeclarations (Hashtable parameters)
        {
            string ep = String.Format ("{0}/customs/declarations?{1}", api_endpoint, generateURLEncodedFromHashmap (parameters));
            return DoRequest<ShippoCollection<CustomsDeclaration>> (ep);
        }

        #endregion

        #region CarrierAccount

        public CarrierAccount CreateCarrierAccount (Hashtable parameters)
        {
            string ep = String.Format ("{0}/carrier_accounts", api_endpoint);
            return DoRequest<CarrierAccount> (ep, "POST", serialize (parameters));
        }

        public CarrierAccount UpdateCarrierAccount (String object_id, Hashtable parameters)
        {
            string ep = String.Format ("{0}/carrier_accounts/{1}", api_endpoint, object_id);
            return DoRequest<CarrierAccount> (ep, "PUT", serialize (parameters));
        }

        public CarrierAccount RetrieveCarrierAccount (String object_id)
        {
            string ep = String.Format ("{0}/carrier_accounts/{1}", api_endpoint, object_id);
            return DoRequest<CarrierAccount> (ep, "GET");
        }

        public ShippoCollection<CarrierAccount> AllCarrierAccount (Hashtable parameters)
        {
            return AllCarrierAccount ();
        }

        public ShippoCollection<CarrierAccount> AllCarrierAccount ()
        {
            string ep = String.Format ("{0}/carrier_accounts", api_endpoint);
            return DoRequest<ShippoCollection<CarrierAccount>> (ep);
        }

        #endregion

        #region Refund

        public Refund CreateRefund (Hashtable parameters)
        {
            string ep = String.Format ("{0}/refunds", api_endpoint);
            return DoRequest<Refund> (ep, "POST", serialize (parameters));
        }

        public Refund RetrieveRefund (String id)
        {
            string ep = String.Format ("{0}/refunds/{1}", api_endpoint, id);
            return DoRequest<Refund> (ep, "GET");
        }

        public ShippoCollection<Refund> AllRefunds (Hashtable parameters)
        {
            string ep = String.Format ("{0}/refunds?{1}", api_endpoint, generateURLEncodedFromHashmap (parameters));
            return DoRequest<ShippoCollection<Refund>> (ep);
        }

        #endregion

        #region Manifest

        public Manifest CreateManifest (Hashtable parameters)
        {
            string ep = String.Format ("{0}/manifests", api_endpoint);
            return DoRequest<Manifest> (ep, "POST", serialize (parameters));
        }

        public Manifest RetrieveManifest (String id)
        {
            string ep = String.Format ("{0}/manifests/{1}", api_endpoint, id);
            return DoRequest<Manifest> (ep, "GET");
        }

        public ShippoCollection<Manifest> AllManifests (Hashtable parameters)
        {
            string ep = String.Format ("{0}/manifests?{1}", api_endpoint, generateURLEncodedFromHashmap (parameters));
            return DoRequest<ShippoCollection<Manifest>> (ep);
        }

        #endregion

        #region Batch

        public Batch CreateBatch (String carrierAccount, String servicelevelToken, String labelFiletype,
                                  String metadata, List<Batch.BatchShipment> batchShipments)
        {
            string ep = String.Format ("{0}/batches", api_endpoint);
            Hashtable parameters = new Hashtable ();
            parameters.Add ("default_carrier_account", carrierAccount);
            parameters.Add ("default_servicelevel_token", servicelevelToken);
            parameters.Add ("label_filetype", labelFiletype);
            parameters.Add ("metadata", metadata);
            parameters.Add ("batch_shipments", batchShipments);
            return DoRequest<Batch> (ep, "POST", serialize(parameters));
        }

        public Batch RetrieveBatch (String id, Hashtable parameters = null)
        {
            string ep = String.Format ("{0}/batches/{1}", api_endpoint, HttpUtility.HtmlEncode(id));
            if (parameters != null)
                ep = String.Format ("{0}?{1}", ep, generateURLEncodedFromHashmap (parameters));
            return DoRequest<Batch> (ep, "GET");
        }

        public Batch AddShipmentsToBatch (String id, List<Hashtable> shipments)
        {
            string ep = String.Format ("{0}/batches/{1}/add_shipments", api_endpoint, HttpUtility.HtmlEncode (id));
            return DoRequest<Batch> (ep, "POST", serializeList<Hashtable> (shipments));
        }

        public Batch RemoveShipmentsFromBatch (String id, List<String> shipments)
        {
            string ep = String.Format ("{0}/batches/{1}/remove_shipments", api_endpoint, HttpUtility.HtmlEncode (id));
            return DoRequest<Batch> (ep, "POST", serializeList<String> (shipments));
        }

        public Batch PurchaseBatch (String id)
        {
            string ep = String.Format ("{0}/batches/{1}/purchase", api_endpoint, HttpUtility.HtmlEncode (id));
            return DoRequest<Batch> (ep, "POST");
        }

        #endregion

        #region Track

        public Track RetrieveTracking (String carrier, String id)
        {
            string encodedCarrier = HttpUtility.HtmlEncode (carrier);
            string encodedId = HttpUtility.HtmlEncode (id);
            string ep = String.Format ("{0}/tracks/{1}/{2}", api_endpoint, encodedCarrier, encodedId);
            return DoRequest<Track> (ep, "GET");
        }

        public Track RegisterTrackingWebhook (Hashtable parameters)
        {
            // For now the trailing '/' is required.
            string ep = String.Format ("{0}/tracks/", api_endpoint);
            return DoRequest<Track> (ep, "POST", serialize(parameters));
        }

        #endregion

        public int TimeoutSeconds { get; set; }
    }
}
