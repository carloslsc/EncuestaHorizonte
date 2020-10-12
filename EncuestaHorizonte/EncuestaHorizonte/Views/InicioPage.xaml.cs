using EncuestaHorizonte.Helpers;
using EncuestaHorizonte.Models;
using EncuestaHorizonte.Services;
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
                //Preguntar al usuario si desea sincronizar
                var respuesta = await Application.Current.MainPage.DisplayAlert(
                    "ATENCIÓN",
                    "¿Desea Sincronizar la información?",
                    "Aceptar",
                    "Cancelar");

                //Setear vacio el item selected
                ((ListView)sender).SelectedItem = null;

                if (respuesta)
                {
                    //Activar el ActiviyIndicator
                    MasterPage.ActivityIndicator.IsRunning = true;
                    MasterPage.ActivityIndicator.IsVisible = true;

                    //Solicitar conexión con el servidor
                    var connection = await this.apiService.CheckConnection();

                    if (!connection.IsSuccess)
                    {
                        //Desactivar el ActivityIndicator
                        MasterPage.ActivityIndicator.IsRunning = false;
                        MasterPage.ActivityIndicator.IsVisible = false;

                        await Application.Current.MainPage.DisplayAlert(
                            "Error",
                            connection.Message,
                            "Aceptar");
                        return;
                    }
                    else
                    {
                        //Inicializar el objeto de enviado
                        Send Objeto = new Send();

                        using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                        {
                            //Obtener todos los afiliados por usuario
                            var afiliados = conn.Table<Afiliado>().Where(a => a.IdUsuario.Equals(Settings.IdUsuario)).ToList();

                            List<AfiliadoSend> afiliadosSend = new List<AfiliadoSend>();
                            
                            foreach (var afiliado in afiliados)
                            {
                                AfiliadoSend afiliadoSend = new AfiliadoSend()
                                {
                                    Nombre = afiliado.Nombre,
                                    NombreSegundo = afiliado.NombreSegundo,
                                    ApellidoPat = afiliado.ApellidoPat,
                                    ApellidoMat = afiliado.ApellidoMat,
                                    Sexo = afiliado.Sexo,
                                    Edad = afiliado.Edad,
                                    EstadoCivil = afiliado.EstadoCivil,
                                    Domicilio = afiliado.Domicilio,
                                    Municipio = afiliado.Municipio,
                                    Region = afiliado.Region,
                                    Zona = afiliado.Zona,
                                    Seccion = afiliado.Seccion,
                                    Casilla = afiliado.Casilla,
                                    Promotor = afiliado.Promotor,
                                    Comunidad = afiliado.Comunidad,
                                    TelefonoFijo = afiliado.TelefonoFijo,
                                    TelefonoCelular = afiliado.TelefonoCelular,
                                    TelefonoAlter = afiliado.TelefonoAlter,
                                    Ocupacion = afiliado.Ocupacion,
                                    Escolaridad = afiliado.Escolaridad,
                                    Email = afiliado.Email,
                                    NumIne = afiliado.NumIne,
                                    ClaveIne = afiliado.ClaveIne,
                                    Curp = afiliado.Curp,
                                    Facebook = afiliado.Facebook,
                                    Observaciones = afiliado.Observaciones,
                                    Foto = afiliado.Foto,
                                    CredencialFrontal = afiliado.CredencialFrontal,
                                    CredencialPosterior = afiliado.CredencialPosterior
                                };

                                //Agregar un afiliado nuevo a la lista de envio
                                afiliadosSend.Add(afiliadoSend);
                            }
                            //Agregar la lista de afiliados al objeto a enviar
                            Objeto.Afiliados = afiliadosSend;
                        }

                        //Crear un nuevo usuario para enviar
                        UsuarioSend usuarioSend = new UsuarioSend()
                        {
                            IdUsuario = Settings.IdUsuario
                        };

                        //Agregar el usuario a enviar al objeto a enviar
                        Objeto.UsuarioSend = usuarioSend;

                        //Enviar los afiliados y el usuario
                        var response = await this.apiService.Post<Send>("https://" + Settings.Servidor + "/controladores/", "promovidos.controlador.php", Objeto);

                        //Obtencion de respuesta del servidor
                        var objetoResult = (Result)response.Result;

                        using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                        {
                            //Obtención de el numero de casos exitosos que hay en servidor
                            UsuarioSincronizado usuario = new UsuarioSincronizado()
                            {
                                Exitosos = Int32.Parse(objetoResult.Exitosos.TotalExitosos),
                                IdUsuario = Int32.Parse(Settings.IdUsuario)
                            };
                            conn.InsertOrReplace(usuario);
                        }

                        //Resultado esperando promovidos repetidos
                        if (objetoResult.Fallidos.Count > 0)
                        {
                            string promovidosFallidos = string.Empty;

                            //Agregando a una cadena el nombre y la curp de los promovidos repetidos
                            foreach (var itemResult in objetoResult.Fallidos)
                            {
                                promovidosFallidos += string.Format("Nombre: {0}\nCURP: {1}\n\n", itemResult.NombreCompleto, itemResult.Curp);
                            }

                            //Eliminacion de los afiliados en la base de datos interna
                            /*
                            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                            {
                                //conn.Delete<Afiliado>();
                            }*/

                            //Desactivacion del ActivityIndicator
                            MasterPage.ActivityIndicator.IsRunning = false;
                            MasterPage.ActivityIndicator.IsVisible = false;

                            await Application.Current.MainPage.DisplayAlert(
                                "EXITO",
                                "Se sincronizó exitosamente la \ncantidad de: "+objetoResult.Exitosos.ExitososAlMomento+
                                " y cuenta con: "+objetoResult.Exitosos.TotalExitosos+" promovidos\n\n"+
                                "Sin embargo solo los siguientes\nno pudieron ser sincronizados:\n\n"+promovidosFallidos,
                                "Aceptar");
                        }
                        //Resultado no esperando promovidos repetidos
                        else
                        {
                            //Eliminacion de los afiliados en la base de datos interna
                            /*
                            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                            {
                                //conn.Delete<Afiliado>();
                            }*/

                            //Desactivacion del ActivityIndicator
                            MasterPage.ActivityIndicator.IsRunning = false;
                            MasterPage.ActivityIndicator.IsVisible = false;

                            await Application.Current.MainPage.DisplayAlert(
                                "EXITO",
                                "Se sincronizó exitosamente la \ncantidad de: " + objetoResult.Exitosos.ExitososAlMomento +
                                " y cuenta con: " + objetoResult.Exitosos.TotalExitosos + " promovidos\n",
                                "Aceptar");
                        }
                    }
                }                        
            }
            //Cerrar Sesión
            else if (item.Id == 1)
            {
                //Consulta para saber si desea cerrar sesión
                var respuesta = await Application.Current.MainPage.DisplayAlert(
                    "ATENCIÓN",
                    "¿Desea Cerrar Sesión?",
                    "Aceptar",
                    "Cancelar");

                //Resetear el item seleccionado
                ((ListView)sender).SelectedItem = null;

                //Eliminar las persistencias usadas
                Settings.IdUsuario = string.Empty;
                Settings.Id = string.Empty;
                Settings.Nombre = string.Empty;

                //Cambio de pagina
                if (respuesta)
                {
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                }
            }
        }
    }
}
