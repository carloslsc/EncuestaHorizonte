using EncuestaHorizonte.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EncuestaHorizonte
{
    public partial class App : Application
    {

        public static string DatabaseLocation = string.Empty;

        public App(string databaseLocation)
        {
            InitializeComponent();

            this.MainPage = new NavigationPage(new LoginPage());

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
