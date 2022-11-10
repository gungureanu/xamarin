using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Spectrum.View.Updation
{
    public partial class Confirmation : ContentPage
    {
        public Confirmation()
        {
            InitializeComponent();
            imgConfirmation.WidthRequest = App.Current.MainPage.Width;
            imgConfirmation.HeightRequest = App.Current.MainPage.Height / 5;
        }
    }
}
