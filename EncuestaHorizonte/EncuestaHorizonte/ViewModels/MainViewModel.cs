namespace EncuestaHorizonte.ViewModels
{
    //using EncuestaHorizonte.;
    using System.Collections.Generic;
    //using Bananera.Models;

    public class MainViewModel
    {
        /*
        #region Properties
        public string Area { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }

        public string Servidor { get; set; }

        public Empleado TheEmp { get; set; }
        #endregion
        */


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

        /*public ConfigurationViewModel Configuration
        {
            get;
            set;
        }

        public EmployeeViewModel Employee
        {
            get;
            set;
        }

        public EmployeeDataViewModel EmployeeData
        {
            get;
            set;
        }

        public EmployeeEditViewModel EmployeeEdit
        {
            get;
            set;
        }

        public EmployeeLaborViewModel EmployeeLabor
        {
            get;
            set;
        }*/
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.Inicio = new InicioViewModel();
            /*this.Configuration = new ConfigurationViewModel();
            this.Employee = new EmployeeViewModel();
            this.EmployeeData = new EmployeeDataViewModel();
            this.EmployeeEdit = new EmployeeEditViewModel();
            this.EmployeeLabor = new EmployeeLaborViewModel();*/
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