using EncuestaHorizonte.Helpers;
using EncuestaHorizonte.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    /*
                    conn.CreateTable<Lotes>();
                    int area = int.Parse(Settings.Area);
                    var Lotes = conn.Table<Lotes>().Where(x => x.IdArea == area).ToList();
                    ObservableCollection<int> cables = new ObservableCollection<int>();
                    foreach (var item in Lotes)
                        if (!cables.Contains(item.IdCable))
                            cables.Add(item.IdCable);
                    Cable.ItemsSource = cables;
                    */
                    conn.CreateTable<Lugares>();
                    var lista = conn.Table<Lugares>().ToList();
                    if (!lista.Equals(null)) 
                    {
                        ObservableCollection<string> lugares = new ObservableCollection<string>();

                        foreach (var item in lista)
                            lugares.Add(item.Lugar);

                        Lugar.ItemsSource = lugares;

                        if (!Settings.Area.Equals(string.Empty))
                        {
                            Lugar.SelectedItem = Settings.Area;
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