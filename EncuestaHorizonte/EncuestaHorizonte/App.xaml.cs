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

                //var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                /*if (status != Permissions.CheckStatusAsync<Permissions.Camera>Status. PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Se Requiere el uso de tu Camara", "Aceptar");
                    }
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
                    if (status == PermissionStatus.Granted)
                    {
                        //await App.Current.MainPage.DisplayAlert("Bien", "Se Requiere el uso de tu localización", "Aceptar");
                        //loc.GetLocation();
                        //await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0, 0, 1), 1);
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Camara Denegada", "Se Requiere el uso de tu Camara", "Aceptar");
                    }
                }*/
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
                //throw;
            }

        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            this.MainPage = new NavigationPage(new LoginPage());

            GetPermissions();
            
            DatabaseLocation = databaseLocation;

            //MainPage = new MainPage();
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
