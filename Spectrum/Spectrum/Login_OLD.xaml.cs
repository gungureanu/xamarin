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
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Spectrum.Model.ModelDataTypes;

namespace Spectrum.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login_OLD : ContentPage
    {

        public bool IsChecked = false;
        public bool IsRememberMe { get; set; }
        LoginService _loginService = new LoginService();
        public Login_OLD()
        {
            InitializeComponent();
            frmLogin.WidthRequest = 210.0 * (double)Application.Current.MainPage.Width / 720.0;
            IsChecked = true;
        }
        public Login_OLD(string EmailAddress)
        {
            InitializeComponent();
            frmLogin.WidthRequest = 210.0 * (double)Application.Current.MainPage.Width / 720.0;
            txtEmailAddress.Text = EmailAddress;
            IsChecked = true;
        }
        private async void Login_Clicked(object sender, EventArgs e)
        {
            try
            {
                frmLogin.IsVisible = false;
                ActiviltyLogin.IsVisible = true;
                ActiviltyLogin.IsRunning = true;

                if (string.IsNullOrEmpty(txtEmailAddress.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    await DisplayAlert("Email Adress and Password is required", "Please enter the Email address and Password in order to login the Specturm app", "OK");
                    ActiviltyLogin.IsVisible = false;
                    ActiviltyLogin.IsRunning = false;
                    frmLogin.IsVisible = true;
                    return;
                }
                else
                {
                    Model.UserModel objuserModel = new Model.UserModel();
                    objuserModel.EmailAddress = txtEmailAddress.Text.Trim();
                    objuserModel.Password = txtPassword.Text.ToString();
                    objuserModel.UserIPAddress = DependencyService.Get<IIPAddressManager>().GetIPAddress();
                    UserProfileMob objProfile = new UserProfileMob();
                    string baseURL = APIConfig.Get_API_BaseURL() + "api/AppLogin";
                    var json = JsonConvert.SerializeObject(objuserModel);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpClient _client = new HttpClient();
                    var task = await _client.PostAsync(baseURL, content);
                    if (task.IsSuccessStatusCode)
                    {
                        var responsecontent = await task.Content.ReadAsStringAsync();
                        objProfile = JsonConvert.DeserializeObject<UserProfileMob>(responsecontent);
                    }
                    if (objProfile != null)
                    {
                        if (objProfile.UserExists.ToLower() == "trialrunning" || objProfile.UserExists.ToLower() == "success")
                        {
                            objProfile.EmailAddress = txtEmailAddress.Text.ToLower();
                            Application.Current.Properties["WebToken"] = Convert.ToString(objProfile.UserWebToken);
                            Application.Current.Properties["UserEmail"] = Convert.ToString(objProfile.EmailAddress);
                            Application.Current.Properties["UserName"] = Convert.ToString(objProfile.UserName);
                            Application.Current.Properties["AccountID"] = Convert.ToString(objProfile.AccountID);
                            Application.Current.Properties["UserID"] = Convert.ToString(objProfile.UserID);
                            Application.Current.Properties["CompanyID"] = Convert.ToString(objProfile.PrimaryCompanyID);
                            Application.Current.Properties["LanguageID"] = Convert.ToString(6);
                            if (IsChecked)
                            {
                                Application.Current.Properties["Password"] = Convert.ToString(txtPassword.Text);
                            }

                            LeftPanelService objLeftservice = new LeftPanelService();
                            List<ModuleMainPanel> lstModules = await objLeftservice.GetModuleNamesAsync(objProfile.AccountID.ToString(), objProfile.PlanID, objProfile.RoleIDList, objProfile.IsSpecialLogin, objProfile.IsCommandAdmin, 3, objProfile.UserID.ToString(), objProfile.WorkspaceID);

                            Navigation.InsertPageBefore(new Spectrum.View.MasterPages.HomeMasterDetailPage(objProfile, lstModules, "Project Tasks", null), this);
                            await Application.Current.MainPage.Navigation.PopAsync().ConfigureAwait(false);
                            //await Application.Current.MainPage.Navigation.PushAsync(new View.MasterPages.HomeMasterDetailPage());
                        }
                        else
                        {
                            if (objProfile.UserExists.ToLower() == "paswordnotmatched")
                            {
                                await DisplayAlert("Invalid Credentials", "Incorrect email address and/or password. Please verify your information and then try again", "OK");
                            }
                            else if (objProfile.UserExists.ToLower() == "notverified")
                            {
                                await DisplayAlert("Success", "Your Specturm.com account is not yet verified. Please check your email(inbox/junk folder) and verify your account", "OK");
                            }
                            else if (objProfile.UserExists.ToLower().Replace(" ", "") == "notexists")
                            {
                                await DisplayAlert(objProfile.CustomMessage.CaptionText, objProfile.CustomMessage.Description, "OK");
                            }
                            ActiviltyLogin.IsVisible = false;
                            ActiviltyLogin.IsRunning = false;
                            frmLogin.IsVisible = true;
                        }
                    }
                    else
                    {
                        ActiviltyLogin.IsVisible = false;
                        ActiviltyLogin.IsRunning = false;
                        frmLogin.IsVisible = true;
                        await DisplayAlert("Invalid Credentials", "Incorrect email address and/or password. Please verify your information and then try again", "OK");
                    }

                }

                //await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.LicenseAgreement());
            }
            catch (Exception ex)
            {
                ActiviltyLogin.IsVisible = false;
                ActiviltyLogin.IsRunning = false;
                frmLogin.IsVisible = true;
                await DisplayAlert("OOps!", "There is some issue with the connectivity, Please try again later", "OK");
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
                    lblshowHidePass.Text = "HIDE";
                }
                else
                {
                    txtPassword.IsPassword = true;
                    lblshowHidePass.Text = "SHOW";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ImgUncheckedAccess_Clicked(object sender, EventArgs e)
        {

            ImgUncheckedAccess.Source = IsChecked ? "unchecked_icon.png" : "checked_icon.png";
            IsChecked = !IsChecked;


            //var imageSource = (Image)sender;
            //var selectedImage = imageSource.Source as FileImageSource;
            //if (selectedImage.File == "checked_icon.png")
            //{
            //    ImgUncheckedAccess.Source = "unchecked_icon.png";
            //}
            //else
            //{
            //    ImgUncheckedAccess.Source = "checked_icon.png";
            //}
        }
        private async void ForgotPassword_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.ForgotPassword.ForgetPasswordEmail());
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
                await Application.Current.MainPage.Navigation.PushAsync(new Welcome());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void CreateAccount_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.LicenseAgreement());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void RememberMe_Tapped(System.Object sender, System.EventArgs e)
        {
            var stk = sender as StackLayout;
            if (stk != null)
            {
                if (IsChecked)
                {
                    ImgUncheckedAccess.Source = "unchecked_icon.png";
                    IsChecked = false;
                }
                else
                {
                    ImgUncheckedAccess.Source = "checked_icon.png";
                    IsChecked = true;
                }
            }
        }
    }
}