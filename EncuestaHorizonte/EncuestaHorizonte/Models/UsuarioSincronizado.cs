using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncuestaHorizonte.Models
{
    public class UsuarioSincronizado
    {
        [PrimaryKey]
        public int IdUsuario { get; set; }
        
        [PrimaryKey]
        public int Exitosos { get; set; }
    }
}
