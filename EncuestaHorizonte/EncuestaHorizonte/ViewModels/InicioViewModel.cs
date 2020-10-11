using EncuestaHorizonte.Helpers;
using EncuestaHorizonte.Models;
using EncuestaHorizonte.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
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
        private int exitosos;
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

        public int Exitosos
        {
            get { return this.exitosos; }
            set { SetValue(ref this.exitosos, value); }
        }
        #endregion

        #region Constructor
        public InicioViewModel()
        {
            //this.apiService = new ApiService();
            this.Usuario = Settings.Nombre;
            this.Exitosos = Int32.Parse(Settings.Exitosos);
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
            this.Afi = new Afiliado();
            await Application.Current.MainPage.Navigation.PushAsync(new AfiliadoCreatePage());
        }

        private async void Editar()
        {
            if (this.Afi.Id > 0)
            {
                var afiliado = this.Afi;
                this.Afi = new Afiliado();
                await Application.Current.MainPage.Navigation.PushAsync(new AfiliadoEditPage(afiliado));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ERROR",
                    "No ha seleccionado ningún afiliado",
                    "Aceptar");
            }
        }

        #endregion
    }
}
