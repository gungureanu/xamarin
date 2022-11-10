using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Acr.UserDialogs;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Spectrum.Model.ModelDataTypes.ProjectManagement;
using Spectrum.Model.ModelDataTypes.TaskManagement;
using Spectrum.Service;
using Spectrum.ViewModel;
using Xamarin.Forms;
//using Xamarin.Forms.Markup;

namespace Spectrum.View.MasterPages
{
    public partial class NewTask : ContentPage
    {
        public UserProfileMob _objProfile { get; set; }
        public List<ModuleMainPanel> _lstModules { get; set; }
        public int SelModuleID { get; set; }
        public int _ProjectID { get; set; }
        public int _NoOfTasks { get; set; }
        private bool _AllTasks { get; set; }
        private List<ProjectDetailList> _lstProject { get; set; }
        private List<TaskTypeProfile> _lstTaskType { get; set; }
        private List<TaskPriorityProfile> _lstTaskPriority { get; set; }
        private List<UserProfile> _lstProjectManager { get; set; }
        private List<UserProfile> _lstTaskOwner { get; set; }

        ProjectDetailList _curProject { get; set; }
        TaskTypeProfile _curTaskType { get; set; }
        TaskPriorityProfile _curTaskPriority { get; set; }
        UserProfile _curProjectManager { get; set; }
        UserProfile _curTaskOwner { get; set; }

        private Int64 _curProjectID { get; set; }
        private Int64 _curTaskTypeID { get; set; }
        private Int64 _curTaskTypeCategoryID { get; set; }
        private Int64 _curTaskPriorityID { get; set; }
        private Guid _curProjectManagerID { get; set; }
        private Guid _curTaskOwnerID { get; set; }

        private MobileTaskViewModel objVM { get; set; }



