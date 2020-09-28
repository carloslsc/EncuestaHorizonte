using EncuestaHorizonte.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EncuestaHorizonte
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            this.MainPage = new NavigationPage(new LoginPage());

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
