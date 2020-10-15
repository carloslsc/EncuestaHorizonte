using EncuestaHorizonte.Helpers;
using EncuestaHorizonte.Models;
using SQLite;
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
    public partial class InicioPageDetail : ContentPage
    {

        public ListView ListView;
        public Label Label;

        public InicioPageDetail()
        {
            InitializeComponent();

            //Lista de objetos manipulables en  InicioPages.xaml.cs
            ListView = Lista;
            Label = Exitosos;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Exitosos.Text = "0";

            try
            {
                //Obtencion de los promovidos segun usuario
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    //Obtencion de los promovidos segun usuario
                    conn.CreateTable<Afiliado>();
                    var list = conn.Table<Afiliado>().Where(a => a.IdUsuario.Equals(Settings.IdUsuario)).ToList();
                    Lista.ItemsSource = list;
                }

                //Cambio en el campo exitosos en XAML
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    //Obtencion de la cantidad de casos exitosos del usuario
                    conn.CreateTable<UsuarioSincronizado>();
                    UsuarioSincronizado usuarioSincronizado = conn.Table<UsuarioSincronizado>().Where(a => a.IdUsuario.Equals(Settings.IdUsuario)).FirstOrDefault();

                    //Verificacion de la existencia de al menos un caso de exito del usuario
                    if (usuarioSincronizado != null)
                    {
                        Exitosos.Text = usuarioSincronizado.Exitosos.ToString();
                    }
                }
            }
            catch (Exception e)
            {

                Application.Current.MainPage.DisplayAlert(
                    "Error",
                    e.Message,
                    "Aceptar");

            }
        }
    }
}