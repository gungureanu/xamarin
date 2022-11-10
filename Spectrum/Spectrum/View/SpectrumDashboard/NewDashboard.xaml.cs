using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Spectrum.View.SpectrumDashboard
{
    public partial class NewDashboard : ContentPage
    {

        private bool DashboardAccess;
        private bool AppsAccess;
        private bool ReportsAccess;
        private bool HelpAccess;
        private bool SettingsAccess;

        public NewDashboard()
        {
            InitializeComponent();

            DashboardAccess = false;
            AppsAccess = false;
            ReportsAccess = false;
            HelpAccess = false;
            SettingsAccess = false;


            StkDashboardPage.IsVisible = true;
            StkAppsPage.IsVisible = false;
            StkReportsPage.IsVisible = false;
            StkHelpPage.IsVisible = false;
            StkSettingsPage.IsVisible = false;


            LblDashboardPage.IsVisible = true;
            LblAppsPage.IsVisible = false;
            LblReportsPage.IsVisible = false;
            LblHelpPage.IsVisible = false;
            LblSettingsPage.IsVisible = false;


            LblDashboardPage1.IsVisible = false;
        }


        private async void Dashboard_Clicked(object sender, EventArgs e)
        {
            if (!DashboardAccess)
            {
                DashboardAccess = true;
                ImgDashboardAccess.Source = "dashboard_active.png";
            }
            AppsAccess = false;
            ReportsAccess = false;
            HelpAccess = false;
            SettingsAccess = false;
            ImgAppsAccess.Source = "apps.png";
            ImgReportsAccess.Source = "reports.png";
            ImgHelpAccess.Source = "help.png";
            ImgSettingsAccess.Source = "setting.png";

            Device.BeginInvokeOnMainThread(() =>
            {
                StkDashboardPage.IsVisible = true;
                StkAppsPage.IsVisible = false;
                StkReportsPage.IsVisible = false;
                StkHelpPage.IsVisible = false;
                StkSettingsPage.IsVisible = false;

                LblDashboardPage.IsVisible = true;
                LblAppsPage.IsVisible = false;
                LblReportsPage.IsVisible = false;
                LblHelpPage.IsVisible = false;
                LblSettingsPage.IsVisible = false;

                LblDashboardPage1.IsVisible = false;
                LblAppsPage1.IsVisible = true;
                LblReportsPage1.IsVisible = true;
                LblHelpPage1.IsVisible = true;
                LblSettingsPage1.IsVisible = true;

            });
        }


        private async void Apps_Clicked(object sender, EventArgs e)
        {
            if (!AppsAccess)
            {
                AppsAccess = true;
                ImgAppsAccess.Source = "apps_active.png";
            }

            ReportsAccess = false;
            HelpAccess = false;
            SettingsAccess = false;
            DashboardAccess = false;
            ImgDashboardAccess.Source = "dashboard.png";

            ImgReportsAccess.Source = "reports.png";
            ImgHelpAccess.Source = "help.png";
            ImgSettingsAccess.Source = "setting.png";

            Device.BeginInvokeOnMainThread(() =>
            {
                StkDashboardPage.IsVisible = false;
                StkAppsPage.IsVisible = true;
                StkReportsPage.IsVisible = false;
                StkHelpPage.IsVisible = false;
                StkSettingsPage.IsVisible = false;

                LblDashboardPage.IsVisible = false;
                LblAppsPage.IsVisible = true;
                LblReportsPage.IsVisible = false;
                LblHelpPage.IsVisible = false;
                LblSettingsPage.IsVisible = false;

                LblDashboardPage1.IsVisible = true;
                LblAppsPage1.IsVisible = false;
                LblReportsPage1.IsVisible = true;
                LblHelpPage1.IsVisible = true;
                LblSettingsPage1.IsVisible = true;

            });
        }

        private async void Reports_Clicked(object sender, EventArgs e)
        {
            if (!ReportsAccess)
            {
                ReportsAccess = true;
                ImgReportsAccess.Source = "reports_active.png";
            }
            HelpAccess = false;
            SettingsAccess = false;
            DashboardAccess = false;
            AppsAccess = false;
            ImgDashboardAccess.Source = "dashboard.png";
            ImgAppsAccess.Source = "apps.png";

            ImgHelpAccess.Source = "help.png";
            ImgSettingsAccess.Source = "setting.png";

            Device.BeginInvokeOnMainThread(() =>
            {
                StkDashboardPage.IsVisible = false;
                StkAppsPage.IsVisible = false;
                StkReportsPage.IsVisible = true;
                StkHelpPage.IsVisible = false;
                StkSettingsPage.IsVisible = false;

                LblDashboardPage.IsVisible = false;
                LblAppsPage.IsVisible = false;
                LblReportsPage.IsVisible = true;
                LblHelpPage.IsVisible = false;
                LblSettingsPage.IsVisible = false;

                LblDashboardPage1.IsVisible = true;
                LblAppsPage1.IsVisible = true;
                LblReportsPage1.IsVisible = false;
                LblHelpPage1.IsVisible = true;
                LblSettingsPage1.IsVisible = true;

            });

        }
        private async void Help_Clicked(object sender, EventArgs e)
        {
            if (!HelpAccess)
            {
                HelpAccess = true;
                ImgHelpAccess.Source = "help_active.png";
            }

            SettingsAccess = false;
            DashboardAccess = false;
            AppsAccess = false;
            ReportsAccess = false;
            ImgDashboardAccess.Source = "dashboard.png";
            ImgAppsAccess.Source = "apps.png";
            ImgReportsAccess.Source = "reports.png";
            ImgSettingsAccess.Source = "setting.png";

            Device.BeginInvokeOnMainThread(() =>
            {

                StkDashboardPage.IsVisible = false;
                StkAppsPage.IsVisible = false;
                StkReportsPage.IsVisible = false;
                StkHelpPage.IsVisible = true;
                StkSettingsPage.IsVisible = false;

                LblDashboardPage.IsVisible = false;
                LblAppsPage.IsVisible = false;
                LblReportsPage.IsVisible = false;
                LblHelpPage.IsVisible = true;
                LblSettingsPage.IsVisible = false;

                LblDashboardPage.IsVisible = false;
                LblAppsPage.IsVisible = false;
                LblReportsPage.IsVisible = false;
                LblHelpPage.IsVisible = true;
                LblSettingsPage.IsVisible = false;

                LblDashboardPage1.IsVisible = true;
                LblAppsPage1.IsVisible = true;
                LblReportsPage1.IsVisible = true;
                LblHelpPage1.IsVisible = false;
                LblSettingsPage1.IsVisible = true;
            });
        }
        private async void Settings_Clicked(object sender, EventArgs e)
        {
            if (!SettingsAccess)
            {

                SettingsAccess = true;
                ImgSettingsAccess.Source = "settings_active.png";
            }

            DashboardAccess = false;
            AppsAccess = false;
            ReportsAccess = false;
            HelpAccess = false;
            ImgDashboardAccess.Source = "dashboard.png";
            ImgAppsAccess.Source = "apps.png";
            ImgReportsAccess.Source = "reports.png";
            ImgHelpAccess.Source = "help.png";

            Device.BeginInvokeOnMainThread(() =>
            {

                StkDashboardPage.IsVisible = false;
                StkAppsPage.IsVisible = false;
                StkReportsPage.IsVisible = false;
                StkHelpPage.IsVisible = false;
                StkSettingsPage.IsVisible = true;

                LblDashboardPage.IsVisible = false;
                LblAppsPage.IsVisible = false;
                LblReportsPage.IsVisible = false;
                LblHelpPage.IsVisible = false;
                LblSettingsPage.IsVisible = true;

                LblDashboardPage1.IsVisible = true;
                LblAppsPage1.IsVisible = true;
                LblReportsPage1.IsVisible = true;
                LblHelpPage1.IsVisible = true;
                LblSettingsPage1.IsVisible = false; ;
            });
        }
    }
}
