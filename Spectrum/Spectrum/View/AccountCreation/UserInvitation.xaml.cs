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
    public partial class UserInvitation : ContentPage
    {

        private bool StandardAccess;
        private bool GuestAccess;
        private bool AdministrativeAccess;

        public UserInvitation()
        {
            InitializeComponent();
            SetPageDesign();
            StandardAccess = false;
            GuestAccess = false;
            AdministrativeAccess = false;

        }
        private async void SetPageDesign()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                StkMain.Margin = new Thickness(0, 16, 0, 0);
            }
        }

        public void ImgStandardAccess_Clicked(object sender, EventArgs args)
        {
            if (!StandardAccess)
            {
                StandardAccess = true;
                ImgStandardAccess.Source = "radio_btn_active.png";
            }
            GuestAccess = false;
            AdministrativeAccess = false;
            ImgGuestAccess.Source = "radio_btn.png";
            ImgAdministrativeAccess.Source = "radio_btn.png";
        }


        public void ImgGuestAccess_Clicked(object sender, EventArgs args)
        {
            if (!GuestAccess)
            {
                GuestAccess = true;
                ImgGuestAccess.Source = "radio_btn_active.png";
            }
            StandardAccess = false;
            AdministrativeAccess = false;
            ImgStandardAccess.Source = "radio_btn.png";
            ImgAdministrativeAccess.Source = "radio_btn.png";
        }


        public void ImgAdministrativeAccess_Clicked(object sender, EventArgs args)
        {
            if (!AdministrativeAccess)
            {
                AdministrativeAccess = true;
                ImgAdministrativeAccess.Source = "radio_btn_active.png";
            }
            StandardAccess = false;
            GuestAccess = false;
            ImgStandardAccess.Source = "radio_btn.png";
            ImgGuestAccess.Source = "radio_btn.png";
        }

        private async void NEXT_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.AccountConfirmation());
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
                await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.TeamMembers());
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
                await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.TeamMembers());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
