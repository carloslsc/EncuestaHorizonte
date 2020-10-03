using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncuestaHorizonte.Models
{
    public class Lugares
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Lugar { get; set; }
    }
}
