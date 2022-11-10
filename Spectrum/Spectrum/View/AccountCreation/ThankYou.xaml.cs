using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectrum.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spectrum.View.AccountCreation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThankYou : ContentPage
    {
        public UserSignUpModel _objSignupModel { get; set; }
        public ThankYou()
        {
            InitializeComponent();
            SetPageDesign();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            imgEnvelope.WidthRequest = App.Current.MainPage.Width;
            imgEnvelope.HeightRequest = App.Current.MainPage.Height / 5 - 30;
        }
        public ThankYou(UserSignUpModel objUserModel)
        {
            InitializeComponent();
            SetPageDesign();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            imgEnvelope.WidthRequest = App.Current.MainPage.Width;
            imgEnvelope.HeightRequest = App.Current.MainPage.Height / 5 - 30;
            _objSignupModel = objUserModel;
        }
        private async void SetPageDesign()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                StkMain.Margin = new Thickness(0, 16, 0, 0);
            }
        }
        private async void NEXT_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Login(_objSignupModel.EmailID));
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
                await Application.Current.MainPage.Navigation.PushAsync(new PersonalInformation());
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
                await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.PersonalInformation());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}