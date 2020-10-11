﻿using EncuestaHorizonte.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using EncuestaHorizonte.Helpers;
using EncuestaHorizonte.Services;
using SQLite;
using EncuestaHorizonte.Models;
using CryptSharp;
using System.Threading.Tasks;

namespace EncuestaHorizonte.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private string email;
        private string password;
        private bool visible;
        private bool isRunning;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
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
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.apiService = new ApiService();
            this.IsRunning = false;
            this.Visible = false;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        #endregion

        #region Methods
        public async void Login()
        {
            //Acceso a la configuración cuando la app nunca se ha usado
            if (Settings.AdminU.Equals(string.Empty) || Settings.AdminP.Equals(string.Empty))
            {
                //Vaciado de campos en XAML
                this.Email = string.Empty;
                this.Password = string.Empty;

                //Cambio de pagina a configuracióon
                await Application.Current.MainPage.Navigation.PushAsync(new ConfigurationPage());
            }

            //Validaciones
            //Validación de campos vacios
            else if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Usuario Vacío",
                    "Aceptar");
                return;
            }
            else if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Campo Contraseña Vacío",
                    "Aceptar");
                return;
            }
            //Validación del usuario y contraseña del admin
            else if (this.Email.Equals(Settings.AdminU) && this.Password.Equals(Settings.AdminP))
            {
                //Vaciado de campos
                this.Email = string.Empty;
                this.Password = string.Empty;

                //Cambio de pagina a configuración
                await Application.Current.MainPage.Navigation.PushAsync(new ConfigurationPage());
            }
            else
            {
                //Activación del ActivityIndicator
                this.IsRunning = true;
                this.Visible = true;

                //Encriptacion de la contraseña de XAML
                byte[] PasswordBytes = Encoding.ASCII.GetBytes(this.Password);
                string cryptedPassword = Crypter.Blowfish.Crypt(PasswordBytes, "$2a$07$g0uO0D9wPLBqFWNLwzO5qu");

                //Validación de los campos de XAML con los usuarios de la tabla
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    //Obtención del usuario correcto de la tabla
                    var usuarioCorrecto = conn.Table<Usuarios>().Where(u => u.Usuario.Equals(this.Email) && u.Password.Equals(cryptedPassword)).FirstOrDefault();

                    //Desactivavión del ActivityIndicator
                    this.IsRunning = false;
                    this.Visible = false;

                    //Verificación de la existencia del usuario
                    if (!usuarioCorrecto.Equals(null))
                    {
                        //Vaciado de los campos en XAML
                        this.Email = string.Empty;
                        this.Password = string.Empty;

                        //Creación de la persistencia del Idusuario y nombre
                        Settings.IdUsuario = usuarioCorrecto.Id.ToString();
                        Settings.Nombre = usuarioCorrecto.Nombre;

                        //Cambio de página
                        Application.Current.MainPage = new NavigationPage(new InicioPage());
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert(
                            "ERROR",
                            "Usuario y/o Contraseña Invalidos",
                            "Aceptar");
                        return;
                    }
                }
                
            }
        }
        #endregion
    }
}
