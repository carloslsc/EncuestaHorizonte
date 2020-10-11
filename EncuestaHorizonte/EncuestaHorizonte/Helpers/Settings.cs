using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace EncuestaHorizonte.Helpers
{
    public static class Settings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        const string area = "Area";
        const string usuario = "Usuario";
        const string password = "Password";
        const string nombre = "Nombre";
        const string idUsuario = "0";
        const string servidor = "horizonte2021.com.mx";
        const string adminU = "AdminU";
        const string adminP = "AdminP";
        const string id = "0";
        const string exitosos = "Exitosos";
        static readonly string stringDefault = string.Empty;

        public static string Area
        {
            get
            {
                return AppSettings.GetValueOrDefault(area, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(area, value);
            }
        }

        public static string Usuario
        {
            get
            {
                return AppSettings.GetValueOrDefault(usuario, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(usuario, value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault(password, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(password, value);
            }
        }

        public static string Nombre
        {
            get
            {
                return AppSettings.GetValueOrDefault(nombre, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nombre, value);
            }
        }

        public static string IdUsuario
        {
            get
            {
                return AppSettings.GetValueOrDefault(idUsuario, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(idUsuario, value);
            }
        }

        public static string Servidor
        {
            get
            {
                return AppSettings.GetValueOrDefault(servidor, "horizonte2021.com.mx");
            }
            set
            {
                AppSettings.AddOrUpdateValue(servidor, value);
            }
        }
        public static string AdminU
        {
            get
            {
                return AppSettings.GetValueOrDefault(adminU, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(adminU, value);
            }
        }

        public static string AdminP
        {
            get
            {
                return AppSettings.GetValueOrDefault(adminP, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(adminP, value);
            }
        }

        public static string Id
        {
            get
            {
                return AppSettings.GetValueOrDefault(id, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(id, value);
            }
        }

        public static string Exitosos
        {
            get
            {
                return AppSettings.GetValueOrDefault(exitosos, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(exitosos, value);
            }
        }
    }
}
