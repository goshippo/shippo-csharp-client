using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject (MemberSerialization.OptIn)]
    public class Servicelevel
    {
        [JsonProperty (PropertyName = "token")]
        public string Token { get; set; }

        [JsonProperty (PropertyName = "name")]
        public string Name { get; set; }

        public override string ToString ()
        {
            return string.Format ("[Servicelevel: Token={0}, Name={1}]", Token, Name);
        }
    }
}
