using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Spectrum.View.ForgotPassword
{
    public partial class ForgotPasswordThankYou : ContentPage
    {
        public ForgotPasswordThankYou()
        {
            InitializeComponent();
            SetPageDesign();
            imgThankYou.WidthRequest = App.Current.MainPage.Width;
            imgThankYou.HeightRequest = App.Current.MainPage.Height / 5;
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }
        private async void SetPageDesign()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                StkMain.Margin = new Thickness(0, 16, 0, 0);
            }
        }
        private async void NEXT_Clicked(object sender, EventArgs e)
        {
            try
            {
                //await Application.Current.MainPage.Navigation.PushAsync(new View.ForgotPassword.ResetPassword());
                await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.Login());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            try
            {
                //await Application.Current.MainPage.Navigation.PushAsync(new ForgetPasswordEmail());
                await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.Login());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            try
            {
                //await Application.Current.MainPage.Navigation.PushAsync(new View.ForgotPassword.ForgetPasswordEmail());
                await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.Login());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
