using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Spectrum.View.SpectrumDashboard;
using Spectrum.View.AccountCreation;
using Spectrum.View.MasterPages;

using Spectrum.View.MasterPages.Chatting;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Spectrum
{
    public partial class App : Application
    {
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            //            MainPage = new NavigationPage(new OnlineChatDashboard());
            //MainPage = new NavigationPage(new PunchCardEntry());
        }
        public async void CheckMobileCookies()
        {
            try
            {
                if (Application.Current.Properties.ContainsKey("UserEmail"))
                {
                    if (!string.IsNullOrEmpty(Application.Current.Properties["UserEmail"].ToString()) && !string.IsNullOrEmpty(Application.Current.Properties["Password"].ToString()))
                    {
                        MainPage = new NavigationPage(new CheckLogin(Application.Current.Properties["UserEmail"].ToString(), Application.Current.Properties["Password"].ToString()));
                    }
                    else
                    {
                        MainPage = new NavigationPage(new CheckLogin());
                    }
                }
                else
                {
                    MainPage = new NavigationPage(new CheckLogin());
                }
            }
            catch (Exception)
            {

                MainPage = new NavigationPage(new CheckLogin());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
