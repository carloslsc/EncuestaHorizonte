﻿using EncuestaHorizonte.Helpers;
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
        private string servidor;
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
            //Se activa el ActivityIndicator
            this.Visible = true;
            this.Running = true;

            //Validaciones
            //Se validan que los campos no esten vacios
            if (this.LugarSelected.Equals(string.Empty))
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
            else
            {
                //Se obtiene el Id del lugar
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    var tabla = conn.Table<Lugares>().Where(l => l.Lugar == this.LugarSelected).FirstOrDefault();
                    Settings.IdArea = tabla.Id.ToString();
                }

                //Se copian los datos ingresados a una clase de persistencia llamada Settings
                Settings.Servidor = this.Servidor;
                Settings.AdminU = this.AdminU;
                Settings.AdminP = this.AdminP;
                Settings.Area = this.LugarSelected;

                //Se desactiva el ActivityIndicator
                this.Visible = false;
                this.Running = false;

                //El usuario recibe una mensaje de exito
                await Application.Current.MainPage.DisplayAlert(
                    "EXITO",
                    "Los datos han sido actualizados \"DEBE VOLVER A ABRIR LA APLICACIÓN\"",
                    "Aceptar");
            }
        }

        public async void Usuario()
        {
            //Se activa el ActivityIndicator
            this.IsVisible = true;
            this.IsRunning = true;

            //Se solicita una comunicacion con el servidor
            var connection = await this.apiService.CheckConnection();
            
            //Se verifica la comunicacion con el servidor
            if (!connection.IsSuccess)
            {
                //Se desactiva el ActivityIndicator
                this.IsRunning = false;
                this.IsVisible = false;

                //Se muestra al usuario un mensaje de error
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }
            else
            {
                //Se solicita al servidor la lista de usuarios
                var response = await this.apiService.GetList<DataUsuario>("https://" + Settings.Servidor + "/controladores/", "xamarin.controlador.php");

                //Se verifica la respuesta del servidor
                if (!response.IsSuccess)
                {
                    //Se desactiva el ActivityIndicator
                    this.IsRunning = false;
                    this.IsVisible = false;

                    //Se muestra al usuario un mensaje de error
                    await Application.Current.MainPage.DisplayAlert(
                        "ERROR",
                        response.Message,
                        "Aceptar");

                }

                //Se castea la lista de usuarios obtenidas del servidor para su manipulación dentro del códgio
                var list = (List<DataUsuario>)response.Result;

                //Banderas creadas para el funcionamiento del código
                int rows = 0;

                //Se crean los usuarios en sqlite segun su lugar
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    //Reseteo de la tabla
                    conn.DropTable<Usuarios>();
                    conn.CreateTable<Usuarios>();

                    //Inserción de usuarios
                    for (int i = 0; i < list.Count; i++)
                    {
                        //Verificación de lugar
                        if (list[i].Id_Lugar.Equals(Settings.IdArea))
                        {
                            //Creación del modelo usuario
                            Usuarios Usuario = new Usuarios()
                            {
                                Id = list[i].Id_Usuario,
                                Nombre = list[i].Nombre,
                                Usuario = list[i].Usuario,
                                Password = list[i].Password,
                                Id_Lugar = list[i].Id_Lugar
                            };
                            //Inserción a la tabla usuario
                            rows += conn.Insert(Usuario);
                        }
                    }
                }

                //Se desactiva el ActivityIndicator
                this.Running = false;
                this.IsVisible = false;

                //Mensajes de exito o error;
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
            //Se activa el ActivityIndicator
            this.VisibleLugar = true;
            this.RunningLugar = true;

            //Se solicita conexion al servidor
            var connection = await this.apiService.CheckConnection();

            //Se verifica la conexion al servidor
            if (!connection.IsSuccess)
            {
                //Se desactiva el ActivityIndicator
                this.RunningLugar = false;
                this.VisibleLugar = false;
                
                //Mensaje para el usuario
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }
            else
            {
                //Se solicita la lista de lugares
                var response = await this.apiService.GetList<DataLugar>("https://" + Settings.Servidor + "/controladores/", "lugar.controlador.php");

                //Se verifica el correcto recibimiento de los lugares
                if (!response.IsSuccess)
                {
                    //Se desactiva el ActivityIndicator
                    this.RunningLugar = false;
                    this.VisibleLugar = false;

                    //Mensaje para el usuario
                    await Application.Current.MainPage.DisplayAlert(
                        "ERROR",
                        response.Message,
                        "Aceptar");

                }

                //Casteo de la respuesta del servidor para la manipulación dentro del código
                var list = (List<DataLugar>)response.Result;

                //Banderas creadas
                int rows = 0;

                //Reseteo de la instancia de lugares en el XAML
                this.Lugares = new ObservableCollection<string>();

                //Agregar los lugares a base de datos
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    //Reseteo de la tabla
                    conn.DropTable<Lugares>();
                    conn.CreateTable<Lugares>();

                    //Inserción de los lugares a la tabla y a la instancia de XAML
                    for (int i = 0; i < list.Count; i++)
                    {
                        Lugares Lugar = new Lugares()
                        {
                            Id = list[i].Id_Lugar,
                            Lugar = list[i].Nombre_Lugar
                        };

                        this.Lugares.Add(list[i].Nombre_Lugar);

                        rows += conn.Insert(Lugar);
                    }
                }

                //Se desactiva el ActivityIndicator
                this.RunningLugar = false;
                this.VisibleLugar = false;

                //Mensajes de exito y error
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
