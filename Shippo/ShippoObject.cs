/*
 * Copyright 2011 Joe Dluzen, 2012 Xamarin, Inc.
 *
 * Author(s):
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
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Shippo {
    public class ShippoObject {
        [JsonProperty(PropertyName = "object")]
        public ShippoObjectType Object { get; set; }

    }


    public class ShippoId : ShippoObject {
        [JsonProperty(PropertyName = "object_id")]
        public string ObjectId { get; set; }
    }

    [JsonConverter(typeof(ShippoEnumConverter<ShippoObjectType>))]
    public enum ShippoObjectType
    {
        Unknown,
    }
}
