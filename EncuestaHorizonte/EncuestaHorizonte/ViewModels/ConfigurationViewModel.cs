using EncuestaHorizonte.Helpers;
using EncuestaHorizonte.Models;
using EncuestaHorizonte.Services;
using GalaSoft.MvvmLight.Command;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace EncuestaHorizonte.ViewModels
{
    public class ConfigurationViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private int area;
        //private string usuario;
        //private string contrasena;
        private string servidor;
        //private int hora;
        private ObservableCollection<string> lugares;
        private int indexLu;
        private string lugarSelected;
        private string adminP;
        private string adminU;
        private bool isRunning;
        private bool isVisible;
        private bool running;
        private bool visible;
        private bool runningLugar;
        private bool visibleLugar;
        #endregion

        #region Properties
        public int Area
        {
            get { return this.area; }
            set { SetValue(ref this.area, value); }
        }

        public ObservableCollection<string> Lugares
        {
            get { return this.lugares; }
            set { SetValue(ref this.lugares, value); }
        }

        public int IndexLu
        {
            get { return this.indexLu; }
            set { SetValue(ref this.indexLu, value); }
        }

        public string LugarSelected
        {
            get { return this.lugarSelected; }
            set { SetValue(ref this.lugarSelected, value); }
        }

        public string Servidor
        {
            get { return this.servidor; }
            set { SetValue(ref this.servidor, value); }
        }

        public string AdminU
        {
            get { return this.adminU; }
            set { SetValue(ref this.adminU, value); }
        }

        public string AdminP
        {
            get { return this.adminP; }
            set { SetValue(ref this.adminP, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool Visible
        {
            get { return this.visible; }
            set { SetValue(ref this.visible, value); }
        }

        public bool Running
        {
            get { return this.running; }
            set { SetValue(ref this.running, value); }
        }

        public bool VisibleLugar
        {
            get { return this.visibleLugar; }
            set { SetValue(ref this.visibleLugar, value); }
        }

        public bool RunningLugar
        {
            get { return this.runningLugar; }
            set { SetValue(ref this.runningLugar, value); }
        }

        public bool IsVisible
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }
        #endregion

        #region Constructor
        public ConfigurationViewModel()
        {
            this.apiService = new ApiService();
            /*if (Settings.Area.Equals(string.Empty))
            {
                //this.Area = 0;
            }
            else
            {
                //this.Area = int.Parse(Settings.Area);
            }*/
            //this.Lugar = Settings.Area;
            this.Servidor = Settings.Servidor;
            this.AdminU = Settings.AdminU;
            this.AdminP = Settings.AdminP;
            this.Visible = false;
            this.Running = false;
            this.IsVisible = false;
            this.IsRunning = false;
            //this.Lugares = new ObservableCollection<string>();
            //this.LugarSelected = Settings.Area;
        }
        #endregion

        #region Commands
        public ICommand ActualizarCommand
        {
            get
            {
                return new RelayCommand(Actualizar);
            }
        }

        public ICommand UsuariosCommand
        {
            get
            {
                return new RelayCommand(Usuario);
            }
        }

        public ICommand LugaresCommand
        {
            get
            {
                return new RelayCommand(LugarMethod);
            }
        }
        #endregion

        #region Methods
        public async void Actualizar()
        {
            if (/*this.Area.Equals(0)*/this.LugarSelected.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Area Vacío",
                    "Aceptar");
            }
            else if (this.Servidor.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Servidor Vacío",
                    "Aceptar");
            }
            else if (this.AdminU.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Usuario del Administrador Vacío",
                    "Aceptar");
            }
            else if (this.AdminP.Equals(string.Empty))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Contraseña del Administrador Vacío",
                    "Aceptar");
            }
            /*
            else if (!Regex.IsMatch(this.Servidor, @"^[0-9]{1,3}[.][0-9]{1,3}[.][0-9]{1,3}[.][0-9]{1,3}$"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Error en la Manera de Escribir el Servidor",
                    "Aceptar");
            }*/
            /*else if (this.AdminU.Equals(this.Usuario))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Usuario y Usuario del Administrador no deben ser iguales",
                    "Aceptar");
            }*/
            else
            {
                this.Visible = false;
                this.Running = false;
                //Settings.Area = this.LugarSelected;
                //Settings.Area = string.Format("{0}", this.Area);
                //Settings.Usuario = this.Usuario;
                //Settings.Password = this.Contrasena;
                //Settings.Servidor = this.Servidor;
                /*this.Servidor = Settings.Servidor;
                this.AdminU = Settings.AdminU;
                this.AdminP = Settings.AdminP;
                this.LugarSelected = Settings.Area;
                */
                Settings.Servidor = this.Servidor;
                Settings.AdminU = this.AdminU;
                Settings.AdminP = this.AdminP;
                Settings.Area = this.LugarSelected;
                await Application.Current.MainPage.DisplayAlert(
                    "EXITO",
                    Settings.Area,
                    "Aceptar");
                //Settings.AdminU = this.AdminU;
                //Settings.AdminP = this.AdminP;
                await Application.Current.MainPage.DisplayAlert(
                    "EXITO",
                    "Los datos han sido actualizados \"DEBE VOLVER A ABRIR LA APLICACIÓN\"",
                    "Aceptar");
                this.Visible = false;
                this.Running = false;
            }
        }

        public async void Usuario()
        {
            this.IsVisible = true;
            this.IsRunning = true;

            var connection = await this.apiService.CheckConnection();
            
            if (!connection.IsSuccess)
            {
                this.Running = false;
                this.IsVisible = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }
            else
            {
                //Utilizar el servidor de settings y el nombre de la fecha actual
                var response = await this.apiService.GetList<DataUsuario>("https://" + Settings.Servidor + "/controladores/", "xamarin.controlador.php");

                if (!response.IsSuccess)
                {
                    this.Running = false;
                    this.IsVisible = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "ERROR",
                        response.Message,
                        "Aceptar");

                }

                var list = (List<DataUsuario>)response.Result;
                //var list = new List<DataLotes>(lis);
                int rows = 0;

                int area = 0;

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    //conn.CreateTable<Usuarios>();
                    var tabla = conn.Table<Lugares>().Where(l => l.Lugar == Settings.Area).FirstOrDefault();
                    area = tabla.Id;
                }

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.DropTable<Usuarios>();
                    conn.CreateTable<Usuarios>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Id_Lugar.Equals(area))
                        {
                            Usuarios Usuario = new Usuarios()
                            {
                                Nombre = list[i].Nombre,
                                Usuario = list[i].Usuario,
                                Password = list[i].Password,
                                Id_Lugar = list[i].Id_Lugar
                            };
                            rows += conn.Insert(Usuario);
                        }
                    }
                }

                this.Running = false;
                this.IsVisible = false;

                if (rows > 0)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "EXITO",
                        "Los datos han sido actualizados \"DEBE VOLVER A ABRIR LA APLICACIÓN\"",
                        "Aceptar");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "ERROR",
                        "Los valores recibidos no se almacenaron en el dispositivo",
                        "Aceptar");
                }
            }
        }

        public async void LugarMethod()
        {
            this.VisibleLugar = true;
            this.RunningLugar = true;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.RunningLugar = false;
                this.VisibleLugar = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }
            else
            {
                //Utilizar el servidor de settings y el nombre de la fecha actual
                var response = await this.apiService.GetList<DataLugar>("https://" + Settings.Servidor + "/controladores/", "lugar.controlador.php");

                if (!response.IsSuccess)
                {
                    this.RunningLugar = false;
                    this.VisibleLugar = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "ERROR",
                        response.Message,
                        "Aceptar");

                }

                var list = (List<DataLugar>)response.Result;
                //var list = new List<DataLotes>(lis);
                int rows = 0;

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.DropTable<Lugares>();
                    conn.CreateTable<Lugares>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        Lugares Lugar = new Lugares()
                        {
                            Id = list[i].Id_Lugar,
                            Lugar = list[i].Nombre_Lugar
                        };
                        rows += conn.Insert(Lugar);
                    }
                }

                this.Lugares = new ObservableCollection<string>();

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    var lista = conn.Table<Lugares>().ToList();
                    
                    foreach (var item in lista)
                        this.Lugares.Add(item.Lugar);
                }

                this.RunningLugar = false;
                this.VisibleLugar = false;

                if (rows > 0)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "EXITO",
                        "Los datos han sido actualizados \"DEBE VOLVER A ABRIR LA APLICACIÓN\"",
                        "Aceptar");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "ERROR",
                        "Los valores recibidos no se almacenaron en el dispositivo",
                        "Aceptar");
                }
            }
        }
        #endregion
    }
}
