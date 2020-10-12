using EncuestaHorizonte.Views;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EncuestaHorizonte
{
    public partial class App : Application
    {

        public static string DatabaseLocation = string.Empty;

        private async void GetPermissions()
        {
            try
            {
                var status = await Permissions.RequestAsync<Permissions.Camera>();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }

        }

        public App(string databaseLocation)
        {
            //Inicializar Componentes de la pagina principal
            InitializeComponent();

            //Crear una pagina principal
            this.MainPage = new NavigationPage(new LoginPage());

            //Preguntar por primera vez los servicios a usar
            GetPermissions();
            
            //Inicializacion de la base de datos sqlite
            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
