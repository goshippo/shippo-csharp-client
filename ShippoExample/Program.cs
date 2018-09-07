using System;
using System.Collections;
using System.Collections.Generic;

using Shippo;

namespace ShippoExample
{
    class Program
    {
    	static readonly string TRACKING_NO = "9205590164917312751089";

        private static void RunBatchExample(APIResource resource)
        {
            ShippoCollection<CarrierAccount> carrierAccounts = resource.AllCarrierAccount();
            string defaultCarrierAccount = "";
            foreach (CarrierAccount account in carrierAccounts) {
                if (account.Carrier.ToString() == "usps")
                    defaultCarrierAccount = account.ObjectId;
            }

            Address addressFrom = Address.createForPurchase("Mr. Hippo", "965 Mission St.", "Ste 201", "SF",
                                                            "CA", "94103", "US", "4151234567", "ship@gmail.com");
            Address addressTo = Address.createForPurchase("Mrs. Hippo", "965 Missions St.", "Ste 202", "SF",
                                                          "CA", "94103", "US", "4151234568", "msship@gmail.com");
            Parcel[] parcels = {Parcel.createForShipment(5, 5, 5, "in", 2, "oz")};
            Shipment shipment = Shipment.createForBatch(addressFrom, addressTo, parcels);
            BatchShipment batchShipment = BatchShipment.createForBatchShipments(defaultCarrierAccount, "usps_priority", shipment);

            List<BatchShipment> batchShipments = new List<BatchShipment>();
            batchShipments.Add(batchShipment);

            Batch batch = resource.CreateBatch(defaultCarrierAccount, "usps_priority", ShippoEnums.LabelFiletypes.PDF_4x6,
                                               "BATCH #170", batchShipments);
            Console.WriteLine("Batch Status = " + batch.Status);
            Console.WriteLine("Metadata = " + batch.Metadata);
        }

        private static void RunTrackingExample(APIResource resource)
        {
            Track track = resource.RetrieveTracking("usps", TRACKING_NO);
            Console.WriteLine("Carrier = " + track.Carrier.ToUpper());
            Console.WriteLine("Tracking number = " + track.TrackingNumber);
        }

        private static void RunInternationalAddressValidationExample(APIResource resource)
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("name", "Shippo Hippo");
            parameters.Add("company", "Shippo");
            parameters.Add("street_no", null);
            parameters.Add("street1", "40 Bay St");
            parameters.Add("street2", null);
            parameters.Add("city", "Toronto");
            parameters.Add("state", "ON");
            parameters.Add("zip", "M5J 2X2");
            parameters.Add("country", "CA");
            parameters.Add("phone", "+1 555 341 9393");
            parameters.Add("email", "hippo@goshippo.com");
            parameters.Add("metadata", "Customer ID 123456");
            parameters.Add("validate", "true");
            Address address = resource.CreateAddress(parameters);
            Console.Out.WriteLine("Address IsValid: " + address.ValidationResults.IsValid);
            if (address.ValidationResults.Messages != null) {
	            foreach (ValidationMessage message in address.ValidationResults.Messages) {
	                Console.Out.WriteLine("Address Message Code: " + message.Code);
	                Console.Out.WriteLine("Address Message Text: " + message.Text);
	                Console.Out.WriteLine();
                }
            }
            Console.Out.WriteLine("Address Latitude: " + address.Latitude);
            Console.Out.WriteLine("Address Longitude: " + address.Longitude);
        }

        static void Main(string[] args)
        {
            // replace with your Shippo Token
            // don't have one? get more info here
            // (https://goshippo.com/docs/#overview)
            APIResource resource = new APIResource("<Shippo Token>");
			// to address
            Hashtable toAddressTable = new Hashtable();
            toAddressTable.Add("name", "Mr. Hippo");
            toAddressTable.Add("company", "Shippo");
            toAddressTable.Add("street1", "215 Clayton St.");
            toAddressTable.Add("city", "San Francisco");
            toAddressTable.Add("state", "CA");
            toAddressTable.Add("zip", "94117");
            toAddressTable.Add("country", "US");
            toAddressTable.Add("phone", "+1 555 341 9393");
            toAddressTable.Add("email", "support@goshipppo.com");

            // from address
            Hashtable fromAddressTable = new Hashtable();
            fromAddressTable.Add("name", "Ms Hippo");
            fromAddressTable.Add("company", "San Diego Zoo");
            fromAddressTable.Add("street1", "2920 Zoo Drive");
            fromAddressTable.Add("city", "San Diego");
            fromAddressTable.Add("state", "CA");
            fromAddressTable.Add("zip", "92101");
            fromAddressTable.Add("country", "US");
            fromAddressTable.Add("email", "hippo@goshipppo.com");
            fromAddressTable.Add("phone", "+1 619 231 1515");
            fromAddressTable.Add("metadata", "Customer ID 123456");

            // parcel
            Hashtable parcelTable = new Hashtable();
            parcelTable.Add("length", "5");
            parcelTable.Add("width", "5");
            parcelTable.Add("height", "5");
            parcelTable.Add("distance_unit", "in");
            parcelTable.Add("weight", "2");
            parcelTable.Add("mass_unit", "lb");
            List<Hashtable> parcels = new List<Hashtable>();
            parcels.Add(parcelTable);


            // shipment
            Hashtable shipmentTable = new Hashtable();
            shipmentTable.Add("address_to", toAddressTable);
            shipmentTable.Add("address_from", fromAddressTable);
            shipmentTable.Add("parcels", parcels);
            shipmentTable.Add("object_purpose", "PURCHASE");
            shipmentTable.Add("async", false);

            // create Shipment object
            Console.WriteLine("Creating Shipment object..");
            Shipment shipment = resource.CreateShipment(shipmentTable);

            // select desired shipping rate according to your business logic
            // we simply select the first rate in this example
            Rate rate = shipment.Rates[0];

            Console.WriteLine("Getting shipping label..");
            Hashtable transactionParameters = new Hashtable();
            transactionParameters.Add("rate", rate.ObjectId);
            transactionParameters.Add("async", false);
            Transaction transaction = resource.CreateTransaction(transactionParameters);

            if (((String) transaction.Status).Equals("SUCCESS", StringComparison.OrdinalIgnoreCase)) {
                Console.WriteLine("Label url : " + transaction.LabelURL);
                Console.WriteLine("Tracking number : " + transaction.TrackingNumber);
            } else {
                Console.WriteLine("An Error has occured while generating your label. Messages : " + transaction.Messages);
            }

            Console.WriteLine("\nBatch\n");
            RunBatchExample(resource);

            Console.WriteLine("\nTrack\n");
            RunTrackingExample(resource);

            Console.WriteLine("\nValidating International Address\n");
            RunInternationalAddressValidationExample(resource);
        }

    }
}
