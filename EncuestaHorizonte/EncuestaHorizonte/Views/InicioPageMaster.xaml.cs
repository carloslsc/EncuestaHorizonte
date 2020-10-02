using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EncuestaHorizonte.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPageMaster : ContentPage
    {
        public ListView ListView;

        public InicioPageMaster()
        {
            InitializeComponent();

            //BindingContext = new InicioPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class InicioPageMasterViewModel //: INotifyPropertyChanged
        {
            /*public ObservableCollection<InicioPageMasterMenuItem> MenuItems { get; set; }

            public InicioPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<InicioPageMasterMenuItem>(new[]
                {
                    new InicioPageMasterMenuItem { Id = 0, Title = "Sincronizar" },
                    new InicioPageMasterMenuItem { Id = 1, Title = "Cerrar Sesión" }
                });
            }*/

            #region INotifyPropertyChanged Implementation
            /*public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }*/
            #endregion
        }
    }
}