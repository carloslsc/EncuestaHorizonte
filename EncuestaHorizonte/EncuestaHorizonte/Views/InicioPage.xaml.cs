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
        public InicioPage()
        {
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
                await Application.Current.MainPage.DisplayAlert(
                    "ATENCIÓN",
                    "¿Desea Sincronizar la información?",
                    "Aceptar",
                    "Cancelar");

                
                ((ListView)sender).SelectedItem = null;
                
            }
            else if (item.Id == 1)
            {
                var respuesta = await Application.Current.MainPage.DisplayAlert(
                    "ATENCIÓN",
                    "¿Desea Cerrar Sesión?",
                    "Aceptar",
                    "Cancelar");

                ((ListView)sender).SelectedItem = null;

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