        public ProjectTaskService _objService = new ProjectTaskService();
        List<ProjectDetailList> Items { get; set; }
        public NewTask()
        {
            InitializeComponent();
            SetPageDesign();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }
        public NewTask(UserProfileMob ObjUserProfile, List<ModuleMainPanel> lstModules, int selModule, int ProjectID, int NoOfTasks, bool AllTasks)
        {
            InitializeComponent();
            try
            {
                NavigationPage.SetHasNavigationBar(this, false);
                NavigationPage.SetHasBackButton(this, false);
                _objProfile = ObjUserProfile;
                _lstModules = lstModules;
                _ProjectID = ProjectID;
                _NoOfTasks = NoOfTasks;
                _AllTasks = AllTasks;
                SelModuleID = selModule;
                StkProjectList.HeightRequest = (double)Application.Current.MainPage.Height - (110);
                SetPageDesign();
                BindTaskDDLs(true);
                dtpTaskSubmitDate.Date = System.DateTime.Now;
                dtpDueDate.Date = System.DateTime.Now.AddDays(7);
                txtSubmitDate.Text = dtpTaskSubmitDate.Date.Month.ToString("00") + "/" + dtpTaskSubmitDate.Date.Day.ToString("00") + "/" + dtpTaskSubmitDate.Date.Year.ToString("00");
                txtDueDate.Text = dtpDueDate.Date.Month.ToString("00") + "/" + dtpDueDate.Date.Day.ToString("00") + "/" + dtpDueDate.Date.Year.ToString("00");

            }
            catch (Exception ex)
            {
                DisplayAlert("Oops", "Something went wrong. Please contact Specturm Administrator", "OK");
            }
        }
        private async void SetPageDesign()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                stkMainHeader.HeightRequest = 60;
                stkMainHeader.Padding = new Thickness(0, 0, 0, 0);
                GrdHeader.RowDefinitions[0].Height = 0;
                GrdHeader.Margin = new Thickness(0, 0, 30, 0);
                // GrdNew.HorizontalOptions = LayoutOptions.EndAndExpand;
            }
        }
        private async void BindTaskDDLs(bool isFirstTime)
        {
            try
            {
                objVM = await _objService.GetNewTaskDDLs(_ProjectID, Convert.ToString(_objProfile.CompanyID), Convert.ToString(_objProfile.UserID), Convert.ToString(_objProfile.AccountID), SelModuleID, _objProfile.WorkspaceID);
                if (objVM != null)
                {
                    if (isFirstTime)
                    {
                        if (objVM.lstProject != null && objVM.lstProject.Count > 0)
                        {
                            _lstProject = objVM.lstProject;
                            ddlProject.ItemsSource = null;
                            ddlProject.ItemsSource = _lstProject;
                            _curProject = _lstProject.Where(x => x.ProjectID == _ProjectID).FirstOrDefault();
                            ddlProject.SelectedItem = _curProject;
                        }
                    }

                    if (objVM.lstProjectManager != null && objVM.lstProjectManager.Count > 0)
                    {
                        _lstProjectManager = objVM.lstProjectManager;
                        ddlProjectManager.ItemsSource = null;
                        ddlProjectManager.ItemsSource = _lstProjectManager;
                        _curProjectManager = _lstProjectManager.Where(x => x.UserID == _objProfile.UserID).FirstOrDefault();
                        ddlProjectManager.SelectedItem = _curProjectManager;

                    }
                    if (objVM.lstTaskOwner != null && objVM.lstTaskOwner.Count > 0)
                    {
                        _lstTaskOwner = objVM.lstTaskOwner;
                        ddlTaskOwner.ItemsSource = null;
                        ddlTaskOwner.ItemsSource = _lstTaskOwner;
                        _curTaskOwner = _lstTaskOwner.Where(x => x.UserID == _objProfile.UserID).FirstOrDefault();
                        ddlTaskOwner.SelectedItem = _curTaskOwner;

                    }
                    if (objVM.lstTaskPriority != null && objVM.lstTaskPriority.Count > 0)
                    {
                        _lstTaskPriority = objVM.lstTaskPriority.Where(x => x.ProjectID == _ProjectID).ToList();
                        ddlPriority.ItemsSource = null;
                        ddlPriority.ItemsSource = _lstTaskPriority;
                        _curTaskPriority = _lstTaskPriority.FirstOrDefault();
                        ddlPriority.SelectedItem = _curTaskPriority;

                    }
                    if (objVM.lstTaskType != null && objVM.lstTaskType.Count > 0)
                    {
                        if (_curProject.ProjectCategoryID == 1)
                        {
                            _lstTaskType = objVM.lstTaskType.Where(x => x.TaskTypeCategoryID == 1).ToList();
                        }
                        else
                        {
                            _lstTaskType = objVM.lstTaskType.Where(x => x.TaskTypeCategoryID == 2).ToList();
                        }


                        ddlTaskType.ItemsSource = null;
                        ddlTaskType.ItemsSource = _lstTaskType;
                        _curTaskType = _lstTaskType.FirstOrDefault();
                        ddlTaskType.SelectedItem = _curTaskType;
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Oops", "Something went wrong. Please contact Specturm Administrator", "OK");
            }
        }

        private async void NavIconTapped_Tapped(object sender, EventArgs e)
        {
            try
            {
                var master = ((MasterDetailPage)(this.Parent.Parent));
                if (master != null)
                {
                    master.IsPresented = true;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("OOps", ex.Message.ToString(), "OK");
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
                //
            }
            catch (Exception ex)
            {
                //Write error logs
            }
        }

        private async void SearchTask_Tapped(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

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

        private async void CancelTask_Tapped(System.Object sender, System.EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Project Tasks", new Spectrum.View.MasterPages.ProjectsTasksList(_objProfile, _lstModules, SelModuleID, _ProjectID, _NoOfTasks, _AllTasks)));
        }

        private async void SaveTask_Tapped(System.Object sender, System.EventArgs e)
        {
            if (ddlProject.SelectedIndex < 0)
            {
                await DisplayAlert("Project Required", "Please select Project", "Ok");
                return;
            }
            else
            {
                _curProject = ddlProject.SelectedItem as ProjectDetailList;
                if (_curProject != null)
                {
                    _curProjectID = _curProject.ProjectID;
                }
            }
            if (string.IsNullOrEmpty(txtTaskName.Text))
            {
                await DisplayAlert("Task Name Required", "Please enter Task Name", "Ok");
                return;
            }
            if (ddlTaskType.SelectedIndex < 0)
            {
                await DisplayAlert("Task Type Required", "Please select Task Type", "Ok");
                return;
            }
            else
            {
                _curTaskType = ddlTaskType.SelectedItem as TaskTypeProfile;
                if (_curTaskType != null)
                {
                    _curTaskTypeID = _curTaskType.TaskTypeID;
                    _curTaskTypeCategoryID = _curTaskType.TaskTypeCategoryID;
                }
            }
            if (ddlPriority.SelectedIndex < 0)
            {
                await DisplayAlert("Priority Required", "Please select Task Priority", "Ok");
                return;
            }
            else
            {
                _curTaskPriority = ddlPriority.SelectedItem as TaskPriorityProfile;
                if (_curTaskPriority != null)
                {
                    _curTaskPriorityID = _curTaskPriority.PriorityID;
                }
            }
            if (ddlProjectManager.SelectedIndex < 0)
            {
                await DisplayAlert("Project Manager Required", "Please select Project Manager", "Ok");
                return;
            }
            else
            {
                _curProjectManager = ddlProjectManager.SelectedItem as UserProfile;
                if (_curProjectManager != null)
                {
                    _curProjectManagerID = _curProjectManager.UserID;
                }
            }
            if (ddlTaskOwner.SelectedIndex < 0)
            {
                await DisplayAlert("Task Owner Required", "Please select Task Owner", "Ok");
                return;
            }
            else
            {
                _curTaskOwner = ddlTaskOwner.SelectedItem as UserProfile;
                if (_curTaskOwner != null)
                {
                    _curTaskOwnerID = _curTaskOwner.UserID;
                }
            }
            if (string.IsNullOrEmpty(txtTaskDescription.Text))
            {
                txtTaskDescription.Text = txtTaskName.Text;
            }
            using (UserDialogs.Instance.Loading("Createing Task..."))
            {
                MobileCreateTaskModel objTask = new MobileCreateTaskModel
                {
                    ProjectID = _curProjectID,
                    TaskName = txtTaskName.Text.Trim(),
                    TaskTypeID = _curTaskTypeID,
                    TaskTypeCategoryID = _curTaskTypeCategoryID,
                    PriorityID = _curTaskPriorityID,
                    ProjectManagerID = _curProjectManagerID,
                    TaskOwnerID = _curTaskOwnerID,
                    Description = txtTaskDescription.Text.Trim(),
                    SubmitDate = dtpTaskSubmitDate.Date.ToString("yyyy-MM-dd"),
                    DueDate = dtpDueDate.Date.ToString("yyyy-MM-dd"),
                    AccountID = _objProfile.AccountID,
                    CompanyID = _objProfile.CompanyID,
                    ModuleID = SelModuleID,
                    WorkspaceID = _objProfile.WorkspaceID,
                    UserID = _objProfile.UserID

                };
                MobileTaskResponse objTaskProfile = await _objService.Save_ProjectTask(objTask);
                if (objTaskProfile.TaskID > 0)
                {
                    await DisplayAlert("Success", "Task has been created successfully", "Ok");
                    await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Project Tasks", new Spectrum.View.MasterPages.ProjectsTasksList(_objProfile, _lstModules, SelModuleID, _ProjectID, _NoOfTasks, _AllTasks)));
                }
                else
                {
                    await DisplayAlert("Failed", "Unable to create Task due to some internal issue. Please contact administrtor", "Ok");
                }
            }
        }

        private async void ddlProject_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                Picker picker = sender as Picker;
                _curProject = picker.SelectedItem as ProjectDetailList;
                _curProjectID = Convert.ToInt64(_curProject.ProjectID);
                _ProjectID = Convert.ToInt32(_curProjectID);
                BindTaskDDLs(false);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Specturm Administrator", "OK");
            }
        }

        private async void txtSubmitDate_Tapped(System.Object sender, System.EventArgs e)
        {
            dtpTaskSubmitDate.Focus();
        }
        private async void txtDueDate_Tapped(System.Object sender, System.EventArgs e)
        {
            dtpDueDate.Focus();
        }

        private async void dtpTaskSubmitDate_DateSelected(System.Object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            //txtSubmitDate.Text = dtpTaskSubmitDate.Date.ToString("MM/dd/yyyy");
            txtSubmitDate.Text = dtpTaskSubmitDate.Date.Month.ToString("00") + "/" + dtpTaskSubmitDate.Date.Day.ToString("00") + "/" + dtpTaskSubmitDate.Date.Year.ToString("00");

        }

        private async void dtpDueDate_DateSelected(System.Object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            //txtDueDate.Text = dtpDueDate.Date.ToString("MM/dd/yyyy");
            txtDueDate.Text = dtpDueDate.Date.Month.ToString("00") + "/" + dtpDueDate.Date.Day.ToString("00") + "/" + dtpDueDate.Date.Year.ToString("00");
        }
    }

}
