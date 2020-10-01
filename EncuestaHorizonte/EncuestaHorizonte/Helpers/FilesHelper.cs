using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EncuestaHorizonte.Helpers
{
    public class FilesHelper
    {
        public static byte[] ReadFully(Stream input)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
