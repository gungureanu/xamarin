using System;
using System.Collections.Generic;
using System.Linq;
using Acr.UserDialogs;
using CarPlay;
using Foundation;
using ProgressRingControl.Forms.Plugin.iOS;
using UIKit;
using Xamarin.Forms;

namespace Spectrum.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // Color of the selected tab icon:
            UITabBar.Appearance.SelectedImageTintColor = UIColor.Red;
            //  UITabBar.Appearance.SelectedImageTintColor = UIColor.FromRGB(0, 122, 255);

            // Color of the tabbar background:
            UITabBar.Appearance.BarTintColor = UIColor.Purple;

            // Color of the selected tab text color:
            UITabBarItem.Appearance.SetTitleTextAttributes(
                new UITextAttributes()
                {
                    TextColor = UIColor.Orange
                },
                UIControlState.Selected);

            // Color of the unselected tab icon & text:
            UITabBarItem.Appearance.SetTitleTextAttributes(
                new UITextAttributes()
                {
                    TextColor = UIColor.Black
                },
                UIControlState.Normal);
            //UITabBar.Appearance.TintColor = UIColor.Red;

            Rg.Plugins.Popup.Popup.Init();
            global::Xamarin.Forms.Forms.Init();
            this.Init();
            LoadApplication(new App());

            ProgressRingRenderer.Init();
            App.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
            App.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
            return base.FinishedLaunching(app, options);


        }
    }
}
