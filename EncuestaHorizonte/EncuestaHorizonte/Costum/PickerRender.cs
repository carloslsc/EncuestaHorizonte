using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EncuestaHorizonte.Costum
{
    public class PickerRender : Picker
    {
        public PickerRender() : base()
        {
        }
        TextAlignment _textAlignment = TextAlignment.Start;  
                                                             
        public TextAlignment HorizontalTextAlignment
        {
            get
            {
                return _textAlignment;
            }
            set
            {
                _textAlignment = value;
            }
        }
    }
}
