using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncuestaHorizonte.Models
{
    public class Exitosos
    {
        [JsonProperty(PropertyName = "totalExitosos")]
        public string TotalExitosos { get; set; }

        [JsonProperty(PropertyName = "totalExitososAlMomento")]
        public string ExitososAlMomento { get; set; }
    }
}
