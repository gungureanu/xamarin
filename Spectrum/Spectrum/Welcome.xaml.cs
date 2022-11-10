using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spectrum
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Welcome : ContentPage
    {
        public Welcome()
        {
            InitializeComponent();
            //var a = Application.Current.MainPage.Width;
            //var b = Application.Current.MainPage.Height;
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.InsertPageBefore(new Login(), this);
                await Application.Current.MainPage.Navigation.PopAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async void SignUp_Clicked(object sender, EventArgs e)
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

    }
}