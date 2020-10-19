using EncuestaHorizonte.Helpers;
using EncuestaHorizonte.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EncuestaHorizonte.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigurationPage : ContentPage
    {
        public ConfigurationPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Lugares>();
                    var lista = conn.Table<Lugares>().ToList();
                    if (!lista.Equals(null)) 
                    {
                        ObservableCollection<string> lugares = new ObservableCollection<string>() 
                        {
                            "Seleccione un lugar"
                        };

                        foreach (var item in lista)
                            lugares.Add(item.Lugar);

                        Lugar.ItemsSource = lugares;

                        try
                        {
                            var areaStorage = SecureStorage.GetAsync("area_secure_storage");
                            if (!areaStorage.Equals(string.Empty))
                            {
                                Lugar.SelectedItem = areaStorage.Result;
                            }
                            else
                            {
                                Lugar.SelectedItem = lugares.ElementAt(0);
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
            catch (Exception e)
            {
                throw;
            }
        }
    }
}