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
    public partial class AboutBusiness : ContentPage
    {
        public AboutBusiness()
        {
            InitializeComponent();
            SetPageDesign();
            BindDropDownList();
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
                await Application.Current.MainPage.Navigation.PushAsync(new ThankYou());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void NEXT_Clicked(object sender, EventArgs e)
        {
            try
            {
                /// await DisplayAlert("Saved", "Business Information saved", "OK");
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

                await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.ThankYou());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public class DrowpDownList
        {
            public Int32 ID { get; set; }
            public string Text { get; set; }
        }
        public void BindDropDownList()
        {
            List<DrowpDownList> lstCompanyType = new List<DrowpDownList>();
            lstCompanyType.Add(new DrowpDownList { ID = 1, Text = "Software" });
            lstCompanyType.Add(new DrowpDownList { ID = 2, Text = "Civil" });
            lstCompanyType.Add(new DrowpDownList { ID = 3, Text = "Other" });
            ddlCompanyType.ItemsSource = lstCompanyType;
            ddlCompanyType.BindingContext = lstCompanyType;


            List<DrowpDownList> lstIndustry = new List<DrowpDownList>();
            lstIndustry.Add(new DrowpDownList { ID = 1, Text = "Information Technology" });
            lstIndustry.Add(new DrowpDownList { ID = 2, Text = "Constructions" });
            lstIndustry.Add(new DrowpDownList { ID = 3, Text = "Other" });
            ddlIndustry.ItemsSource = lstIndustry;
            ddlIndustry.BindingContext = lstIndustry;


            List<DrowpDownList> lstEmployee = new List<DrowpDownList>();
            lstEmployee.Add(new DrowpDownList { ID = 1, Text = "Yes" });
            lstEmployee.Add(new DrowpDownList { ID = 2, Text = "No" });
            ddlEmployee.ItemsSource = lstEmployee;
            ddlEmployee.BindingContext = lstEmployee;
        }
    }
}