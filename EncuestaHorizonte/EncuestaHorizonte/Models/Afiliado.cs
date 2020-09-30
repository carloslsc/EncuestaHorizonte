using SQLite;
using System;
using System.Collections.Generic;
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
        /*
        public int IdCaporal { get; set; }

        public string NomCap { get; set; }
        */
        /*
        public string Capp { get; set; }

        public string Capm { get; set; }
        */
        /*public int Cnsle { get; set; }

        public int IdEmp { get; set; }

        public string NomEmp { get; set; }
        /*
        public string App { get; set; }

        public string Apm { get; set; }
        */
        /*public int IdLab { get; set; }

        public string DescLab { get; set; }

        public int IdArea { get; set; }

        public int Cable { get; set; }

        public int Lote { get; set; }

        public double Cantidad { get; set; }

        public string FecExeLab { get; set; }

        public int Dup { get; set; }*/
    }
}
