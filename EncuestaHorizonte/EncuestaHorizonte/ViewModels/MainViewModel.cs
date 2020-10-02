namespace EncuestaHorizonte.ViewModels
{
    using EncuestaHorizonte.Models;
    //using EncuestaHorizonte.;
    using System.Collections.Generic;
    //using Bananera.Models;

    public class MainViewModel
    {
        
        #region Properties
        public string Area { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }

        public string Servidor { get; set; }

        public Afiliado TheAfi { get; set; }
        #endregion
        


        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }

        public InicioViewModel Inicio
        {
            get;
            set;
        }

        public InicioMasterViewModel InicioMaster
        {
            get;
            set;
        }

        public ConfigurationViewModel Configuration
        {
            get;
            set;
        }

        /*public EmployeeViewModel Employee
        {
            get;
            set;
        }

        */
        public AfiliadoCreateViewModel AfiliadoCreate
        {
            get;
            set;
        }
        
        public AfiliadoEditViewModel AfiliadoEdit
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.Inicio = new InicioViewModel();
            this.Configuration = new ConfigurationViewModel();
            this.InicioMaster = new InicioMasterViewModel();
            //this.Employee = new EmployeeViewModel();
            this.AfiliadoCreate = new AfiliadoCreateViewModel();
            this.AfiliadoEdit = new AfiliadoEditViewModel();
            //this.EmployeeLabor = new EmployeeLaborViewModel();*/
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}