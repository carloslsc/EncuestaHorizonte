using EncuestaHorizonte.Helpers;
using EncuestaHorizonte.Models;
using EncuestaHorizonte.Views;
using GalaSoft.MvvmLight.Command;
using Plugin.Media;
using Plugin.Media.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EncuestaHorizonte.ViewModels
{
    public class AfiliadoCreateViewModel : BaseViewModel
    {
        #region Helpers
        private FullAfiliado helperAfiliado;
        #endregion

        #region Attributes
        private string municipio;
        private string region;
        private string zona;
        private string seccion;
        private string casilla;
        private string promotor;
        private string comunidad;
        private string nombre;
        private string nombreSegundo;
        private string apellidoPat;
        private string apellidoMat;
        private string domicilio;
        private string telefonoFijo;
        private string telefonoCelular;
        private string telefonoAlter;
        private string ocupacion;
        private string escolaridad;
        private string email;
        private string numIne;
        private string claveIne;
        private string curp;
        private string facebook;
        private string observacion;
        private Afiliado afiliado;
        private ImageSource imageSource;
        private MediaFile file;
        #endregion

        #region Properties
        public ImageSource ImageSource
        {
            get { return this.imageSource; }
            set { SetValue(ref this.imageSource, value); }
        }

        /*public MediaFile File
        {
            get { return this.file; }
            set { SetValue(ref this.file, value); }
        }*/

        public string Municipio 
        {
            get { return this.municipio; }
            set { SetValue(ref this.municipio, value); }
        }

        public string Region
        {
            get { return this.region; }
            set { SetValue(ref this.region, value); }
        }

        public string Zona
        {
            get { return this.zona; }
            set { SetValue(ref this.zona, value); }
        }

        public string Seccion
        {
            get { return this.seccion; }
            set { SetValue(ref this.seccion, value); }
        }

        public string Casilla
        {
            get { return this.casilla; }
            set { SetValue(ref this.casilla, value); }
        }

        public string Promotor
        {
            get { return this.promotor; }
            set { SetValue(ref this.promotor, value); }
        }

        public string Comunidad
        {
            get { return this.comunidad; }
            set { SetValue(ref this.comunidad, value); }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }

        public string NombreSegundo
        {
            get { return this.nombreSegundo; }
            set { SetValue(ref this.nombreSegundo, value); }
        }

        public string ApellidoPat
        {
            get { return this.apellidoPat; }
            set { SetValue(ref this.apellidoPat, value); }
        }

        public string ApellidoMat
        {
            get { return this.apellidoMat; }
            set { SetValue(ref this.apellidoMat, value); }
        }

        public string Domicilio
        {
            get { return this.domicilio; }
            set { SetValue(ref this.domicilio, value); }
        }

        public string TelefonoFijo
        {
            get { return this.telefonoFijo; }
            set { SetValue(ref this.telefonoFijo, value); }
        }

        public string TelefonoCelular
        {
            get { return this.telefonoCelular; }
            set { SetValue(ref this.telefonoCelular, value); }
        }

        public string TelefonoAlter
        {
            get { return this.telefonoAlter; }
            set { SetValue(ref this.telefonoAlter, value); }
        }

        public string Ocupacion
        {
            get { return this.ocupacion; }
            set { SetValue(ref this.ocupacion, value); }
        }

        public string Escolaridad
        {
            get { return this.escolaridad; }
            set { SetValue(ref this.escolaridad, value); }
        }

        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string NumIne
        {
            get { return this.numIne; }
            set { SetValue(ref this.numIne, value); }
        }

        public string ClaveIne
        {
            get { return this.claveIne; }
            set { SetValue(ref this.claveIne, value); }
        }

        public string Curp
        {
            get { return this.curp; }
            set { SetValue(ref this.curp, value); }
        }

        public string Facebook
        {
            get { return this.facebook; }
            set { SetValue(ref this.facebook, value); }
        }

        public string Observacion
        {
            get { return this.observacion; }
            set { SetValue(ref this.observacion, value); }
        }

        public Afiliado Afiliado
        {
            get { return this.afiliado; }
            set { SetValue(ref this.afiliado, value); }
        }
        #endregion

        #region Constructor
        public AfiliadoCreateViewModel()
        {
            this.helperAfiliado = new FullAfiliado();
            this.Municipio = string.Empty;
            this.Region = string.Empty;
            this.Zona = string.Empty;
            this.Seccion = string.Empty;
            this.Casilla = string.Empty;
            this.Promotor = string.Empty;
            this.Comunidad = string.Empty;
            this.Nombre = string.Empty;
            this.NombreSegundo = string.Empty;
            this.ApellidoPat = string.Empty;
            this.ApellidoMat = string.Empty;
            this.Domicilio = string.Empty;
            this.TelefonoFijo = string.Empty;
            this.TelefonoCelular = string.Empty;
            this.TelefonoAlter = string.Empty;
            this.Ocupacion = string.Empty;
            this.Escolaridad = string.Empty;
            this.Email = string.Empty;
            this.NumIne = string.Empty;
            this.ClaveIne = string.Empty;
            this.Curp = string.Empty;
            this.Facebook = string.Empty;
            this.Observacion = string.Empty;
            this.ImageSource = "no_image";
        }
        #endregion

        #region Commands
        public ICommand CancelarCommand
        {
            get
            {
                return new RelayCommand(Cancelar);
            }
        }

        public ICommand SelectImageCommand
        {
            get
            {
                return new RelayCommand(SelectImage);
            }
        }

        public ICommand CreateCommand
        {
            get
            {
                return new RelayCommand(Capturar);
            }
        }
        #endregion

        #region Methods
        public void Cancelar()
        {
            Application.Current.MainPage = new InicioPage();
            //await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async void SelectImage()
        {
            await CrossMedia.Current.Initialize();

            if (CrossMedia.Current.IsCameraAvailable)
            {
                this.file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.jpg",
                        PhotoSize = PhotoSize.Small
                    });
            }
            if (this.file != null)
            {
                this.ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
        }

        public async void Capturar()
        {
            if (this.Municipio.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Municipio Vacío",
                    "Aceptar");
            }
            else if (this.Region.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Región Vacío",
                    "Aceptar");
            }
            else if (this.Zona.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Zona Vacío",
                    "Aceptar");
            }
            else if (this.Seccion.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Sección Vacío",
                    "Aceptar");
            }
            else if (this.Casilla.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Casilla Vacío",
                    "Aceptar");
            }
            else if (this.Promotor.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Promotor Vacío",
                    "Aceptar");
            }
            else if (this.Comunidad.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Comunidad Vacío",
                    "Aceptar");
            }
            else if (this.Nombre.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Nombre Vacío",
                    "Aceptar");
            }
            /*else if (this.NombreSegundo.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Segundo Nombre Vacío",
                    "Aceptar");
            }*/
            else if (this.ApellidoPat.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Apellido Paterno Vacío",
                    "Aceptar");
            }
            else if (this.ApellidoMat.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Apellido Materno Vacío",
                    "Aceptar");
            }
            else if (this.Domicilio.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Domicilio Vacío",
                    "Aceptar");
            }
            else if (this.TelefonoFijo.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Teléfono Fijo Vacío",
                    "Aceptar");
            }
            else if (this.TelefonoCelular.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Teléfono Celular Vacío",
                    "Aceptar");
            }
            else if (this.TelefonoAlter.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Teléfono Alterno/Radio Vacío",
                    "Aceptar");
            }
            else if (this.Ocupacion.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Ocupación Vacío",
                    "Aceptar");
            }
            else if (this.Escolaridad.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Escolaridad Vacío",
                    "Aceptar");
            }
            else if (this.Email.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Correo Electrónico Vacío",
                    "Aceptar");
            }
            else if (!RegexUtilities.ComprobarFormatoEmail(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Formato Correo Electrónico Incorrecto",
                    "Aceptar");
            }
            else if (this.NumIne.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Número INE Vacío",
                    "Aceptar");
            }
            else if (!this.NumIne.Length.Equals(14))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Número INE Necesita 14 Dígitos",
                    "Aceptar");
            }
            else if (this.ClaveIne.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Clave INE Vacío",
                    "Aceptar");
            }
            else if (this.Curp.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo CURP Vacío",
                    "Aceptar");
            }
            else if (!this.Curp.Length.Equals(18))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo CURP Necesita 18 Dígitos",
                    "Aceptar");
            }
            else if (this.Facebook.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Facebook Vacío",
                    "Aceptar");
            }
            else if (this.Observacion.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Observación Vacío",
                    "Aceptar");
            }
            else
            {

                string id = null;
                byte[] imageArray = null;
                if(this.file != null)
                {
                    imageArray = FilesHelper.ReadFully(this.file.GetStream());
                }

                int rows = 0;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Afiliado>();
                    this.Afiliado = this.helperAfiliado.Llenado(id, this.Municipio, this.Region, this.Zona, this.Seccion, this.Casilla, this.Promotor, this.Comunidad,
                        this.Nombre, this.NombreSegundo, this.ApellidoPat, this.ApellidoMat, this.Domicilio, this.TelefonoFijo, this.TelefonoCelular, this.TelefonoAlter,
                        this.Ocupacion, this.Escolaridad, this.Email, this.NumIne, this.ClaveIne, this.Curp, this.Facebook, this.Observacion, imageArray);
                    rows += conn.Insert(this.Afiliado);
                }
                if (rows > 0)
                {
                    this.Municipio = string.Empty;
                    this.Region = string.Empty;
                    this.Zona = string.Empty;
                    this.Seccion = string.Empty;
                    this.Casilla = string.Empty;
                    this.Promotor = string.Empty;
                    this.Comunidad = string.Empty;
                    this.Nombre = string.Empty;
                    this.NombreSegundo = string.Empty;
                    this.ApellidoPat = string.Empty;
                    this.ApellidoMat = string.Empty;
                    this.Domicilio = string.Empty;
                    this.TelefonoFijo = string.Empty;
                    this.TelefonoCelular = string.Empty;
                    this.TelefonoAlter = string.Empty;
                    this.Ocupacion = string.Empty;
                    this.Escolaridad = string.Empty;
                    this.Email = string.Empty;
                    this.NumIne = string.Empty;
                    this.ClaveIne = string.Empty;
                    this.Curp = string.Empty;
                    this.Facebook = string.Empty;
                    this.Observacion = string.Empty;
                    await Application.Current.MainPage.DisplayAlert(
                        "EXITO",
                        "Creación Exitosa",
                        "Aceptar");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(
                       "ERROR",
                       "La Creación Falló",
                       "Aceptar");
                }
            }
        }
        #endregion
    }
}
