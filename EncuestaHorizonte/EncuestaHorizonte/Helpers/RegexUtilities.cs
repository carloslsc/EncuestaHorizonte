using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EncuestaHorizonte.Helpers
{
    public static class RegexUtilities
    {
        public static bool ComprobarFormatoEmail(string email)
        {
            string sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, sFormato))
            {
                if (Regex.Replace(email, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
