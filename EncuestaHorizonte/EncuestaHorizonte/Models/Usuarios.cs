using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncuestaHorizonte.Models
{
    public class Usuarios
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }

        public int Id_Lugar { get; set; }

        //public int Sel { get; set; }
    }
}
