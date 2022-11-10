using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spectrum.View.ForgotPassword;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Spectrum.Service;

namespace Spectrum.View.ChangePassword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePassword : ContentPage
    {
        public UserProfileMob _objProfile { get; set; }
        List<ModuleMainPanel> _lstmodules { get; set; }
        public string _PageTitle { get; set; }
        ContentPage _prevPage { get; set; }
        public ResetPasswordService _resetPasswordService = new ResetPasswordService();
        public ChangePassword()
        {
            InitializeComponent();
            SetPageDesign();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }
        public ChangePassword(UserProfileMob objUserProfile, List<ModuleMainPanel> lstModules)
        {
            InitializeComponent();
            SetPageDesign();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            _objProfile = objUserProfile;
            _lstmodules = lstModules;
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
                if (string.IsNullOrEmpty(EntryPassword.Text) || string.IsNullOrEmpty(EntryConfirmPassword.Text))
                {
                    await DisplayAlert("Required", "Please enter Password and Corfirm password field to proceed. thanks", "OK");
                    return;
                }
                else
                {
                    if (EntryPassword.Text != EntryConfirmPassword.Text)
                    {
                        await DisplayAlert("Required", "Password and confirm password must match. thanks", "OK");
                        return;
                    }
                    else
                    {
                        frmSubmit.IsVisible = false;
                        Indicator.IsVisible = true;
                        PasswordManagerModel model = new PasswordManagerModel
                        {
                            CompanyID = _objProfile.CompanyID.ToString(),
                            AccountID = _objProfile.AccountID.ToString(),
                            UserID = _objProfile.UserID.ToString(),
                            Password = EntryPassword.Text

                        };
                        string retval = await _resetPasswordService.ResetUserPasswordAsync(model);
                        if (retval.ToLower().Contains("success"))
                        {
                            await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstmodules, "Projects", new Spectrum.View.ChangePassword.ChangePasswordSeccss(_objProfile, _lstmodules)));
                        }
                        else
                        {
                            frmSubmit.IsVisible = true;
                            Indicator.IsVisible = false;
                            await DisplayAlert("Oops", "Something went wrong while resetting the pasword. Please try again later", "OK");
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                frmSubmit.IsVisible = true;
                Indicator.IsVisible = false;
                await DisplayAlert("Oops", "Something went wrong while resetting the pasword. Please try again later", "OK");
                //   throw ex;
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
                await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstmodules, "Projects", new Spectrum.View.MasterPages.WorkSpaceSelection(_objProfile, _lstmodules, 3)));
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
                await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstmodules, "Projects", new Spectrum.View.MasterPages.WorkSpaceSelection(_objProfile, _lstmodules, 3)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}