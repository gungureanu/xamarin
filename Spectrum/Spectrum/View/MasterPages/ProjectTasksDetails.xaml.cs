using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Spectrum.Model.ModelDataTypes.TaskManagement;
using Spectrum.Service;
using Xamarin.Forms;
//using Xamarin.Forms.Markup;

namespace Spectrum.View.MasterPages
{
    public partial class ProjectTasksDetails : ContentPage
    {
        public UserProfileMob _objProfile { get; set; }
        public List<ModuleMainPanel> _lstModules { get; set; }
        public ProjectTaskDetail _objTask { get; set; }
        private bool _AllTasks { get; set; }

        public int SelModuleID { get; set; }
        public int _ProjectID { get; set; }
        ProjectTaskService objTaskService { get; set; }
        public ProjectTasksDetails()
        {
            InitializeComponent();
            objTaskService = new ProjectTaskService();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            //grdTask.Row(0).BackgroundColor = Color.Red;
            BoxView1.WidthRequest = (double)Application.Current.MainPage.Width;
            boxTaskDetailBottom.WidthRequest = (double)Application.Current.MainPage.Width;
            scrTaskDescription.HeightRequest = (double)Application.Current.MainPage.Height - (84 + 78 + 30);
            scrTaskDescription.WidthRequest = (double)Application.Current.MainPage.Width;
            SetPageDesign();
        }

        public ProjectTasksDetails(UserProfileMob ObjUserProfile, List<ModuleMainPanel> lstModules, int selModule, ProjectTaskDetail objTask, bool AllTasks, int ProjectID)
        {
            InitializeComponent();
            objTaskService = new ProjectTaskService();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            //grdTask.Row(0).BackgroundColor = Color.Red;
            BoxView1.WidthRequest = (double)Application.Current.MainPage.Width;
            boxTaskDetailBottom.WidthRequest = (double)Application.Current.MainPage.Width;

            scrTaskDescription.HeightRequest = (double)Application.Current.MainPage.Height - (84 + 78 + 30);
            scrTaskDescription.WidthRequest = (double)Application.Current.MainPage.Width;
            _objProfile = ObjUserProfile;
            _lstModules = lstModules;
            _objTask = objTask;
            _AllTasks = AllTasks;
            _ProjectID = ProjectID;
            SelModuleID = selModule;
            SetPageDesign();
            SetTaskDetail();
        }

        private async void SetPageDesign()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                stkMainHeader.HeightRequest = 60;
                GrdHeader.RowDefinitions[0].Height = 0;
                GrdHeader.Margin = new Thickness(0, 0, 30, 0);
                // GrdNew.HorizontalOptions = LayoutOptions.EndAndExpand;
            }
        }
        private async void SetTaskDetail()
        {
            //txtTaskSummary.Text = _objTask.TaskPrefixKey + " - " + _objTask.TaskName;
            txtTaskSummary.Text = _objTask.TaskName;
            txtAssignedTo.Text = "To: " + _objTask.ProjectAssignName;
            lblDescription.Text = _objTask.Description;
            txtTaskOwner.Text = _objTask.TaskOwnerName;
            txtTaskDate.Text = _objTask.ModifiedDate.ToString("ddd") + " " + _objTask.MainListName + " " + _objTask.TaskTimeName;
            GetTaskAttachments();
        }

        private async void GetTaskAttachments()
        {

            List<DocumentUpload> lstdocuements = await objTaskService.GetTaskDocuentsAsync(SelModuleID, "ProjectTask", Convert.ToInt32(_objTask.TaskID), _objProfile.UserID.ToString(), _objProfile.AccountID.ToString());
            if (lstdocuements != null && lstdocuements.Count > 0)
            {
                grdAttachment.IsVisible = true;
                ScrDocuments.IsVisible = true;
                ScrDocuments.HeightRequest = 45;
                grdAttachment.RowDefinitions[1].Height = 45;
                if (lstdocuements.Count > 1)
                    txtAttachmentCount.Text = lstdocuements.Count.ToString() + " attachments";
                else
                    txtAttachmentCount.Text = lstdocuements.Count.ToString() + " attachment";
                foreach (DocumentUpload doc in lstdocuements)
                {
                    if (doc != null)
                    {
                        var curAttachment = new StackLayout
                        {
                            VerticalOptions = LayoutOptions.Start,
                            HorizontalOptions = LayoutOptions.Center,
                            Orientation = StackOrientation.Vertical,
                            HeightRequest = 45,
                            WidthRequest = 45,
                            BackgroundColor = Color.FromHex("#4E9BEA"),
                            Opacity = 0.5
                        };
                        var attachmentImage = new Image
                        {
                            Source = "https://khamelia.com/" + doc.FilePath,
                            HeightRequest = 35,
                            WidthRequest = 45,
                            Aspect = Aspect.AspectFill
                        };
                        curAttachment.Children.Add(attachmentImage);
                        StkDocuments.Children.Add(curAttachment);
                    }

                }
            }
            else
            {
                //txtAttachmentCount.Text = "No attachments";
                grdAttachment.IsVisible = false;
                txtAttachmentCount.Text = "";
                ScrDocuments.IsVisible = false;
                ScrDocuments.HeightRequest = 0;
                grdAttachment.RowDefinitions[1].Height = 10;
            }
            UpdateTaskReadStatus();
        }

        private async void UpdateTaskReadStatus()
        {
            try
            {
                int retval = await objTaskService.Update_TaskReadStatus(Convert.ToString(_objProfile.AccountID), Convert.ToString(_objProfile.CompanyID), Convert.ToString(_objProfile.UserID), _ProjectID, _objTask.TaskID, 3);
            }
            catch (Exception ex)
            {
                // Do nothing
            }
        }
        private async void BackIconTapped_Tapped(object sender, EventArgs e)
        {
            try
            {
                //await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.ProjectsTasksList(_objProfile, _lstModules, SelModuleID));
                await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Project Tasks", new Spectrum.View.MasterPages.ProjectsTasksList(_objProfile, _lstModules, SelModuleID, _ProjectID, 1, _AllTasks)));
            }
            catch (Exception ex)
            {
                //Write error logs
            }
        }

        private async void Envelope_Tapped(object sender, EventArgs e)
        {
            try
            {
                //ispre
            }
            catch (Exception ex)
            {
                //Write error logs
            }
        }
        private async void Search_Tapped(object sender, EventArgs e)
        {
            try
            {
                //ispre
            }
            catch (Exception ex)
            {
                //Write error logs
            }
        }
        private async void Calendar_Tapped(object sender, EventArgs e)
        {
            try
            {
                //ispre
            }
            catch (Exception ex)
            {
                //Write error logs
            }
        }
    }
}
