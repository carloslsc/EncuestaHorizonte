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
        private bool isVisible;
        private bool isRunning;
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

        public bool IsVisible
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        #endregion

        #region Constructor
        public InicioViewModel()
        {
            //this.apiService = new ApiService();
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
        /*
        private async void Enviar()
        {
            var response = await Application.Current.MainPage.DisplayAlert(
                    "ALERTA",
                    "Desea Enviar los datos al servidor",
                    "Aceptar",
                    "Cancelar");
            if (response)
            {
                this.IsRunning = true;
                this.IsVisible = true;

                var connection = await this.apiService.CheckConnection();

                if (!connection.IsSuccess)
                {
                    this.IsRunning = false;
                    this.IsVisible = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        connection.Message,
                        "Aceptar");
                    return;
                }
                else
                {
                    List<Send> Objeto = new List<Send>();
                    List<Empleado> Emp = new List<Empleado>();
                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                        conn.CreateTable<Empleado>();
                        Emp = conn.Table<Empleado>().Where(x => x.Dup.Equals(1)).ToList();
                        foreach (var item in Emp)
                        {
                            Send O = new Send()
                            {
                                IdCaporal = item.IdCaporal,
                                /*IdEmp = item.IdEmp,
                                IdLab = item.IdLab,*/
                                //IdArea = item.IdArea,
                                //Cnsle = item.Cnsle,
                                //IdCable = item.Cable,
                                //IdLote = item.Lote,
                                //Cantidad = item.Cantidad,
                                //FecExeLab = item.FecExeLab
                            /*};
                            Objeto.Add(O);
                        }
                    }

                    var respuesta = await this.apiService.Post<Send>("http://" + Settings.Servidor + "/finca_ban/", "cont.php", Objeto);

                    this.IsRunning = false;
                    this.IsVisible = false;

                    if (respuesta.IsSuccess)
                    {
                        await Application.Current.MainPage.DisplayAlert(
                            "EXITO",
                            "Datos enviados",
                            "Aceptar");
                        using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                        {
                            conn.CreateTable<Lotes>();
                            var Lotes = conn.Table<Lotes>().Where(x => x.Sel.Equals(1)).ToList();
                            foreach (var item in Lotes)
                            {
                                item.Sel = 0;
                                conn.Update(item);
                            }
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert(
                            "ERROR",
                            "Los datos no fueron enviados",
                            "Aceptar");
                    }
                }
            }
        }
        */

        private async void Capturar()
        {
            this.Afi = null;//new Afiliado();
            await Application.Current.MainPage.Navigation.PushAsync(new AfiliadoCreatePage());
        }

        private async void Editar()
        {
            if (!this.Afi.Id.Equals(0))
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
