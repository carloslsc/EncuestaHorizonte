using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncuestaHorizonte.Models
{
    public class Result
    {
        [JsonProperty(PropertyName = "exitosos")]
        public Exitosos Exitosos { get; set; }

        [JsonProperty(PropertyName = "fallidos")]
        public List<Fallidos> Fallidos { get; set; }
    }
}
