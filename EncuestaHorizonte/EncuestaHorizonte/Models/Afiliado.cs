using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace EncuestaHorizonte.Models
{
    public class Afiliado
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string NombreSegundo { get; set; }

        public string ApellidoPat { get; set; }

        public string ApellidoMat { get; set; }

        public string Sexo { get; set; }

        public string Edad { get; set; }

        public string EstadoCivil { get; set; }

        public string Domicilio { get; set; }

        public string Municipio { get; set; }

        public string Region { get; set; }

        public string Zona { get; set; }

        public string Seccion { get; set; }

        public string Casilla { get; set; }

        public string Promotor { get; set; }

        public string Comunidad { get; set; }

        public string TelefonoFijo { get; set; }

        public string TelefonoCelular { get; set; }

        public string TelefonoAlter { get; set; }

        public string Ocupacion { get; set; }

        public string Escolaridad { get; set; }

        public string Email { get; set; }

        public string NumIne { get; set; }

        public string ClaveIne { get; set; }

        public string Curp { get; set; }

        public string Facebook { get; set; }

        public string Observaciones { get; set; }

        public byte[] Foto { get; set; }

        public byte[] CredencialFrontal { get; set; }

        public byte[] CredencialPosterior { get; set; }

        public string IdUsuario { get; set; }

    }
}
