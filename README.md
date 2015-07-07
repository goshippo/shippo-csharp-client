Shippo C# API Client
==================

Shippo is a shipping API that connects you with multiple shipping carriers (such as USPS, UPS, Fedex, and DHL Express) all 
throughone interface and allows you to create shipping labels. Shippo also offers you great discounts for US and international
shipping rates.

This readme is meant as a simple guide for how to use the Shippo C# bindings. The Shippo C# bindings are built with Xamarin
so that you can use them cross platform in your .NET projects.

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

Wrapper Functionality Available
---------------------------
To see all the possible methods and objects look in the project Shippo. In this project you'll see the definitions for every type
of object you can create through the API.

A particularly important file is APIResource.cs, this file contains the code responsible for making requests. Also contained
within this file are all the methods for generating different type of API objects. Each object's methods are contained within
a region tag for convenient navigation. For example, the Parcel's methods are contained within: 
        
        #region Parcel
        /* Parcel Code */
        #endregion
        
Outside of APIResource.cs, the other code relevant to Parcels is contained within Parcel.cs. This includes directives for JSON encoding parameters, and getters and setters necessary for deserialization. This paradigm is consistent for every API object throughout.

