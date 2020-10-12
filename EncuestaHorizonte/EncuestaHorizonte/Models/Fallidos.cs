using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncuestaHorizonte.Models
{
    public class Fallidos
    {
        [JsonProperty(PropertyName = "nombreCompleto")]
        public string NombreCompleto { get; set; }

        [JsonProperty(PropertyName = "curp")]
        public string Curp { get; set; }
    }
}
