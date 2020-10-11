using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncuestaHorizonte.Models
{
    public class AfiliadoSend
    {
        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "nombreSegundo")]
        public string NombreSegundo { get; set; }

        [JsonProperty(PropertyName = "apellidoPat")]
        public string ApellidoPat { get; set; }

        [JsonProperty(PropertyName = "apellidoMat")]
        public string ApellidoMat { get; set; }

        [JsonProperty(PropertyName = "sexo")]
        public string Sexo { get; set; }

        [JsonProperty(PropertyName = "edad")]
        public string Edad { get; set; }

        [JsonProperty(PropertyName = "estadoCivil")]
        public string EstadoCivil { get; set; }

        [JsonProperty(PropertyName = "domicilio")]
        public string Domicilio { get; set; }

        [JsonProperty(PropertyName = "municipio")]
        public string Municipio { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "zona")]
        public string Zona { get; set; }

        [JsonProperty(PropertyName = "seccion")]
        public string Seccion { get; set; }

        [JsonProperty(PropertyName = "casilla")]
        public string Casilla { get; set; }

        [JsonProperty(PropertyName = "promotor")]
        public string Promotor { get; set; }

        [JsonProperty(PropertyName = "comunidad")]
        public string Comunidad { get; set; }

        [JsonProperty(PropertyName = "telefonoFijo")]
        public string TelefonoFijo { get; set; }

        [JsonProperty(PropertyName = "telefonoCelular")]
        public string TelefonoCelular { get; set; }

        [JsonProperty(PropertyName = "telefonoAlter")]
        public string TelefonoAlter { get; set; }

        [JsonProperty(PropertyName = "ocupacion")]
        public string Ocupacion { get; set; }

        [JsonProperty(PropertyName = "escolaridad")]
        public string Escolaridad { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "numIne")]
        public string NumIne { get; set; }

        [JsonProperty(PropertyName = "claveIne")]
        public string ClaveIne { get; set; }

        [JsonProperty(PropertyName = "curp")]
        public string Curp { get; set; }

        [JsonProperty(PropertyName = "facebook")]
        public string Facebook { get; set; }

        [JsonProperty(PropertyName = "observaciones")]
        public string Observaciones { get; set; }

        [JsonProperty(PropertyName = "foto")]
        public byte[] Foto { get; set; }

        [JsonProperty(PropertyName = "credencialFrontal")]
        public byte[] CredencialFrontal { get; set; }

        [JsonProperty(PropertyName = "credencialPosterior")]
        public byte[] CredencialPosterior { get; set; }
    }
}
