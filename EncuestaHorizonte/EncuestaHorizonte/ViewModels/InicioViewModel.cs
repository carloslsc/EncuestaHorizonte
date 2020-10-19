using EncuestaHorizonte.Helpers;
using EncuestaHorizonte.Models;
using EncuestaHorizonte.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EncuestaHorizonte.ViewModels
{
    public class InicioViewModel : BaseViewModel
    {
        #region Services
        //private ApiService apiService;
        #endregion

        #region Attributes
        private string usuario;
        private ObservableCollection<Afiliado> afiliados;
        private Afiliado afi;
        #endregion

        #region Properties
        public ObservableCollection<Afiliado> Afiliados
        {
            get { return this.afiliados; }
            set { SetValue(ref this.afiliados, value); }
        }

        public Afiliado Afi
        {
            get { return this.afi; }
            set { SetValue(ref this.afi, value);}
        }

        public string Usuario
        {
            get { return this.usuario; }
            set { SetValue(ref this.usuario, value); }
        }

        #endregion

        #region Constructor
        public InicioViewModel()
        {
            //this.apiService = new ApiService();
            /*try
            {
                this.Usuario = SecureStorage.GetAsync("nombre_secure_storage").Result;
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert(
                    "Error",
                    ex.Message,
                    "Aceptar");
            }*/
            //this.Usuario = Settings.Nombre;
            this.Afi = new Afiliado();
        }
        #endregion

        #region Commands
        public ICommand CapturarCommand
        {
            get
            {
                return new RelayCommand(Capturar);
            }
        }

        public ICommand EditarCommand
        {
            get
            {
                return new RelayCommand(Editar);
            }
        }
        #endregion

        #region Methods
        private async void Capturar()
        {
            //Reseteo del Item seleccionado
            this.Afi = new Afiliado();

            //Cambio de Pagina
            await Application.Current.MainPage.Navigation.PushAsync(new AfiliadoCreatePage());
        }

        private async void Editar()
        {
            //Verificacion de haber seleccionado un usuario
            if (this.Afi.Id > 0)
            {
                //Crear la variable del usuario que se mandara
                var afiliado = this.Afi;
                
                //Reseteo del item seleccionado
                this.Afi = new Afiliado();
                
                //Cambio de pagina
                await Application.Current.MainPage.Navigation.PushAsync(new AfiliadoEditPage(afiliado));
            }
            else
            {
                //Mensaje para el usuario
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "No ha seleccionado ningún afiliado",
                    "Aceptar");
            }
        }

        #endregion
    }
}
