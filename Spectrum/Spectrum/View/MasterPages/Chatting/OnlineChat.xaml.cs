using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Acr.UserDialogs;
using Spectrum.Model.ModelDataTypes;

using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;

using Spectrum.Service;
using Xamarin.Forms;

namespace Spectrum.View.MasterPages.Chatting
{
    public partial class OnlineChat : ContentPage
    {
        public UserProfileMob _objProfile { get; set; }
        public List<ModuleMainPanel> _lstModules { get; set; }
        public int SelModuleID { get; set; }
        //public TimeSheetsService TimeSheetService { get; set; }
        //public TimeSheetsViewModel ObjtimeSheets { get; set; }
        private List<WorkspaceItem> _lstWorkSpaces { get; set; }
        private WorkspaceItem _curWorkSpace { get; set; }
        public ContentPage _objPage { get; set; }
        int TextFontSize { get; set; }
        int ImageSize { get; set; }
        int RowHeightSize { get; set; }
        int FirstGridHeight { get; set; }
        int FirstGridRowHeieght { get; set; }
        //List<TimesheetListModel> lstTimesheets { get; set; }
        //List<TimesheetListModel> lstTimesheetsApproved { get; set; }
        //List<TimesheetListModel> lstTimesheetsPending { get; set; }
        public ProjectTaskService _objService = new ProjectTaskService();
        public OnlineChat()
        {
            InitializeComponent();
        }

        public OnlineChat(UserProfileMob ObjUserProfile, List<ModuleMainPanel> lstModules, int selModule)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            _objProfile = ObjUserProfile;
            _lstModules = lstModules;
            SelModuleID = selModule;
           // TimeSheetService = new TimeSheetsService();
            //SetPageDesign();
            //BindTimesheetData(0, 0);
        }

        private async void dtpStartDate_DateSelected(System.Object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            txtStartDate.Text = dtpStartDate.Date.Month.ToString("00") + "/" + dtpStartDate.Date.Day.ToString("00") + "/" + dtpStartDate.Date.Year.ToString("00");
        }
        private async void dtpEndDate_DateSelected(System.Object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            txtEndDate.Text = dtpEndDate.Date.Month.ToString("00") + "/" + dtpEndDate.Date.Day.ToString("00") + "/" + dtpEndDate.Date.Year.ToString("00");
            string StartDate = txtStartDate.Text;
            string EndDate = txtEndDate.Text;

            //if (DateTime.Parse(StartDate) > DateTime.Parse(EndDate))
            //{
            //    await DisplayAlert("Alert", "Timesheet Start Date Can not be less than End Date. Please try again later", "Ok");
            //    txtEndDate.Text = dtpStartDate.Date.Month.ToString("00") + "/" + dtpStartDate.Date.Day.ToString("00") + "/" + dtpStartDate.Date.Year.ToString("00");
            //    return;
            //}
        }


        private async void txtStartDate_Tapped(System.Object sender, System.EventArgs e)
        {
            dtpStartDate.Focus();
        }
        private async void txtEndDate_Tapped(System.Object sender, System.EventArgs e)
        {
            dtpEndDate.Focus();
        }
    }



}
