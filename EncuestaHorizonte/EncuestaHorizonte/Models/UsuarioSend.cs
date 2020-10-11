using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncuestaHorizonte.Models
{
    public class UsuarioSend
    {
        [JsonProperty(PropertyName = "idUsuario")]
        public string IdUsuario { get; set; }
    }
}
