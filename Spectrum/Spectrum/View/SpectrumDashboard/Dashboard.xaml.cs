using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Spectrum.Model;

namespace Spectrum.View.SpectrumDashboard
{
    public partial class Dashboard : TabbedPage
    {

        public Dashboard()
        {

            InitializeComponent();


            //BarBackgroundColor = Color.FromHex("#D1DFF8");
            //BarBackgroundColor = Color.Red;
            // BarTextColor = Color.Yellow;
            //BarTextColor = Color.FromHex("#228CFA");
            // BarItemColor = Color.Green;
            //BarSelectedItemColor = Color.Red;
        }
        //private async void Dashboard_Clicked(object sender, EventArgs e)
        //{
        //    if (!DashboardAccess)
        //    {
        //        DashboardAccess = true;
        //        ImgDashboardAccess.Source = "dashboard_active.png";
        //    }
        //    AppsAccess = false;
        //    ReportsAccess = false;
        //    HelpAccess = false;
        //    SettingsAccess = false;
        //    ImgAppsAccess.Source = "apps.png";
        //    ImgReportsAccess.Source = "reports.png";
        //    ImgHelpAccess.Source = "help.png";
        //    ImgSettingsAccess.Source = "setting.png";

        //    //try
        //    //{
        //    //  await Application.Current.MainPage.Navigation.pu(new AppsPage());
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //}


        //private async void Apps_Clicked(object sender, EventArgs e)
        //{
        //    if (!AppsAccess)
        //    {
        //        AppsAccess = true;
        //        ImgAppsAccess.Source = "apps_active.png";
        //    }

        //    ReportsAccess = false;
        //    HelpAccess = false;
        //    SettingsAccess = false;
        //    DashboardAccess = false;
        //    ImgDashboardAccess.Source = "dashboard.png";

        //    ImgReportsAccess.Source = "reports.png";
        //    ImgHelpAccess.Source = "help.png";
        //    ImgSettingsAccess.Source = "setting.png";
        //    //try
        //    //{
        //    //    await Application.Current.MainPage.Navigation.PushAsync(new AppsPage());
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //}
        //private async void Reports_Clicked(object sender, EventArgs e)
        //{
        //    if (!ReportsAccess)
        //    {
        //        ReportsAccess = true;
        //        ImgReportsAccess.Source = "reports_active.png";
        //    }
        //    HelpAccess = false;
        //    SettingsAccess = false;
        //    DashboardAccess = false;
        //    AppsAccess = false;
        //    ImgDashboardAccess.Source = "dashboard.png";
        //    ImgAppsAccess.Source = "apps.png";

        //    ImgHelpAccess.Source = "help.png";
        //    ImgSettingsAccess.Source = "setting.png";
        //    //try
        //    //{
        //    //    await Application.Current.MainPage.Navigation.PushAsync(new ReportsPage());
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //}
        //private async void Help_Clicked(object sender, EventArgs e)
        //{
        //    if (!HelpAccess)
        //    {
        //        HelpAccess = true;
        //        ImgHelpAccess.Source = "help_active.png";
        //    }

        //    SettingsAccess = false;
        //    DashboardAccess = false;
        //    AppsAccess = false;
        //    ReportsAccess = false;
        //    ImgDashboardAccess.Source = "dashboard.png";
        //    ImgAppsAccess.Source = "apps.png";
        //    ImgReportsAccess.Source = "reports.png";
        //    ImgSettingsAccess.Source = "setting.png";

        //    //try
        //    //{
        //    //    await Application.Current.MainPage.Navigation.PushAsync(new HelpPage());
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //}
        //private async void Settings_Clicked(object sender, EventArgs e)
        //{
        //    if (!SettingsAccess)
        //    {
        //        SettingsAccess = true;
        //        ImgSettingsAccess.Source = "settings_active.png";
        //    }


        //    DashboardAccess = false;
        //    AppsAccess = false;
        //    ReportsAccess = false;
        //    HelpAccess = false;
        //    ImgDashboardAccess.Source = "dashboard.png";
        //    ImgAppsAccess.Source = "apps.png";
        //    ImgReportsAccess.Source = "reports.png";
        //    ImgHelpAccess.Source = "help.png";


        //    //try
        //    //{
        //    //    await Application.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //}
    }
}
