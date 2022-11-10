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
    public partial class PersonalInformation : ContentPage
    {
        UserSignUpModel objSignUpModel;
        public PersonalInformation()
        {
            InitializeComponent();
            SetPageDesign();
            objSignUpModel = new UserSignUpModel();
        }
        public PersonalInformation(UserSignUpModel userModel)
        {
            InitializeComponent();
            objSignUpModel = userModel;
            txtEmailAddress.Text = objSignUpModel.EmailID;
            txtCompanyName.Text = objSignUpModel.CompanyName;
            txtFName.Text = objSignUpModel.FirstName;
            txtLName.Text = objSignUpModel.LastName;
            SetPageDesign();
            CheckValidation();
        }
        private async void SetPageDesign()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                StkMain.Margin = new Thickness(0, 16, 0, 0);
            }
        }
        private async void CheckValidation()
        {
            if (objSignUpModel.ReturnMessage.ToLower() == "company exists")
            {
                await DisplayAlert("Company Exists!", "The Company Name has already been registered with Spectrum.com by another user. Please try another Company Name", "OK");
                txtCompanyName.Focus();
                txtCompanyName.TextColor = Color.Red;
            }
            if (objSignUpModel.ReturnMessage.ToLower() == "user exists")
            {
                await DisplayAlert("User Exists!", "The Email Address has already been registered with Spectrum.com. Please enter another Email Address", "OK");
                txtEmailAddress.Focus();
                txtEmailAddress.TextColor = Color.Red;
            }
        }
        private async void NEXT_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmailAddress.Text) || string.IsNullOrEmpty(txtCompanyName.Text) || string.IsNullOrEmpty(txtFName.Text) || string.IsNullOrEmpty(txtLName.Text))
                {
                    await DisplayAlert("Fill the Requied information", "All fields are mandatory. Please fill all the fieds in order to move forward", "OK");
                }
                else
                {
                    objSignUpModel.EmailID = txtEmailAddress.Text;
                    objSignUpModel.CompanyName = txtCompanyName.Text;
                    objSignUpModel.FirstName = txtFName.Text;
                    objSignUpModel.LastName = txtLName.Text;
                    objSignUpModel.ReturnMessage = "";
                    objSignUpModel.PlanID = 2;
                    await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.SetAccountPassword(objSignUpModel));
                }

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
                await Application.Current.MainPage.Navigation.PushAsync(new LicenseAgreement());
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
                await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.LicenseAgreement());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void CompanyName_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (objSignUpModel != null && objSignUpModel.ReturnMessage != null && objSignUpModel.ReturnMessage.ToLower() != "success")
            {
                if (objSignUpModel.CompanyName != txtCompanyName.Text)
                {
                    txtCompanyName.TextColor = Color.Black;
                }
            }
        }

        private async void EmailAddress_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (objSignUpModel != null && objSignUpModel.ReturnMessage != null && objSignUpModel.ReturnMessage.ToLower() != "success")
            {
                if (objSignUpModel.EmailID != txtEmailAddress.Text)
                {
                    txtEmailAddress.TextColor = Color.Black;
                }
            }
        }
    }
}