using Spectrum.Model;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Spectrum.Service;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace Spectrum.Views.Popup.Alerts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupMessage : PopupPage
    {
        private object popupLoadingView;

        private AlertPopup _objAlert { get; set; }
        private UserProfileMob _objProfile { get; set; }
        Label _lblUndoStatus { get; set; }
        private List<ModuleMainPanel> _lstModules { get; set; }
   
        public PopupMessage()
        {
            InitializeComponent();
            setcontrols();
        }
        public PopupMessage(AlertPopup objalert, UserProfileMob objProfile, Label lblUndoStatus)
        {
            InitializeComponent();
            setcontrols();
            _objAlert = objalert;
            _objProfile = objProfile;
            _lblUndoStatus = lblUndoStatus;
            //punchCardService = new PunchCardService();
            SetPoupText();
        }

        private async void SetPoupText()
        {
            lblMessageHeading.Text = _objAlert.PopupHeading;
            lblMessageText.Text = _objAlert.PopupMessage;
            //LblActivity.Text = _objAlert.ClockActivity;
        }
        private async void Close_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAllPopupAsync();
        }

        private void setcontrols()
        {
            if (Device.Idiom == TargetIdiom.Phone)
            {
                // frmtxt.HeightRequest = 170;
                //frmtxt.WidthRequest = 285;

                // frmtxt.Margin = new Thickness(0, 4, 10, 0);
                // frmMain.Padding = new Thickness(10, 30, 10, 0);
            }
            else
            {

                //frmtxt.Margin = new Thickness(0, 4, 12, 0);
                //frmMain.Padding = new Thickness(20, 20, 20, 0);
                //frmtxt.HeightRequest = 340;
                //frmtxt.WidthRequest = 420;
            }
        }

        private async void UndoActivity_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                //int retval = await punchCardService.UndoPunchCardActivity(Convert.ToString(_objProfile.AccountID), 23, Convert.ToString(_objProfile.UserID));
                //_lblUndoStatus.Text = retval.ToString();
                //await Navigation.PopAllPopupAsync();
            }
            catch (Exception ex)
            {

            }
        }
    }
}