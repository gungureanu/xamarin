using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Spectrum.View.Updation
{
    public partial class CheckUpdate : ContentPage
    {
        string _CurAppPlatform { get; set; }
        public CheckUpdate()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            imgCheckUpdate.WidthRequest = App.Current.MainPage.Width;
            imgCheckUpdate.HeightRequest = App.Current.MainPage.Height / 5;
        }
        public CheckUpdate(string AppName, string AppPlatform, string VersionNo, string BuildNo)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            _CurAppPlatform = AppPlatform;
            imgCheckUpdate.WidthRequest = App.Current.MainPage.Width;
            imgCheckUpdate.HeightRequest = App.Current.MainPage.Height / 5;
        }
        private async void Update_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (_CurAppPlatform.ToLower() == "ios")
                {
                    Device.OpenUri(new Uri("https://apps.apple.com/in/app/khamelia/id1547772102"));
                }
                else
                {
                    Device.OpenUri(new Uri("https://play.google.com/store/apps/details?id=com.khamelia.Khamelia"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
