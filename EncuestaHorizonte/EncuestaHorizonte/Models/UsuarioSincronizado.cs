using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncuestaHorizonte.Models
{
    public class UsuarioSincronizado
    {
        [PrimaryKey]
        public int Id { get; set; }
        
        public int IdUsuario { get; set; }

        public int Exitosos { get; set; }
    }
}
