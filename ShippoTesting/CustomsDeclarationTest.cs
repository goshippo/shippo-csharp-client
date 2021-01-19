using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

using Shippo;


namespace ShippoTesting {
    [TestFixture]
    public class CustomsDeclarationTest : ShippoTest {

        [Test]
        public void TestValidCreate()
        {
            CustomsDeclaration testObject = CustomsDeclarationTest.getDefaultObject();
            Hashtable parameters = CustomsDeclarationTest.getDefaultParameters();
            Assert.AreEqual("VALID", testObject.ObjectState);
            Assert.AreEqual(parameters["exporter_reference"], testObject.ExporterReference);
            Assert.AreEqual(parameters["importer_reference"], testObject.ImporterReference);
            Assert.AreEqual(parameters["contents_type"], testObject.ContentsType);
            Assert.AreEqual(parameters["contents_explanation"], testObject.ContentsExplanation);
            Assert.AreEqual(parameters["invoice"], testObject.Invoice);
            Assert.AreEqual(parameters["license"], testObject.License);
            Assert.AreEqual(parameters["certificate"], testObject.Certificate);
            Assert.AreEqual(parameters["notes"], testObject.Notes);
            Assert.AreEqual(parameters["eel_pfc"], testObject.EelPfc);
            Assert.AreEqual(parameters["aes_itn"], testObject.AesItn);
            Assert.AreEqual(parameters["non_delivery_option"], testObject.NonDeliveryOption);
            Assert.AreEqual(parameters["certify"], testObject.Certify);
            Assert.AreEqual(parameters["certify_signer"], testObject.CertifySigner);
            Assert.AreEqual(parameters["disclaimer"], testObject.Discliamer);
            Assert.AreEqual(parameters["incoterm"], testObject.Incoterm);
            Assert.AreEqual(parameters["b13a_filing_option"], testObject.B13aFilingOption);
            Assert.AreEqual(parameters["b13a_number"], testObject.B13aNumber);

            var invoicedChargesParameters = (Dictionary<String, String>)parameters["invoiced_charges"];
            Assert.AreEqual(invoicedChargesParameters["total_shipping"], testObject.InvoicedCharges.TotalShipping);
            Assert.AreEqual(invoicedChargesParameters["total_taxes"], testObject.InvoicedCharges.TotalTaxes);
            Assert.AreEqual(invoicedChargesParameters["total_duties"], testObject.InvoicedCharges.TotalDuties);
            Assert.AreEqual(invoicedChargesParameters["other_fees"], testObject.InvoicedCharges.OtherFees);
            Assert.AreEqual(invoicedChargesParameters["currency"], testObject.InvoicedCharges.Currency);
        }

        [Test]
        public void testValidRetrieve()
        {
            CustomsDeclaration testObject = CustomsDeclarationTest.getDefaultObject();
            CustomsDeclaration retrievedObject;

            retrievedObject = apiResource.RetrieveCustomsDeclaration((string) testObject.ObjectId);
            Assert.AreEqual(testObject.ObjectId, retrievedObject.ObjectId);
        }

        [Test]
        public void testValidRetrieveWithAddressImporter ()
        {
            CustomsDeclaration testObject = CustomsDeclarationTest.getDefaultObject_2();
            CustomsDeclaration retrievedObject;

            retrievedObject = apiResource.RetrieveCustomsDeclaration ((string)testObject.ObjectId);
            Assert.AreEqual(testObject.ObjectId, retrievedObject.ObjectId);
            Assert.IsNotNull(retrievedObject.AddressImporter);
            Assert.AreEqual(testObject.AddressImporter, retrievedObject.AddressImporter);
        }

        [Test]
        public void testListAll()
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("results", "1");
            parameters.Add("page", "1");

            var parcels = apiResource.AllCustomsDeclarations(parameters);
            Assert.AreNotEqual(0, parcels.Data.Count);
        }

        public static Hashtable getDefaultParameters()
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("exporter_reference", "Exporter Reference");
            parameters.Add("importer_reference", "Importer Reference");
            parameters.Add("contents_type", "MERCHANDISE");
            parameters.Add("contents_explanation", "T-Shirt purchase");
            parameters.Add("invoice", "#123123");
            parameters.Add("license", "License");
            parameters.Add("certificate", "Certificate");
            parameters.Add("notes", "Notes");
            parameters.Add("eel_pfc", "NOEEI_30_37_a");
            parameters.Add("aes_itn", "X20180426506889");
            parameters.Add("non_delivery_option", "ABANDON");
            parameters.Add("certify", true);
            parameters.Add("certify_signer", "Laura Behrens Wu");
            parameters.Add("incoterm", "");
            parameters.Add("b13a_filing_option", "FILED_ELECTRONICALLY");
            parameters.Add("b13a_number", "AA9999202008311");
            parameters.Add("metadata", "Order ID #123123");

            JArray customsItems = new JArray();
            CustomsItem customsItem = CustomsItemTest.getDefaultObject();
            customsItems.Add((string)customsItem.ObjectId);
            parameters.Add("items", customsItems);

            var invoicedCharges = new Dictionary<String, String>(){
                {"total_shipping", "1.23"},
                {"total_taxes", "4.56"},
                {"total_duties", "78.90"},
                {"other_fees", "9.87"},
                {"currency", "USD"}
            };
            parameters.Add("invoiced_charges", invoicedCharges);

            return parameters;
        }

        public static CustomsDeclaration getDefaultObject()
        {
            CustomsItem customsItem = CustomsItemTest.getDefaultObject();
            Hashtable parameters = CustomsDeclarationTest.getDefaultParameters();
            return getAPIResource().CreateCustomsDeclaration(parameters);
        }

        public static CustomsDeclaration getDefaultObject_2 ()
        {
            CustomsItem customsItem = CustomsItemTest.getDefaultObject();
            Address addressImporter = AddressTest.getDefaultObject();
            Hashtable parameters = new Hashtable ();
            parameters.Add ("exporter_reference", "");
            parameters.Add ("importer_reference", "");
            parameters.Add ("contents_type", "MERCHANDISE");
            parameters.Add ("contents_explanation", "T-Shirt purchase");
            parameters.Add ("invoice", "#123123");
            parameters.Add ("license", "");
            parameters.Add ("certificate", "");
            parameters.Add ("notes", "");
            parameters.Add ("eel_pfc", "NOEEI_30_37_a");
            parameters.Add ("aes_itn", "");
            parameters.Add ("non_delivery_option", "ABANDON");
            parameters.Add ("certify", true);
            parameters.Add ("certify_signer", "Laura Behrens Wu");
            parameters.Add ("address_importer", addressImporter.ObjectId);
            parameters.Add ("incoterm", "");
            parameters.Add("metadata", "Order ID #123123");
            parameters.Add("b13a_filing_option", "FILED_ELECTRONICALLY");
            parameters.Add("b13a_number", "AA9999202008311");

            JArray customsItems = new JArray ();
            customsItems.Add ((string)customsItem.ObjectId);

            parameters.Add ("items", customsItems);
            return getAPIResource ().CreateCustomsDeclaration (parameters);
        }
    }
}

