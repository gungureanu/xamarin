using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectrum.Model;
using Spectrum.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spectrum.View.ForgotPassword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgetPasswordEmail : ContentPage
    {
        ForgetPasswordService _forgetPasswordService = new ForgetPasswordService();
        public ForgetPasswordEmail()
        {
            InitializeComponent();
            SetPageDesign();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private async void SetPageDesign()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                StkMain.Margin = new Thickness(0, 16, 0, 0);
            }
        }
        private async void SUBMIT_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(EntryEmailAddress.Text))
                {
                    await DisplayAlert("Required", "Please enter your email address which is associated with your Spectrum account and try again. thanks", "Ok");
                    return;
                }
                else
                {
                    frmForgetPassword.IsVisible = false;
                    Indicator.IsVisible = true;
                    var obj = await _forgetPasswordService.ResetUserPasswordAsync(EntryEmailAddress.Text);
                    if (!string.IsNullOrEmpty(obj.ReturnMessage))
                    {
                        if (obj.ReturnMessage.ToLower() == "sucess")
                        {
                            await Application.Current.MainPage.Navigation.PushAsync(new View.ForgotPassword.ForgotPasswordThankYou());
                        }
                        else
                        {
                            frmForgetPassword.IsVisible = true;
                            Indicator.IsVisible = false;
                            await DisplayAlert("Invalid Email Address", "Sorry, there is not any matching account associated with the email address you have provided. Please verify the email address and try agian. Thanks", "Ok");
                            return;
                        }
                    }
                    else
                    {
                        frmForgetPassword.IsVisible = true;
                        Indicator.IsVisible = false;
                        await DisplayAlert("Invalid Email Address", "Sorry, there is not any matching account associated with the email address you have provided. Please verify the email address and try agian. Thanks", "Ok");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                frmForgetPassword.IsVisible = true;
                Indicator.IsVisible = false;
                await DisplayAlert("Connection Error", "There is some issue in processing the request, please contact administrator.", "Ok");
                //throw ex;
            }
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Login());
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
                await Application.Current.MainPage.Navigation.PushAsync(new Login());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}