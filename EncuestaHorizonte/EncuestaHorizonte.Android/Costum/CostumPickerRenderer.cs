using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using EncuestaHorizonte.Costum;
using EncuestaHorizonte.Droid.Renderer;

using PickerRenderer = Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer;

[assembly: ExportRenderer(typeof(PickerRender), typeof(CustomPickerRenderer))]
namespace EncuestaHorizonte.Droid.Renderer
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Xamarin.Forms.TextAlignment align = ((PickerRender)Element).HorizontalTextAlignment;

                switch (align)
                {
                    case Xamarin.Forms.TextAlignment.Center:
                        Control.Gravity = GravityFlags.CenterHorizontal;
                        break;
                    case Xamarin.Forms.TextAlignment.Start:
                        Control.Gravity = GravityFlags.Left;
                        break;
                    case Xamarin.Forms.TextAlignment.End:
                        Control.Gravity = GravityFlags.Right;
                        break;
                }
            }
        }
    }
}