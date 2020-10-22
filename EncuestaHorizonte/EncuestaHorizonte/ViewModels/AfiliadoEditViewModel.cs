using EncuestaHorizonte.Helpers;
using EncuestaHorizonte.Models;
using EncuestaHorizonte.Views;
using GalaSoft.MvvmLight.Command;
using Plugin.Media;
using Plugin.Media.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace EncuestaHorizonte.ViewModels
{
    public class AfiliadoEditViewModel : BaseViewModel
    {
        #region Helpers
        private FullAfiliado helperAfiliado;
        #endregion

        #region Attributes
        private int perfilTomado;
        private int frontalTomado;
        private int posteriorTomado;
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
        private ObservableCollection<string> sexos;
        private ObservableCollection<string> estadosCiviles;
        private string sexoSelected;
        private string edad;
        private string estadoCivilSelected;
        private string domicilio;
        private string telefonoFijo;
        private string telefonoCelular;
        private string telefonoAlter;
        private ObservableCollection<string> ocupaciones;
        private ObservableCollection<string> escolaridades;
        private string ocupacion;
        private string escolaridad;
        private string email;
        private string numIne;
        private string claveIne;
        private string curp;
        private string facebook;
        private string observacion;
        private Afiliado afiliado;
        private ImageSource fotoSource;
        private ImageSource credencialFrontalSource;
        private ImageSource credencialPosteriorSource;
        private MediaFile file;
        private MediaFile credencialFrontalfile;
        private MediaFile credencialPosteriorfile;
        #endregion

        #region Properties        
        public ImageSource FotoSource
        {
            get { return this.fotoSource; }
            set { SetValue(ref this.fotoSource, value); }
        }

        public ImageSource CredencialFrontalSource
        {
            get { return this.credencialFrontalSource; }
            set { SetValue(ref this.credencialFrontalSource, value); }
        }

        public ImageSource CredencialPosteriorSource
        {
            get { return this.credencialPosteriorSource; }
            set { SetValue(ref this.credencialPosteriorSource, value); }
        }

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

        public ObservableCollection<string> Sexos
        {
            get { return this.sexos; }
            set { SetValue(ref this.sexos, value); }
        }

        public ObservableCollection<string> EstadosCiviles
        {
            get { return this.estadosCiviles; }
            set { SetValue(ref this.estadosCiviles, value); }
        }

        public string SexoSelected
        {
            get { return this.sexoSelected; }
            set { SetValue(ref this.sexoSelected, value); }
        }

        public string Edad
        {
            get { return this.edad; }
            set { SetValue(ref this.edad, value); }
        }

        public string EstadoCivilSelected
        {
            get { return this.estadoCivilSelected; }
            set { SetValue(ref this.estadoCivilSelected, value); }
        }

        public string Domicilio
        {
            get { return this.domicilio; }
            set { SetValue(ref this.domicilio, value); }
        }

        public string TelefonoFijo
        {
            get { return this.telefonoFijo; }
            set
            {
                if (this.telefonoFijo != value)
                {
                    this.telefonoFijo = value;
                    OnPropertyChanged();
                    this.TelefonoFijo = TelefonoFormat(this.TelefonoFijo);
                }
            }
        }

        public string TelefonoCelular
        {
            get { return this.telefonoCelular; }
            set
            {
                if (this.telefonoCelular != value)
                {
                    this.telefonoCelular = value;
                    OnPropertyChanged();
                    this.TelefonoCelular = TelefonoFormat(this.TelefonoCelular);
                }
            }
        }

        public string TelefonoAlter
        {
            get { return this.telefonoAlter; }
            set
            {
                if (this.telefonoAlter != value)
                {
                    this.telefonoAlter = value;
                    OnPropertyChanged();
                    long num = 0;
                    if (this.TelefonoAlter.Length.Equals(10) && Int64.TryParse(this.TelefonoAlter, out num))
                    {
                        this.TelefonoAlter = TelefonoFormat(this.TelefonoAlter);
                    }
                }
            }
        }

        public ObservableCollection<string> Ocupaciones
        {
            get { return this.ocupaciones; }
            set { SetValue(ref this.ocupaciones, value); }
        }

        public ObservableCollection<string> Escolaridades
        {
            get { return this.escolaridades; }
            set { SetValue(ref this.escolaridades, value); }
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
        public AfiliadoEditViewModel()
        {
            this.helperAfiliado = new FullAfiliado();

            this.FotoSource = null;
            this.CredencialPosteriorSource = null;
            this.credencialFrontalSource = null;

            this.perfilTomado = 0;
            this.frontalTomado = 0;
            this.posteriorTomado = 0;

            //Llenado de los campos de tipo picker
            this.Sexos = new ObservableCollection<string>()
            {
                "Seleccione un sexo",
                "Masculino",
                "Femenino"
            };
            this.EstadosCiviles = new ObservableCollection<string>()
            {
                "Seleccione un estado civil",
                "Soltera/o",
                "Casada/o",
                "Viuda/o",
                "Madre Soltera",
                "Padre Soltero"
            };
            this.Ocupaciones = new ObservableCollection<string>()
            {
                "Seleccione una ocupación",
                "Desempleada/o",
                "Ama de Casa",
                "Estudiante",
                "Campesina/o / Ejidataria/o",
                "Pequeña/o Productor/a",
                "Comerciante",
                "Empleada/o de Gobierno",
                "Empleada/o Particular",
                "Empresaria/o",
                "Profesionista Independiente",
                "Jubilida/o / Pensionada/o",
                "Otra/o"
            };
            this.Escolaridades = new ObservableCollection<string>()
            {
                "Seleccione una escolaridad",
                "Ninguna",
                "Preescolar",
                "Primaria",
                "Secundaria",
                "Carrera Ténica con Secundaria Terminada",
                "Preparatoria o Bachillerato",
                "Carrera Técnica con Preparatoria Terminada",
                "Normal",
                "Profesional",
                "Posgrado"
            };
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

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(Delete);
            }
        }

        public ICommand SelectImageCommand
        {
            get
            {
                return new RelayCommand(SelectImage);
            }
        }
        public ICommand SelectCredencialFrontalCommand
        {
            get
            {
                return new RelayCommand(SelectCredencialFrontal);
            }
        }

        public ICommand SelectCredencialPosteriorCommand
        {
            get
            {
                return new RelayCommand(SelectCredencialPosterior);
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return new RelayCommand(Editar);
            }
        }
        #endregion

        #region Methods
        public async void Cancelar()
        {
            //Devolver a la página anterior
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public string TelefonoFormat(string telefono)
        {
            try
            {
                //Darle el formato a la cadena telefono
                string telefonoFinal = Regex.Replace(telefono, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");

                //Implementar el cambio de formato
                return telefonoFinal;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async void Delete()
        {
            //Preguntar al usuario si desea eliminar afiliado
            var respuesta = await Application.Current.MainPage.DisplayAlert(
                    "ALERTA",
                    "¿Desea eliminar al afiliado?",
                    "Aceptar",
                    "Cancelar");
            if (respuesta)
            {
                int rows = 0;
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    //Crear un objeto para eliminar
                    this.Afiliado = new Afiliado();

                    //Colocando un ID al objeto a eliminar
                    this.Afiliado.Id = int.Parse(Settings.Id);
                    
                    //Eliminar al promovido
                    conn.CreateTable<Afiliado>();
                    rows += conn.Delete(this.Afiliado);

                    if (rows > 0)
                    {
                        //Mensaje para el usuario
                        await Application.Current.MainPage.DisplayAlert(
                            "EXITO",
                            "El afiliado fue eliminado",
                            "Aceptar");
            
                        //Regresando al usuario a la pagina principal
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }
                }
            }

            
        }

        public async void SelectImage()
        {
            //Inicializar el servicio de CrossMedia
            await CrossMedia.Current.Initialize();

            //Preguntar si la camara esta disponible
            if (CrossMedia.Current.IsCameraAvailable)
            {
                //Obtener la imagen de la camara
                this.file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Name = "fotoPerfilEdit.jpg",
                        PhotoSize = PhotoSize.Small,
                        SaveToAlbum = false
                    });
            }

            //acumulador para contar las fotos tomadas
            this.perfilTomado++;

            //Pasar la imagen tomada a la vista XAML
            if (this.file != null)
            {
                this.FotoSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
        }

        public async void SelectCredencialFrontal()
        {
            //Inicializar el servicio de CrossMedia
            await CrossMedia.Current.Initialize();

            //Preguntar si la camara esta disponible
            if (CrossMedia.Current.IsCameraAvailable)
            {
                //Obtener la imagen de la camara
                this.credencialFrontalfile = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        //Directory = "Sample",
                        Name = "testCredencialFEdit.jpg",
                        PhotoSize = PhotoSize.Small,
                        SaveToAlbum = false
                    });
            }

            //acumulador para contar las fotos tomadas
            this.frontalTomado++;

            //Pasar la imagen tomada a la vista XAML
            if (this.credencialFrontalfile != null)
            {
                this.CredencialFrontalSource = ImageSource.FromStream(() =>
                {
                    var stream = credencialFrontalfile.GetStream();
                    return stream;
                });
            }
        }


        public async void SelectCredencialPosterior()
        {
            //Inicializar el servicio de CrossMedia
            await CrossMedia.Current.Initialize();

            //Preguntar si la camara esta disponible
            if (CrossMedia.Current.IsCameraAvailable)
            {
                //Obtener la imagen de la camara
                this.credencialPosteriorfile = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Name = "testCredencialPEdit.jpg",
                        PhotoSize = PhotoSize.Small,
                        SaveToAlbum = false,
                    });
            }

            //acumulador para contar las fotos tomadas
            this.posteriorTomado++;

            //Pasar la imagen tomada a la vista XAML
            if (this.credencialPosteriorfile != null)
            {
                this.CredencialPosteriorSource = ImageSource.FromStream(() =>
                {
                    var stream = credencialPosteriorfile.GetStream();
                    return stream;
                });
            }
        }

        public async void Editar()
        {
            //Variable para la validacion de campos numericos
            int num = 0;

            //Obtener las imagenes del XAML
            var imageFotoPerfil = this.FotoSource as FileImageSource;
            var imageCredencialFrontal = this.CredencialFrontalSource as FileImageSource;
            var imageCredencialPosterior = this.CredencialPosteriorSource as FileImageSource;

            //Obtencion de las rutas de las imagenes de XAML
            string fotoRuta = string.Empty;
            string credencialFRuta = string.Empty;
            string credencialPRuta = string.Empty;

            //Verificaciones de las cadenas de ruta de imagenes de XAML
            if (imageFotoPerfil == null)
            {
                fotoRuta = "0";
            }
            else
            {
                fotoRuta = "no_image";
            }

            if (imageCredencialFrontal == null)
            {
                credencialFRuta = "0";
            }
            else
            {
                credencialFRuta = "no_image";
            }

            if (imageCredencialPosterior == null)
            {
                credencialPRuta = "0";
            }
            else
            {
                credencialPRuta = "no_image";
            }

            //Validaciones
            //Validacion de Imagen de foto de perfil
            if (fotoRuta.Equals("no_image"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Se necesita una foto de perfil",
                    "Aceptar");
            }
            //Validaciones de campos vacios
            else if (this.Nombre.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Nombre Vacío",
                    "Aceptar");
            }
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
            else if (this.SexoSelected.Equals(this.Sexos.ElementAt(0)))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Sexo Vacío",
                    "Aceptar");
            }
            else if (this.Edad.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Edad Vacío",
                    "Aceptar");
            }
            //Validacion de campo numerico
            else if (!Int32.TryParse(this.Edad, out num))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo edad no es númerico",
                    "Aceptar");
            }
            else if (this.EstadoCivilSelected.Equals(this.EstadosCiviles.ElementAt(0)))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Estado Civil Vacío",
                    "Aceptar");
            }
            else if (this.Municipio.Equals(string.Empty))
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
            else if (!Int32.TryParse(this.Region, out num))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo región no es númerico",
                    "Aceptar");
            }
            /*else if (this.Zona.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Zona Vacío",
                    "Aceptar");
            }
            else if (!Int32.TryParse(this.Zona, out num))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo zona no es númerico",
                    "Aceptar");
            }
            else if (this.Seccion.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Sección Vacío",
                    "Aceptar");
            }
            else if (!Int32.TryParse(this.Seccion, out num))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo sección no es númerico",
                    "Aceptar");
            }*/
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
            else if (this.Domicilio.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Domicilio Vacío",
                    "Aceptar");
            }
            else if (this.TelefonoCelular.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Teléfono Celular Vacío",
                    "Aceptar");
            }
            //Validacion de tamaño de la cadena
            else if (!this.TelefonoCelular.Length.Equals(14))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Teléfono Celular Vacío",
                    "Aceptar");
            }
            else if (this.Ocupacion.Equals(this.Ocupaciones.ElementAt(0)))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Ocupación Vacío",
                    "Aceptar");
            }
            else if (this.Escolaridad.Equals(this.Escolaridades.ElementAt(0)))
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
            else if (!this.NumIne.Length.Equals(13))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    string.Format("Campo Número INE Tiene {0} dígitos y deben ser 13 dígitos", this.NumIne.Length),
                    "Aceptar");
            }
            else if (this.ClaveIne.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Clave de Elector Vacío",
                    "Aceptar");
            }
            else if (!this.ClaveIne.Length.Equals(18))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    string.Format("Campo Clave de Elector Tiene {0} caracteres y deben ser 18 caracteres", this.ClaveIne.Length),
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
                    string.Format("Campo CURP Tiene {0} caracteres y deben ser 18 caracteres", this.Curp.Length),
                    "Aceptar");
            }
            else if (credencialFRuta.Equals("no_image"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Foto frontal de la credencial es obligatoria",
                    "Aceptar");
            }
            else if (credencialPRuta.Equals("no_image"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Foto posterior de la credencial es obligatoria",
                    "Aceptar");
            }
            else
            {
                //Creacion de variables por default
                string id = Settings.Id;
                byte[] imageArray = null;
                byte[] credencialFArray = null;
                byte[] credencialPArray = null;

                //Obtener las imagenes del promovido ya en base de datos
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    var afiliado = conn.Table<Afiliado>().Where(a => a.Id.Equals(id)).FirstOrDefault();
                    imageArray = afiliado.Foto;
                    credencialFArray = afiliado.CredencialFrontal;
                    credencialPArray = afiliado.CredencialPosterior;
                }

                //convertir las imagenes en tipo byte[]
                if (this.file != null)
                {
                    imageArray = FilesHelper.ReadFully(this.file.GetStream());
                    File.Delete("/storage/emulated/0/Android/data/com.companyname.encuestahorizonte/files/Pictures/fotoPerfilEdit.jpg");
                    if (this.perfilTomado > 1)
                    {
                        for (int i = 1; i < this.perfilTomado; i++)
                        {
                            File.Delete(string.Format("/storage/emulated/0/Android/data/com.companyname.encuestahorizonte/files/Pictures/fotoPerfilEdit_{0}.jpg", i));
                        }
                    }
                    this.file.Dispose();
                    this.file = null;
                }

                if (this.credencialFrontalfile != null)
                {
                    credencialFArray = FilesHelper.ReadFully(this.credencialFrontalfile.GetStream());
                    File.Delete("/storage/emulated/0/Android/data/com.companyname.encuestahorizonte/files/Pictures/testCredencialFEdit.jpg");
                    if (this.frontalTomado > 1)
                    {
                        for (int i = 1; i < this.frontalTomado; i++)
                        {
                            File.Delete(string.Format("/storage/emulated/0/Android/data/com.companyname.encuestahorizonte/files/Pictures/testCredencialFEdit_{0}.jpg", i));
                        }
                    }
                    this.credencialFrontalfile.Dispose();
                    this.credencialFrontalfile = null;
                }

                if (this.credencialPosteriorfile != null)
                {
                    credencialPArray = FilesHelper.ReadFully(this.credencialPosteriorfile.GetStream());
                    File.Delete("/storage/emulated/0/Android/data/com.companyname.encuestahorizonte/files/Pictures/testCredencialPEdit.jpg");
                    if (this.posteriorTomado > 1)
                    {
                        for (int i = 1; i < this.posteriorTomado; i++)
                        {
                            File.Delete(string.Format("/storage/emulated/0/Android/data/com.companyname.encuestahorizonte/files/Pictures/testCredencialPEdit_{0}.jpg", i));
                        }
                    }
                    this.credencialPosteriorfile.Dispose();
                    this.credencialPosteriorfile = null;
                }

                this.perfilTomado = 0;
                this.frontalTomado = 0;
                this.posteriorTomado = 0;

                int rows = 0;
                try
                {
                    //Actualizar el afiliado
                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                        conn.CreateTable<Afiliado>();
                        this.Afiliado = new Afiliado();
                        this.Afiliado = this.helperAfiliado.Llenado(id, this.Municipio, this.Region, this.Zona, this.Seccion, this.Casilla, this.Promotor, this.Comunidad,
                            this.Nombre, this.NombreSegundo, this.ApellidoPat, this.ApellidoMat, this.SexoSelected, this.Edad, this.EstadoCivilSelected, this.Domicilio,
                            this.TelefonoFijo, this.TelefonoCelular, this.TelefonoAlter, this.Ocupacion, this.Escolaridad, this.Email, this.NumIne, this.ClaveIne, this.Curp,
                            this.Facebook, this.Observacion, Settings.IdUsuario, imageArray, credencialFArray, credencialPArray);
                        rows += conn.Update(this.Afiliado);
                    
                    }
                }
                catch (Exception e)
                {
                    //Mensaje de error con la base de datos
                    await Application.Current.MainPage.DisplayAlert(
                        "ERROR",
                        e.Message + "\n\nVolver a intentar",
                        "Aceptar");
                }

                if (rows > 0)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "EXITO",
                        "Actualización Exitosa",
                        "Aceptar");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(
                       "ERROR",
                       "La Actualización Falló",
                       "Aceptar");
                }
            }
        }
        #endregion
    }
}
