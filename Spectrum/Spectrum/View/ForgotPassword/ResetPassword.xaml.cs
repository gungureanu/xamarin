using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spectrum.View.ChangePassword;

namespace Spectrum.View.ForgotPassword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPassword : ContentPage
    {
        public ResetPassword()
        {
            InitializeComponent();
            SetPageDesign();
        }
        private async void SetPageDesign()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                StkMain.Margin = new Thickness(0, 16, 0, 0);
            }
        }
        private async void FINISH_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.ForgotPassword.PasswordResetSuccess());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Show_Clicked(object sender, EventArgs e)
        {
            try
            {
                //lblshowHidePass
                if (EntryPassword.IsPassword)
                {
                    EntryPassword.IsPassword = false;
                    EntryConfirmPassword.IsPassword = false;
                    lblshowHidePass.Text = "HIDE";
                }
                else
                {
                    EntryPassword.IsPassword = true;
                    EntryConfirmPassword.IsPassword = true;
                    lblshowHidePass.Text = "SHOW";
                }
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
                await Application.Current.MainPage.Navigation.PushAsync(new View.ForgotPassword.ForgotPasswordThankYou());
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
                await Application.Current.MainPage.Navigation.PushAsync(new ForgotPasswordThankYou());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}