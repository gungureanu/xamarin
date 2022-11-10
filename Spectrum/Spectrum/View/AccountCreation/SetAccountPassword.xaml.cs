using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectrum.Model;
using Spectrum.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spectrum.APISettings;
using Newtonsoft.Json;
using System.Net.Http;
using Acr.UserDialogs;

namespace Spectrum.View.AccountCreation
{
    public partial class SetAccountPassword : ContentPage
    {
        public UserSignUpModel _objUserModel { get; set; }
        public SetAccountPassword()
        {
            InitializeComponent();
            SetPageDesign();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public SetAccountPassword(UserSignUpModel objUserModel)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            _objUserModel = objUserModel;
            SetPageDesign();
            if (!string.IsNullOrEmpty(_objUserModel.Password))
            {
                PerformSignUp();
            }
        }
        private async void SetPageDesign()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                StkMain.Margin = new Thickness(0, 16, 0, 0);
            }
        }
        private async void PerformSignUp()
        {
            try
            {
                //using (UserDialogs.Instance.Loading("Signing Up..."))
                //{
                UserAccountProfile objProfile = new UserAccountProfile();

                string baseURL = APIConfig.Get_API_BaseURL() + "api/UserSignUp";
                var json = JsonConvert.SerializeObject(_objUserModel);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient _client = new HttpClient();
                var task = await _client.PostAsync(baseURL, content);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    objProfile = JsonConvert.DeserializeObject<UserAccountProfile>(responsecontent);
                }
                if (objProfile != null)
                {
                    if (objProfile.ReturnMessage.ToLower() == "success")
                    {
                        ActiviltyLogin.IsVisible = false;
                        ActiviltyLogin.IsRunning = false;
                        frmSubmitSignup.IsVisible = true;
                        await Application.Current.MainPage.Navigation.PushAsync(new ThankYou(_objUserModel));
                    }
                    else
                    {
                        ActiviltyLogin.IsVisible = false;
                        ActiviltyLogin.IsRunning = false;
                        frmSubmitSignup.IsVisible = true;
                        _objUserModel.ReturnMessage = objProfile.ReturnMessage;
                        await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.PersonalInformation(_objUserModel));
                    }
                }
                else
                {
                    ActiviltyLogin.IsVisible = false;
                    ActiviltyLogin.IsRunning = false;
                    frmSubmitSignup.IsVisible = true;
                    await DisplayAlert(objProfile.ReturnMessage, objProfile.ReturnMessage, "OK");
                }
                //}
            }
            catch (Exception ex)
            {
                ActiviltyLogin.IsVisible = false;
                ActiviltyLogin.IsRunning = false;
                frmSubmitSignup.IsVisible = true;
            }
        }
        private async void SUBMIT_Clicked(object sender, EventArgs e)
        {
            try
            {
                //using (UserDialogs.Instance.Loading("Signing Up..."))
                //{
                frmSubmitSignup.IsVisible = false;
                ActiviltyLogin.IsVisible = true;
                ActiviltyLogin.IsRunning = true;
                if (!string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtConfirmPassword.Text))
                {
                    if (txtPassword.Text == txtConfirmPassword.Text)
                    {
                        _objUserModel.Password = txtPassword.Text;
                        _objUserModel.UserIPAddress = DependencyService.Get<IIPAddressManager>().GetIPAddress();
                        PerformSignUp();
                    }
                    else
                    {
                        await DisplayAlert("Password is required", "Password and Confirm Password must match in order to move forward. thanks", "OK");
                        ActiviltyLogin.IsVisible = false;
                        ActiviltyLogin.IsRunning = false;
                        frmSubmitSignup.IsVisible = true;
                    }
                }
                else
                {
                    await DisplayAlert("Password is required", "Password is required in order to move forward. thanks", "OK");
                    ActiviltyLogin.IsVisible = false;
                    ActiviltyLogin.IsRunning = false;
                    frmSubmitSignup.IsVisible = true;
                }
                // }
            }
            catch (Exception ex)
            {
                ActiviltyLogin.IsVisible = false;
                ActiviltyLogin.IsRunning = false;
                frmSubmitSignup.IsVisible = true;
                throw ex;
            }
        }
        private void Show_Clicked(object sender, EventArgs e)
        {
            try
            {
                //lblshowHidePass
                if (txtPassword.IsPassword)
                {
                    txtPassword.IsPassword = false;
                    txtConfirmPassword.IsPassword = false;
                    lblshowHidePass.Text = "HIDE";
                }
                else
                {
                    txtPassword.IsPassword = true;
                    txtConfirmPassword.IsPassword = true;
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
                await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.PersonalInformation(_objUserModel));
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
                await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.PersonalInformation(_objUserModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
