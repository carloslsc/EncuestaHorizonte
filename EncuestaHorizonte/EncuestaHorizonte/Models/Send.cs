using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncuestaHorizonte.Models
{
    public class Send
    {
        [JsonProperty(PropertyName = "usuarioSend")]
        public UsuarioSend UsuarioSend { get; set; }

        [JsonProperty(PropertyName = "afiliados")]
        public List<AfiliadoSend> Afiliados { get; set; }
    }
}
