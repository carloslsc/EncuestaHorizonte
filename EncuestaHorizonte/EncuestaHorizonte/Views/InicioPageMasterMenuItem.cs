using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestaHorizonte.Views
{

    public class InicioPageMasterMenuItem
    {
        public InicioPageMasterMenuItem()
        {
            TargetType = typeof(InicioPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public Type TargetType { get; set; }
    }
}