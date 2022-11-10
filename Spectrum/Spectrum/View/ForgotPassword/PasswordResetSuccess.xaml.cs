using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spectrum.View.ForgotPassword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordResetSuccess : ContentPage
    {
        public PasswordResetSuccess()
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
        private async void CONTINUE_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.ChangePassword.ChangePassword());
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
                await Application.Current.MainPage.Navigation.PushAsync(new View.ForgotPassword.ResetPassword());
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
                await Application.Current.MainPage.Navigation.PushAsync(new View.ForgotPassword.ResetPassword());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}