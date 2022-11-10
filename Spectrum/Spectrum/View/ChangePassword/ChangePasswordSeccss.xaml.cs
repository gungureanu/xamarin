using System;
using System.Collections.Generic;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Xamarin.Forms;

namespace Spectrum.View.ChangePassword
{
    public partial class ChangePasswordSeccss : ContentPage
    {
        public UserProfileMob _objProfile { get; set; }
        List<ModuleMainPanel> _lstmodules { get; set; }
        public ChangePasswordSeccss()
        {
            InitializeComponent();
            SetPageDesign();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }

        public ChangePasswordSeccss(UserProfileMob objUserProfile, List<ModuleMainPanel> lstModules)
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

        private async void CONTINUE_Clicked(object sender, EventArgs e)
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
