using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spectrum.View.AccountCreation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountConfirmation : ContentPage
    {
        public AccountConfirmation()
        {
            InitializeComponent();
            SetPageDesign();
            imgConfirmation.WidthRequest = App.Current.MainPage.Width;
            imgConfirmation.HeightRequest = App.Current.MainPage.Height / 5 - 30;
        }
        private async void SetPageDesign()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                StkMain.Margin = new Thickness(0, 16, 0, 0);
            }
        }
        private async void Back_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new UserInvitation());
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
                await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.UserInvitation());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void Finish_Clicked(object sender, EventArgs e)
        {
            try
            {
                await DisplayAlert("Success", " Spectrum apps Installation Seccessfully", "OK");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}