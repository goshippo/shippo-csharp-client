/*
 * Copyright 2012 Xamarin, Inc.
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
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Shippo {
    public class ShippoObjectConverter : JsonConverter {
        public override bool CanWrite { get { return false; } }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ShippoObject).IsAssignableFrom(objectType);
        }

        ShippoObject FindType(JObject jobj)
        {
            // Theoretical code illustrating potential improvements
            //            var type = (string) jobj.Property("object");
            //            switch (type) {
            //            case "account":
            //                return new ShippoAccount();
            //            }
            return new ShippoObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jobj = JObject.Load(reader);

            var target = FindType(jobj);

            serializer.Populate(jobj.CreateReader(), target);

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = JObject.FromObject(value);
            obj.WriteTo(writer);
        }
    }
}
