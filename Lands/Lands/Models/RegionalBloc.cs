using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Models
{
    public class RegionalBloc
    {
        [JsonProperty(PropertyName = "acronmy")]
        public string Acronmy { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
