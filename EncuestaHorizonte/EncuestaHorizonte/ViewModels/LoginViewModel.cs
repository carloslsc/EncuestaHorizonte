using EncuestaHorizonte.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using EncuestaHorizonte.Helpers;

namespace EncuestaHorizonte.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
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
            //this.apiService = new ApiService();
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
            
            /*if (Settings.AdminU.Equals(string.Empty) || Settings.AdminP.Equals(string.Empty))
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ConfigurationPage());
            }
            else*/ if (string.IsNullOrEmpty(this.Email))
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
            /*else if (this.Email.Equals(Settings.AdminU) && this.Password.Equals(Settings.AdminP))
            {
                this.Visible = true;
                this.IsRunning = true;
                this.Visible = false;
                this.IsRunning = false;
                await Application.Current.MainPage.Navigation.PushAsync(new ConfigurationPage());
            }*/
            else if (!this.Password.Equals("1") || !this.Email.Equals("1")/*this.Password.Equals(Settings.Password) || !this.Email.Equals(Settings.Usuario)*/)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "Usuario y/o Contraseña Invalidos",
                    "Aceptar");
                return;
            }
            else
            {
                this.Visible = true;
                this.IsRunning = true;

                /*DateTime Fecha = DateTime.UtcNow;
                int hora = Fecha.Hour - 6;
                int min = Fecha.Minute;
                int rows = 0;
                if (hora.Equals(int.Parse(Settings.Hora)))
                {
                    var connection = await this.apiService.CheckConnection();

                    if (!connection.IsSuccess)
                    {
                        this.IsRunning = false;
                        this.Visible = false;
                        await Application.Current.MainPage.DisplayAlert(
                            "Error",
                            connection.Message,
                            "Aceptar");
                        return;
                    }
                    else
                    {
                        DateTime fecha = Fecha.Date;
                        var response = await this.apiService.GetList<Data>("http://" + Settings.Servidor + "/finca_ban/json/enviados_a_tablet/", "jd" + fecha.ToString("yyyyMMdd") + ".json");

                        if (!response.IsSuccess)
                        {
                            this.IsRunning = false;
                            this.Visible = false;
                            await Application.Current.MainPage.DisplayAlert(
                                "ERROR",
                                response.Message,
                                "Aceptar");

                        }
                        else
                        {
                            var list = (List<Data>)response.Result;

                            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                            {
                                conn.DropTable<Empleado>();
                                conn.DropTable<Location>();
                                conn.CreateTable<Empleado>();
                                for (int i = 0; i < list.Count; i++)
                                {
                                    Empleado Emp = new Empleado()
                                    {
                                        IdCaporal = list[i].IdCaporal,
                                        NomCap = list[i].NomCap + " " + list[i].Capp + " " + list[i].Capm,
                                        Cnsle = list[i].Cnsle,
                                        IdEmp = list[i].IdEmp,
                                        NomEmp = list[i].NomEmp + " " + list[i].App + " " + list[i].Apm,
                                        IdLab = list[i].IdLab,
                                        DescLab = list[i].DescLab,
                                        IdArea = list[i].IdArea,
                                        Cable = 0,
                                        Lote = 0,
                                        Cantidad = 0,
                                        FecExeLab = list[i].FecExeLab,
                                        Dup = 0,
                                    };
                                    if (Emp.IdArea.Equals(int.Parse(Settings.Area)))
                                    {
                                        rows += conn.Insert(Emp);
                                    }
                                }
                            }
                            if (rows.Equals(0))
                            {
                                this.IsRunning = false;
                                this.Visible = false;
                                await Application.Current.MainPage.DisplayAlert(
                                    "ERROR",
                                    "Los valores recibidos no se almacenaron en el dispositivo",
                                    "Aceptar");
                            }
                            else
                            {
                                this.IsRunning = false;
                                this.Visible = false;

                                this.Email = string.Empty;
                                this.Password = string.Empty;

                                Application.Current.MainPage = new NavigationPage(new EmployeePage());
                                //}
                            }
                        }
                    }
                }
                else
                {
                    /*if (rows.Equals(0))
                    {
                        this.IsRunning = false;
                        this.Visible = false;
                        await Application.Current.MainPage.DisplayAlert(
                            "ERROR",
                            "Los valores recibidos no se almacenaron en el dispositivo",
                            "Aceptar");
                    }
                    else
                    {*/

                    this.Email = string.Empty;
                    this.Password = string.Empty;


                    this.IsRunning = false;
                    this.Visible = false;

                    Application.Current.MainPage = new NavigationPage(new InicioPage());
                    //}
                //}
            }
        }
        #endregion
    }
}
