using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Spectrum.Model.ModelDataTypes.TaskManagement;
using Spectrum.ViewModel;
using Xamarin.Forms;

namespace Spectrum.View.MasterPages
{
    public partial class ProjectsTasksList : ContentPage
    {
        public UserProfileMob _objProfile { get; set; }
        public List<ModuleMainPanel> _lstModules { get; set; }
        public int SelModuleID { get; set; }
        private bool IsSearchOpen { get; set; }
        private bool _AllTasks { get; set; }
        private bool _CanShowList { get; set; }
        private int _projectID { get; set; }
        private int _NoOfTasks { get; set; }
        private ProjectTaskViewModel _lstTasks { get; set; }

        public ProjectsTasksList()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            SetPageDesign();
            IsSearchOpen = false;
        }

        public ProjectsTasksList(UserProfileMob ObjUserProfile, List<ModuleMainPanel> lstModules, int selModule, int ProjectID, int NoOfTasks, bool AllTasks)
        {
            InitializeComponent();
            try
            {
                NavigationPage.SetHasNavigationBar(this, false);
                NavigationPage.SetHasBackButton(this, false);
                //BoxFooterList.WidthRequest = (double)Application.Current.MainPage.Width;
                IsSearchOpen = false;
                _objProfile = ObjUserProfile;
                _lstModules = lstModules;
                SelModuleID = selModule;
                _AllTasks = AllTasks;
                _CanShowList = true;
                _projectID = ProjectID;
                _NoOfTasks = NoOfTasks;
                SetPageDesign();
                if (!_AllTasks)
                {
                    imgTaskType.Source = "Toggle_MyTask";
                }
                else
                {
                    imgTaskType.Source = "Toggle_AllTask";
                }
                // SwitchTasks.SetValue(Switch.IsToggledProperty, _AllTasks);
                //if (_NoOfTasks > 0)
                //{
                //    stkTaskList.IsVisible = true;
                //    stkNoTasks.IsVisible = false;
                //}
                //else
                //{
                //    stkTaskList.IsVisible = false;
                //    stkNoTasks.IsVisible = true;
                //}
                _lstTasks = new ProjectTaskViewModel(_objProfile, SelModuleID, _projectID, _AllTasks, lblCanShwList);
                //Thread.Sleep(2000);
                this.BindingContext = _lstTasks;
                //if (_lstTasks.CanShowList)
                //{
                //    stkTaskList.IsVisible = true;
                //    stkNoTasks.IsVisible = false;
                //}
                //else
                //{
                //    stkTaskList.IsVisible = false;
                //    stkNoTasks.IsVisible = true;
                //}
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
                stkMainHeader.HeightRequest = 110;
                stkMainHeader.Padding = new Thickness(0, 0, 0, 0);
                GrdHeader.RowDefinitions[0].Height = 0;
                GrdHeader.Margin = new Thickness(0, 0, 30, 0);
                GrdNew.HorizontalOptions = LayoutOptions.EndAndExpand;
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
                //if (!IsSearchOpen)
                //{
                //    StkSearchBar.HeightRequest = 40;
                //    StkSearchBar.IsVisible = true;
                //    IsSearchOpen = true;
                //}
                //else
                //{
                //    StkSearchBar.HeightRequest = 0;
                //    StkSearchBar.IsVisible = false;
                //    IsSearchOpen = false;
                //}
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


        private async void OnTaskSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                ProjectTaskDetail item = (ProjectTaskDetail)e.SelectedItem;
                if (item != null)
                {
                    Thread.Sleep(750);
                    //await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.ProjectTasksDetails(_objProfile, _lstModules, SelModuleID, item, _AllTasks, _projectID));
                    await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Project Tasks", new Spectrum.View.MasterPages.ProjectTasksDetails(_objProfile, _lstModules, SelModuleID, item, _AllTasks, _projectID)));
                }
                else
                {
                    await DisplayAlert("Connection Error", "Cannot process request due to connection problem, Please try again later", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Connection Error", "Cannot process request due to connection problem, Please try again later", "OK");
            }
        }

        //private async void Switch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        //{
        //    if (_AllTasks != e.Value)
        //    {
        //        _AllTasks = e.Value;
        //        if (!_AllTasks)
        //        {
        //            lblAllTasks.TextColor = Color.White;
        //            lblMyTasks.TextColor = Color.Black;
        //        }
        //        else
        //        {
        //            lblAllTasks.TextColor = Color.Black;
        //            lblMyTasks.TextColor = Color.White;
        //        }
        //        this.BindingContext = null;
        //        this.BindingContext = new ProjectTaskViewModel(_objProfile, SelModuleID, _projectID, _AllTasks);
        //        //  await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Project Tasks", new Spectrum.View.MasterPages.ProjectsTasksList(_objProfile, _lstModules, SelModuleID, e.Value)));
        //    }
        //}

        //private async void AllTaskFrame_Tapped(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!_AllTasks)
        //        {
        //            imgTaskType.Source = "Toggle_AllTask";


        //            _AllTasks = true;
        //            this.BindingContext = null;
        //            this.BindingContext = new ProjectTaskViewModel(_objProfile, SelModuleID, _projectID, _AllTasks);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        //private async void MyTaskFrame_Tapped(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (_AllTasks)
        //        {
        //            frmMyTasks.BackgroundColor = Color.FromHex("#FFFFFF");
        //            lblMyTasks.TextColor = Color.FromHex("#2292E8");
        //            frmAllTasks.BackgroundColor = Color.FromHex("#2292E8");
        //            lblAllTasks.TextColor = Color.FromHex("#FFFFFF");

        //            _AllTasks = false;
        //            this.BindingContext = null;
        //            this.BindingContext = new ProjectTaskViewModel(_objProfile, SelModuleID, _projectID, _AllTasks);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        private async void Toggle_TaskType(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (!_AllTasks)
                {
                    imgTaskType.Source = "Toggle_AllTask";
                    _AllTasks = true;
                    this.BindingContext = null;
                }
                else
                {
                    imgTaskType.Source = "Toggle_MyTask";
                    _AllTasks = false;
                }
                lblCanShwList.Text = "";
                _lstTasks = new ProjectTaskViewModel(_objProfile, SelModuleID, _projectID, _AllTasks, lblCanShwList);

                this.BindingContext = null;
                this.BindingContext = _lstTasks;
                //Thread.Sleep(2000);
                //if (_lstTasks.CanShowList)
                //{
                //    stkTaskList.IsVisible = true;
                //    stkNoTasks.IsVisible = false;
                //}
                //else
                //{
                //    stkTaskList.IsVisible = false;
                //    stkNoTasks.IsVisible = true;
                //}

                //this.BindingContext = null;
                //this.BindingContext = new ProjectTaskViewModel(_objProfile, SelModuleID, _projectID, _AllTasks, _CanShowList);
                //if (_NoOfTasks > 0)
                //{
                //    stkTaskList.IsVisible = true;
                //    stkNoTasks.IsVisible = false;
                //}
                //else
                //{
                //    stkTaskList.IsVisible = false;
                //    stkNoTasks.IsVisible = true;
                //}
            }
            catch (Exception ex)
            {

            }
        }

        private async void New_Task_Clicked(System.Object sender, System.EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Projects", new Spectrum.View.MasterPages.NewTask(_objProfile, _lstModules, SelModuleID, _projectID, _NoOfTasks, _AllTasks)));
        }

        private async void Cancel_TaskList_Tapped(System.Object sender, System.EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Projects", new Spectrum.View.MasterPages.WorkSpaceSelection(_objProfile, _lstModules, 3)));
        }

        private void lblCanShwList_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (lblCanShwList.Text == "0")
            {
                stkTaskList.IsVisible = false;
                stkNoTasks.IsVisible = true;
            }
            else
            {
                stkNoTasks.IsVisible = false;
                stkTaskList.IsVisible = true;
            }
        }
    }
}
