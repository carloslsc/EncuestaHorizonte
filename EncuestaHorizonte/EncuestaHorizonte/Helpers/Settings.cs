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
        const string idArea = "idArea";
        const string nombre = "Nombre";
        const string idUsuario = "idUsuario";
        const string servidor = "horizonte2021.com.mx";
        const string adminU = "AdminU";
        const string adminP = "AdminP";
        const string id = "0";
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

        public static string IdArea
        {
            get
            {
                return AppSettings.GetValueOrDefault(idArea, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(idArea, value);
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
    }
}
