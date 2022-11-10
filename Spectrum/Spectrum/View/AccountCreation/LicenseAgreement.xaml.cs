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
    public partial class LicenseAgreement : ContentPage
    {
        public bool IsLicenseAccepted { get; set; }

        public LicenseAgreement()
        {
            InitializeComponent();
            SetPageDesign();
            //NavigationPage.SetHasNavigationBar(this, true);
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
                await Application.Current.MainPage.Navigation.PushAsync(new Welcome());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool IsChecked = false;
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

        private async void AGREE_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (IsChecked)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.PersonalInformation());
                }
                else
                {
                    await DisplayAlert("Accept the User Agreement", "You must accept the User Agreement before proceeding. Thanks", "ok");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private async void Disagree_Clicked(object sender, EventArgs e)
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
        private async void ClickHere_Clicked(object sender, EventArgs e)
        {
            try
            {
                //await DisplayAlert("Test", "Hello", "OK");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}