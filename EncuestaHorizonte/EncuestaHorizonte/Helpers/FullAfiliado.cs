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
            string comunidad, string nombre, string nombreSegundo, string apellidoPat, string apellidoMat, string sexo, string edad, string estadoCivil, 
            string domicilio, string telefonoFijo, string telefonoCelular, string telefonoAlter, string ocupacion, string escolaridad, string email,
            string numIne, string claveIne, string curp, string facebook, string observaciones, byte[] imageArray, byte[] credencialF, byte[] credencialP)
        {
            int idAfiliado = Convert.ToInt32(id);

            Afiliado afiliado = new Afiliado();

            if (imageArray == null)
            {
                afiliado.Id = idAfiliado;
                afiliado.Municipio = municipio;
                afiliado.Region = region;
                afiliado.Zona = zona;
                afiliado.Seccion = seccion;
                afiliado.Casilla = casilla;
                afiliado.Promotor = promotor;
                afiliado.Comunidad = comunidad;
                afiliado.Nombre = nombre;
                afiliado.NombreSegundo = nombreSegundo;
                afiliado.ApellidoPat = apellidoPat;
                afiliado.ApellidoMat = apellidoMat;
                afiliado.Sexo = sexo;
                afiliado.Edad = edad;
                afiliado.EstadoCivil = estadoCivil;
                afiliado.Domicilio = domicilio;
                afiliado.TelefonoFijo = telefonoFijo;
                afiliado.TelefonoCelular = telefonoCelular;
                afiliado.TelefonoAlter = telefonoAlter;
                afiliado.Ocupacion = ocupacion;
                afiliado.Escolaridad = escolaridad;
                afiliado.Email = email;
                afiliado.NumIne = numIne;
                afiliado.ClaveIne = claveIne;
                afiliado.Curp = curp;
                afiliado.Facebook = facebook;
                afiliado.Observaciones = observaciones;
            }
            else
            {
                afiliado.Id = idAfiliado;
                afiliado.Municipio = municipio;
                afiliado.Region = region;
                afiliado.Zona = zona;
                afiliado.Seccion = seccion;
                afiliado.Casilla = casilla;
                afiliado.Promotor = promotor;
                afiliado.Comunidad = comunidad;
                afiliado.Nombre = nombre;
                afiliado.NombreSegundo = nombreSegundo;
                afiliado.ApellidoPat = apellidoPat;
                afiliado.ApellidoMat = apellidoMat;
                afiliado.Sexo = sexo;
                afiliado.Edad = edad;
                afiliado.EstadoCivil = estadoCivil;
                afiliado.Domicilio = domicilio;
                afiliado.TelefonoFijo = telefonoFijo;
                afiliado.TelefonoCelular = telefonoCelular;
                afiliado.TelefonoAlter = telefonoAlter;
                afiliado.Ocupacion = ocupacion;
                afiliado.Escolaridad = escolaridad;
                afiliado.Email = email;
                afiliado.NumIne = numIne;
                afiliado.ClaveIne = claveIne;
                afiliado.Curp = curp;
                afiliado.Facebook = facebook;
                afiliado.Observaciones = observaciones;
                afiliado.Foto = imageArray;
                afiliado.CredencialFrontal = credencialF;
                afiliado.CredencialPosterior = credencialP;

            }

            return afiliado;
        }
    }
}
