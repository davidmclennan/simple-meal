using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SimpleMeal.Effects
{
    public class NativePaddingEffect : RoutingEffect
    {
        public Thickness NativePadding { get; set; }

        public NativePaddingEffect() : base("SimpleMeal.NativePaddingEffect") { }
    }
}
