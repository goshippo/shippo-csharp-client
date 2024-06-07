[![CircleCI](https://circleci.com/gh/goshippo/shippo-csharp-client.svg?style=svg)](https://circleci.com/gh/goshippo/shippo-csharp-client)

# Shippo C# API wrapper

---

:warning: **Shippo no longer actively maintains this library** <br>

Shippo no longer actively maintains this library

Use our latest [Shippo C# SDK](https://github.com/goshippo/shippo-csharp-sdk) 🚀

---

Shippo is a shipping API that connects you with [multiple shipping carriers](https://goshippo.com/carriers/) (such as USPS, UPS, DHL, Canada Post, Australia Post, UberRUSH and many others) through one interface.

Print a shipping label in 10 mins using our default USPS and DHL Express accounts. No need to register for a carrier account to get started.

You will need to [register for a Shippo account](https://goshippo.com/) to use the Shippo API. It's free to sign up, free to use the API. Only pay to print a live label, test labels are free.

Install Manually
----------------
To manually include the code in a project of your own, just add the project to your solution, and then link it in the compiler.
Shippo get's its packages via NuGet. The required packages are json.NET, and NUnit for testing.

To load the code into your Visual Studio IDE or Xamarin Studio IDE, click "File --> Open" and then locate the solution file
within the root directory of this folder.

Running the Test Cases / Example
--------------------------------
To run the test cases, right click the ShippoTesting project and then click "Run Item".

- A prerequisite to running the test cases is editing the file ShippoTest.cs with your appropriate authorization token.

To run the example code, right click the ShippoExample project and then click "Run Item".

- A prerequisite to running the example is editing the file Example.cs with your appropriate authorization token.

Example code can be found in the ShippoExample project, in the file Example.cs.

A Brief Example
---------------
For convenience, a brief example to create, get, and list all parcels can be found below (substitute your own Shippo token):
```csharp
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Shippo;
    using Newtonsoft.Json;

    namespace ShippoExample {
        class Example {
            static void Main (string [] args)
            {
                APIResource resource = new APIResource (“<Your Shippo Token>“);

                // Hash table of properties
                Hashtable parameters = new Hashtable ();
                parameters.Add("length", "5");
                parameters.Add("width", "5");
                parameters.Add("height", "5");
                parameters.Add("distance_unit", "cm");
                parameters.Add("weight", "2");
                parameters.Add("mass_unit", "lb");
                parameters.Add("template", "");
                parameters.Add("metadata", "Customer ID 123456");

                // Create Parcel
                Parcel parcel = resource.CreateParcel (parameters);
                Console.WriteLine (parcel.Length);

                // Get Parcel
                Parcel parcelRetrieved = resource.RetrieveParcel ((string) parcel.ObjectId);
                Console.WriteLine (parcelRetrieved.DistanceUnit);

                // All Parcels
                parameters = new Hashtable ();
                parameters.Add ("results", "2");
                parameters.Add ("page", "1");

                var parcels = resource.AllParcels(parameters);
                Console.WriteLine (parcels.Data.Count);

            }
        }
    }
```
Wrapper Functionality Available
---------------------------
To see all the possible methods and objects look in the project Shippo. In this project you'll see the definitions for every type
of object you can create through the API.

A particularly important file is [APIResource.cs](/Shippo/APIResource.cs), this file contains the code responsible for making requests. Also contained
within this file are all the methods for generating different type of API objects. Each object's methods are contained within
a region tag for convenient navigation. For example, the Parcel's methods are contained within:
```csharp        
        #region Parcel
        /* Parcel Code */
        #endregion
```
Outside of [APIResource.cs](/Shippo/APIResource.cs), the other code relevant to Parcels is contained within [Parcel.cs](/Shippo/Parcel.cs). This includes directives for JSON encoding parameters, and getters and setters necessary for deserialization. This paradigm is consistent for every API object throughout.

## Documentation

Please see [https://goshippo.com/docs](https://goshippo.com/docs) for up-to-date documentation.

## About Shippo

Connect with multiple different carriers, get discounted shipping labels, track parcels, and much more with just one integration. You can use your own carrier accounts or take advantage of our discounted rates with the USPS and DHL Express. Using Shippo makes it easy to deal with multiple carrier integrations, rate shopping, tracking and other parts of the shipping workflow. We provide the API and dashboard for all your shipping needs.

## Supported Features

The Shippo API provides in depth support of carrier and shipping functionalities. Here are just some of the features we support through the API:

* Shipping rates & labels
* Tracking for any shipment with just the tracking number
* Batch label generation
* Multi-piece shipments
* Manifests and SCAN forms
* Customs declaration and commercial invoicing
* Address verification
* Signature and adult signature confirmation
* Consolidator support including:
	* DHL eCommerce
	* UPS Mail Innovations
	* FedEx Smartpost
* Additional services: cash-on-delivery, certified mail, delivery confirmation, and more.
