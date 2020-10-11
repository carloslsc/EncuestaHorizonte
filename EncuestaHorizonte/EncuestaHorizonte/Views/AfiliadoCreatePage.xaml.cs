using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EncuestaHorizonte.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AfiliadoCreatePage : ContentPage
    {
        public AfiliadoCreatePage()
        {
            InitializeComponent();
            Image.Source = "no_image";
            CredencialFrontal.Source = "no_image";
            CredencialPosterior.Source = "no_image";
        }

    }
}