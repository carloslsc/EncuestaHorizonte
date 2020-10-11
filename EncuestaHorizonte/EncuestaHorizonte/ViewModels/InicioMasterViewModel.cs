using EncuestaHorizonte.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EncuestaHorizonte.ViewModels
{
    public class InicioMasterViewModel : BaseViewModel
    {
        #region Attributes
        private InicioPageMasterMenuItem itemSelected;
        private ObservableCollection<InicioPageMasterMenuItem> menuItems;
        #endregion

        #region Properties
        public InicioPageMasterMenuItem ItemSelected 
        {
            get { return this.itemSelected; }
            set { SetValue(ref this.itemSelected, value); }
        }

        public ObservableCollection<InicioPageMasterMenuItem> MenuItems
        {
            get { return this.menuItems; }
            set { SetValue(ref this.menuItems, value); }
        }
        #endregion

        public InicioMasterViewModel()
        {
            //Creacion de los objetos visibles en el menu hamburguesa
            this.MenuItems = new ObservableCollection<InicioPageMasterMenuItem>(new[]
            {
                new InicioPageMasterMenuItem { Id = 0, Title = "Sincronizar", Image = "ic_autorenew" },
                new InicioPageMasterMenuItem { Id = 1, Title = "Cerrar Sesión", Image = "ic_exit_to_app" }
            });
        }
    }
}
