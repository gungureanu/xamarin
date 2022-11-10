using System;

using Xamarin.Forms;

namespace KhameliaApp.View.ForgotPassword
{
    public class ForgotPasswordThankYou : ContentPage
    {
        public ForgotPasswordThankYou()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

