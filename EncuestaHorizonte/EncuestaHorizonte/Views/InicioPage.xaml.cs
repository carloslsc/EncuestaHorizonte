using EncuestaHorizonte.Helpers;
using EncuestaHorizonte.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EncuestaHorizonte.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : MasterDetailPage
    {

        #region Services
        private ApiService apiService;
        #endregion

        public InicioPage()
        {
            this.apiService = new ApiService();
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as InicioPageMasterMenuItem;
            if (item == null)
                return;

            if (item.Id == 0)
            {
                var respuesta = await Application.Current.MainPage.DisplayAlert(
                    "ATENCIÓN",
                    "¿Desea Sincronizar la información?",
                    "Aceptar",
                    "Cancelar");


                ((ListView)sender).SelectedItem = null;

                if (respuesta)
                {
                    var connection = await this.apiService.CheckConnection();

                    if (!connection.IsSuccess)
                    {
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
                    else if (item.Id == 1)
                    {
                        var respuesta = await Application.Current.MainPage.DisplayAlert(
                            "ATENCIÓN",
                            "¿Desea Cerrar Sesión?",
                            "Aceptar",
                            "Cancelar");

                        ((ListView)sender).SelectedItem = null;

                        Settings.Usuario = string.Empty;
                        Settings.Password = string.Empty;

                        if (respuesta)
                        {
                            Application.Current.MainPage = new NavigationPage(new LoginPage());
                        }
                    }
                    /*
                    var page = (Page)Activator.CreateInstance(item.TargetType);
                    page.Title = item.Title;

                    Detail = new NavigationPage(page);
                    IsPresented = false;

                    //MasterPage.ListView.SelectedItem = null;
                    if(e.SelectedItem == null)
                    {
                        return;
                    }*/
                                }
                }
        }
    }
}