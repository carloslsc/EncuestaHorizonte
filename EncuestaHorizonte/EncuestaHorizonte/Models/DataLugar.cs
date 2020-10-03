using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncuestaHorizonte.Models
{
    public class DataLugar
    {
        [JsonProperty(PropertyName = "id_lugar")]
        public int Id_Lugar { get; set; }

        [JsonProperty(PropertyName = "nombre_lugar")]
        public string Nombre_Lugar { get; set; }
    }
}
