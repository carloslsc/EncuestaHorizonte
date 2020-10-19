using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EncuestaHorizonte.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var areaStorage = SecureStorage.GetAsync("area_secure_storage");
                if (!areaStorage.Equals(string.Empty))
                {
                    string result = areaStorage.Result.Replace(" ","");
                    Logo.Source = string.Format("Logo{0}",result);
                }
                else
                {
                    Logo.Source = "LogoHorizonte";
                }
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert(
                    "Error",
                    ex.Message,
                    "Acepttar");
            }
        }
    }
}