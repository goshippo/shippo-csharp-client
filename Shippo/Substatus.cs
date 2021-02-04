using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Substatus
    {
        [JsonProperty(PropertyName = "code")]
        public string Code;

        [JsonProperty(PropertyName = "text")]
        public string Text;

        [JsonProperty(PropertyName = "action_required")]
        public bool ActionRequired;
    }
}
