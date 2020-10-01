using EncuestaHorizonte.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EncuestaHorizonte.Helpers
{
    public class FullAfiliado
    {
        public Afiliado Llenado(string id, string municipio, string region, string zona, string seccion, string casilla, string promotor,
            string comunidad, string nombre, string nombreSegundo, string apellidoPat, string apellidoMat, string domicilio, string telefonoFijo,
            string telefonoCelular, string telefonoAlter, string ocupacion, string escolaridad, string email, string numIne, string claveIne,
            string curp, string facebook, string observaciones, byte[] imageArray)
        {
            int idAfiliado = Convert.ToInt32(id);
            return new Afiliado
            {
                Id = idAfiliado,
                Municipio = municipio,
                Region = region,
                Zona = zona,
                Seccion = seccion,
                Casilla = casilla,
                Promotor = promotor,
                Comunidad = comunidad,
                Nombre = nombre,
                NombreSegundo = nombreSegundo,
                ApellidoPat = apellidoPat,
                ApellidoMat = apellidoMat,
                Domicilio = domicilio,
                TelefonoFijo = telefonoFijo,
                TelefonoCelular = telefonoCelular,
                TelefonoAlter = telefonoAlter,
                Ocupacion = ocupacion,
                Escolaridad = escolaridad,
                Email = email,
                NumIne = numIne,
                ClaveIne = claveIne,
                Curp = curp,
                Facebook = facebook,
                Observaciones = observaciones,
                Foto = imageArray
            };
        }
    }
}
