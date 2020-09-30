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
        const string servidor = "Servidor";
        const string adminU = "AdminU";
        const string adminP = "AdminP";
        //const string hora = "Hora";
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

        public static string Servidor
        {
            get
            {
                return AppSettings.GetValueOrDefault(servidor, stringDefault);
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

    }
}
