/*
 * Copyright 2011 Xamarin, Inc., Joe Dluzen
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
using System.Collections;
using System.Collections.Generic;
using Shippo;
using Newtonsoft.Json;

namespace ShippoExample {
    class Example {
        static void Main (string[] args)
        {
            // replace with your Shippo Token
            // don't have one? get more info here
            // (https://goshippo.com/docs/#overview)
            APIResource resource = new APIResource ("<Shippo Token>");

            // to address
            Hashtable toAddressTable = new Hashtable ();
            toAddressTable.Add ("object_purpose", "PURCHASE");
            toAddressTable.Add ("name", "Mr. Hippo");
            toAddressTable.Add ("company", "Shippo");
            toAddressTable.Add ("street1", "215 Clayton St.");
            toAddressTable.Add ("city", "San Francisco");
            toAddressTable.Add ("state", "CA");
            toAddressTable.Add ("zip", "94117");
            toAddressTable.Add ("country", "US");
            toAddressTable.Add ("phone", "+1 555 341 9393");
            toAddressTable.Add ("email", "support@goshipppo.com");

            // from address
            Hashtable fromAddressTable = new Hashtable ();
            fromAddressTable.Add ("object_purpose", "PURCHASE");
            fromAddressTable.Add ("name", "Ms Hippo");
            fromAddressTable.Add ("company", "San Diego Zoo");
            fromAddressTable.Add ("street1", "2920 Zoo Drive");
            fromAddressTable.Add ("city", "San Diego");
            fromAddressTable.Add ("state", "CA");
            fromAddressTable.Add ("zip", "92101");
            fromAddressTable.Add ("country", "US");
            fromAddressTable.Add ("email", "hippo@goshipppo.com");
            fromAddressTable.Add ("phone", "+1 619 231 1515");
            fromAddressTable.Add ("metadata", "Customer ID 123456");

            // parcel
            Hashtable parcelTable = new Hashtable ();
            parcelTable.Add ("length", "5");
            parcelTable.Add ("width", "5");
            parcelTable.Add ("height", "5");
            parcelTable.Add ("distance_unit", "in");
            parcelTable.Add ("weight", "2");
            parcelTable.Add ("mass_unit", "lb");

            // shipment
            Hashtable shipmentTable = new Hashtable ();
            shipmentTable.Add ("address_to", toAddressTable);
            shipmentTable.Add ("address_from", fromAddressTable);
            shipmentTable.Add ("parcel", parcelTable);
            shipmentTable.Add ("object_purpose", "PURCHASE");
            shipmentTable.Add ("async", false);

            // create Shipment object
            Console.WriteLine ("Creating Shipment object..");
            Shipment shipment = resource.CreateShipment (shipmentTable);

            // select desired shipping rate according to your business logic
            // we simply select the first rate in this example
            Rate rate = shipment.RatesList.Data [0];

            Console.WriteLine ("Getting shipping label..");
            Hashtable transactionParameters = new Hashtable ();
            transactionParameters.Add ("rate", rate.ObjectId);
            transactionParameters.Add ("async", false);
            Transaction transaction = resource.CreateTransaction (transactionParameters);


            if (((String) transaction.ObjectStatus).Equals ("SUCCESS", StringComparison.OrdinalIgnoreCase)) {
                Console.WriteLine ("Label url : " + transaction.LabelURL);
                Console.WriteLine ("Tracking number : " + transaction.TrackingNumber);
            } else {
                Console.WriteLine ("An Error has occured while generating your label. Messages : " + transaction.Messages);
            }
        }
    }
}
