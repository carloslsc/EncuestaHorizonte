using EncuestaHorizonte.Views;
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
            //this.IsRunning = false;
            //this.Visible = false;
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

            this.Visible = true;
            this.IsRunning = true;

            if (Settings.AdminU.Equals(string.Empty) || Settings.AdminP.Equals(string.Empty))
            {

                this.Email = string.Empty;
                this.Password = string.Empty;
                await Application.Current.MainPage.Navigation.PushAsync(new ConfigurationPage());
            }
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
            else if (this.Email.Equals(Settings.AdminU) && this.Password.Equals(Settings.AdminP))
            {
                this.Visible = true;
                this.IsRunning = true;
                this.Email = string.Empty;
                this.Password = string.Empty;
                this.Visible = false;
                this.IsRunning = false;
                await Application.Current.MainPage.Navigation.PushAsync(new ConfigurationPage());
            }
            else
            {
                

                byte[] PasswordBytes = Encoding.ASCII.GetBytes(this.Password);
                string cryptedPassword = Crypter.Blowfish.Crypt(PasswordBytes, "$2a$07$g0uO0D9wPLBqFWNLwzO5qu");

                
                int validacion = 0;

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    var usuarios = conn.Table<Usuarios>().ToList();

                    foreach (var item in usuarios)
                    {
                        
                        if (item.Password.Equals(cryptedPassword) && item.Usuario.Equals(this.Email))
                        {
                            Settings.Usuario = this.Email;
                            Settings.Password = cryptedPassword;
                            Settings.IdUsuario = string.Format("{0}",item.Id);

                            validacion++;
                        }
                    }
                }
                if (/*!this.Password.Equals(Settings.Password) || !this.Email.Equals(Settings.Usuario)*/validacion.Equals(0))
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "ERROR",
                        "Usuario y/o Contraseña Invalidos",
                        "Aceptar");
                    return;
                }
                else
                {  
                    this.IsRunning = false;
                    this.Visible = false;

                    this.Email = string.Empty;
                    this.Password = string.Empty;

                    Application.Current.MainPage = new NavigationPage(new InicioPage());
                    
                }
                
            }
        }
        #endregion
    }
}
