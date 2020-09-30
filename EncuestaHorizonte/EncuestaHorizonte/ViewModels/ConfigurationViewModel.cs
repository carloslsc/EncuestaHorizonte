using EncuestaHorizonte.Helpers;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace EncuestaHorizonte.ViewModels
{
    public class ConfigurationViewModel : BaseViewModel
    {
        #region Services
        //private ApiService apiService;
        #endregion

        #region Attributes
        private int area;
        //private string usuario;
        //private string contrasena;
        private string servidor;
        //private int hora;
        private string adminP;
        private string adminU;
        private bool isRunning;
        private bool isVisible;
        private bool running;
        private bool visible;
        #endregion

        #region Properties
        public int Area
        {
            get { return this.area; }
            set { SetValue(ref this.area, value); }
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

        public bool IsVisible
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }
        #endregion

        #region Constructor
        public ConfigurationViewModel()
        {
            //this.apiService = new ApiService();
            if (Settings.Area.Equals(string.Empty))
            {
                this.Area = 0;
            }
            else
            {
                this.Area = int.Parse(Settings.Area);
            }
            this.Servidor = Settings.Servidor;
            this.AdminU = Settings.AdminU;
            this.AdminP = Settings.AdminP;
            this.Visible = false;
            this.Running = false;
            this.IsVisible = false;
            this.IsRunning = false;
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

        public ICommand LotesCommand
        {
            get
            {
                return new RelayCommand(Usuario);
            }
        }
        #endregion

        #region Methods
        public async void Actualizar()
        {
            if (this.Area.Equals(0))
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
            else if (!Regex.IsMatch(this.Servidor, @"^[0-9]{1,3}[.][0-9]{1,3}[.][0-9]{1,3}[.][0-9]{1,3}$"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Error en la Manera de Escribir el Servidor",
                    "Aceptar");
            }
            /*else if (this.AdminU.Equals(this.Usuario))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Usuario y Usuario del Administrador no deben ser iguales",
                    "Aceptar");
            }*/
            else
            {
                this.Visible = true;
                this.Running = true;
                Settings.Area = string.Format("{0}", this.Area);
                //Settings.Usuario = this.Usuario;
                //Settings.Password = this.Contrasena;
                Settings.Servidor = this.Servidor;
                Settings.AdminU = this.AdminU;
                Settings.AdminP = this.AdminP;
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

            //var connection = await this.apiService.CheckConnection();
            /*
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
                var response = await this.apiService.GetList<DataLotes>("http://" + Settings.Servidor + "/finca_ban/json/", "jdlotes.json");

                if (!response.IsSuccess)
                {
                    this.Running = false;
                    this.IsVisible = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "ERROR",
                        response.Message,
                        "Aceptar");

                }

                var list = (List<DataLotes>)response.Result;
                //var list = new List<DataLotes>(lis);
                int rows = 0;

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.DropTable<Lotes>();
                    conn.CreateTable<Lotes>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        Lotes Lote = new Lotes()
                        {
                            IdArea = list[i].IdArea,
                            IdCable = list[i].IdCable,
                            IdLote = list[i].IdLote,
                            TamLote = list[i].TamLote,
                            Sel = 0,
                        };
                        rows += conn.Insert(Lote);
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
            */
        }
        #endregion
    }
}
