using System;
using Xamarin.Forms;

namespace Spectrum.View.MasterDetailPages
{
    public class MasterPageItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public int ModuleID { get; set; }

        public ContentPage TargetType { get; set; }
    }
}
