using EncuestaHorizonte.Helpers;
using EncuestaHorizonte.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EncuestaHorizonte.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AfiliadoEditPage : ContentPage
    {
        Afiliado TheAfi = new Afiliado();

        public AfiliadoEditPage(Afiliado Afi)
        {

            TheAfi = Afi;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Afiliado>();
                var Afiliado = conn.Table<Afiliado>().Where(x => x.Id.Equals(TheAfi.Id)).FirstOrDefault();
                Settings.Id = Afiliado.Id.ToString();
                Municipio.Text = Afiliado.Municipio;
                Region.Text = Afiliado.Region;
                Zona.Text = Afiliado.Zona;
                Seccion.Text = Afiliado.Seccion;
                Casilla.Text = Afiliado.Casilla;
                Promotor.Text = Afiliado.Promotor;
                Comunidad.Text = Afiliado.Comunidad;
                Nombre.Text = Afiliado.Nombre;
                NombreSegundo.Text = Afiliado.NombreSegundo;
                ApellidoPat.Text = Afiliado.ApellidoPat;
                ApellidoMat.Text = Afiliado.ApellidoMat;
                Edad.Text = Afiliado.Edad;
                Sexo.SelectedItem = Afiliado.Sexo;
                EstadoCivil.SelectedItem = Afiliado.EstadoCivil;
                Domicilio.Text = Afiliado.Domicilio;
                TelefonoFijo.Text = Afiliado.TelefonoFijo;
                TelefonoCelular.Text = Afiliado.TelefonoCelular;
                TelefonoAlter.Text = Afiliado.TelefonoAlter;
                Ocupacion.SelectedItem = Afiliado.Ocupacion;
                Escolaridad.SelectedItem = Afiliado.Escolaridad;
                Email.Text = Afiliado.Email;
                NumIne.Text = Afiliado.NumIne;
                ClaveIne.Text = Afiliado.ClaveIne;
                Curp.Text = Afiliado.Curp;
                Facebook.Text = Afiliado.Facebook;
                Observacion.Text = Afiliado.Observaciones;

                Image.Source = "no_image";
                CredencialFrontal.Source = "no_image";
                CredencialPosterior.Source = "no_image";

                try
                {
                    if (!Afiliado.Foto.Equals(null))
                        Image.Source = ImageSource.FromStream(() => new MemoryStream(Afiliado.Foto));

                    if (!Afiliado.CredencialFrontal.Equals(null))
                        CredencialFrontal.Source = ImageSource.FromStream(() => new MemoryStream(Afiliado.CredencialFrontal));

                    if (!Afiliado.CredencialPosterior.Equals(null))
                        CredencialPosterior.Source = ImageSource.FromStream(() => new MemoryStream(Afiliado.CredencialPosterior));
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}