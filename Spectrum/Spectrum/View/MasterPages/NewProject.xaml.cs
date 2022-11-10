using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Acr.UserDialogs;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Spectrum.Model.ModelDataTypes.ProjectManagement;
using Spectrum.Service;
using Xamarin.Forms;
//using Xamarin.Forms.Markup;


namespace Spectrum.View.MasterPages
{
    public partial class NewProject : ContentPage
    {
        public UserProfileMob _objProfile { get; set; }
        public List<ModuleMainPanel> _lstModules { get; set; }
        public int SelModuleID { get; set; }
        public ProjectTaskService _objService = new ProjectTaskService();
        List<ProjectDetailList> Items { get; set; }
        private MobileProjectDetailViewModel objProjectDDLs { get; set; }

        private List<ProjectTypeDetailProfile> _lstProjectType { get; set; }
        private ProjectTypeDetailProfile _curProjectType { get; set; }
        private int _ProjectTypeCategoryID { get; set; }

        private List<CompanyProfile> _lstCompanies { get; set; }
        private CompanyProfile _curCompany { get; set; }
        private string _companyID { get; set; }

        private List<TeamProfile> _lstTeams { get; set; }
        private TeamProfile _curTeam { get; set; }
        private int _TeamID { get; set; }

        private List<UserProfile> _lstProjectManager { get; set; }
        private UserProfile _curProjectManager { get; set; }
        private string _ProjectManagerID { get; set; }

        private List<ProjectStatusProfile> _lstProjectStatus { get; set; }
        private ProjectStatusProfile _curProjectStatus { get; set; }
        private long _ProjectStatusID { get; set; }


        public NewProject()
        {
            InitializeComponent();
            SetPageDesign();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }
        public NewProject(UserProfileMob ObjUserProfile, List<ModuleMainPanel> lstModules, int selModule)
        {
            InitializeComponent();
            try
            {

                NavigationPage.SetHasNavigationBar(this, false);
                NavigationPage.SetHasBackButton(this, false);
                _objProfile = ObjUserProfile;
                _lstModules = lstModules;
                SelModuleID = selModule;
                StkProjectList.HeightRequest = (double)Application.Current.MainPage.Height - (110);
                SetPageDesign();
                BindProjectDDLs();

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
        private async void BindProjectDDLs()
        {
            try
            {
                objProjectDDLs = await _objService.Fetch_ProjectPageDDLS(3, Convert.ToString(_objProfile.UserID), Convert.ToString(_objProfile.PrimaryCompanyID)
                    , Convert.ToString(_objProfile.AccountID), _objProfile.WorkspaceID, Convert.ToString(_objProfile.IsSpecialLogin));
                if (objProjectDDLs != null)
                {
                    txtTaskNumber.Text = objProjectDDLs.NextTaskNumber.ToString();
                    if (objProjectDDLs.lstProjectType != null && objProjectDDLs.lstProjectType.Count > 0)
                    {
                        _lstProjectType = objProjectDDLs.lstProjectType.Where(x => x.ProjectypeCategoryID == 1 || x.ProjectypeCategoryID == 2).ToList();
                        if (_lstProjectType != null && _lstProjectType.Count > 0)
                        {
                            _curProjectType = _lstProjectType.FirstOrDefault();
                            ddlProjectType.ItemsSource = _lstProjectType;
                            ddlProjectType.SelectedItem = _curProjectType;
                            _ProjectTypeCategoryID = _curProjectType.ProjectypeCategoryID;
                        }
                    }
                    if (objProjectDDLs.lstCompanies != null && objProjectDDLs.lstCompanies.Count > 0)
                    {
                        _lstCompanies = objProjectDDLs.lstCompanies.Where(x => x.AccountID == _objProfile.AccountID).ToList();
                        if (_lstCompanies != null && _lstCompanies.Count > 0)
                        {
                            ddlCompany.ItemsSource = _lstCompanies;
                            _curCompany = _lstCompanies.FirstOrDefault();
                            ddlCompany.SelectedItem = _curCompany;
                        }
                    }
                    if (objProjectDDLs.lstTeams != null && objProjectDDLs.lstTeams.Count > 0)
                    {
                        _lstTeams = objProjectDDLs.lstTeams;
                        if (_lstTeams != null && _lstTeams.Count > 0)
                        {
                            ddlTeam.ItemsSource = _lstTeams;
                            _curTeam = _lstTeams.FirstOrDefault();
                            ddlTeam.SelectedItem = _curTeam;
                            _TeamID = _curTeam.TeamID;
                        }
                    }

                    if (objProjectDDLs.lstProjectManagers != null && objProjectDDLs.lstProjectManagers.Count > 0)
                    {
                        _lstProjectManager = objProjectDDLs.lstProjectManagers.Where(x => x.AccountID == _objProfile.AccountID).ToList();
                        if (_lstProjectManager != null && _lstProjectManager.Count > 0)
                        {
                            ddlProjectManager.ItemsSource = _lstProjectManager;
                            _curProjectManager = _lstProjectManager.FirstOrDefault();
                            ddlProjectManager.SelectedItem = _curProjectManager;
                            _ProjectManagerID = Convert.ToString(_curProjectManager.UserID);
                        }
                    }


                    if (objProjectDDLs.lstProjectStatus != null && objProjectDDLs.lstProjectStatus.Count > 0)
                    {
                        _lstProjectStatus = objProjectDDLs.lstProjectStatus.Where(x => x.CompanyID == _objProfile.CompanyID).ToList();
                        if (_lstProjectStatus != null && _lstProjectStatus.Count > 0)
                        {
                            ddlProjectStatus.ItemsSource = _lstProjectStatus;
                            _curProjectStatus = _lstProjectStatus.FirstOrDefault();
                            ddlProjectStatus.SelectedItem = _curProjectStatus;
                            _ProjectStatusID = _curProjectStatus.ProjectStatusID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Specturm Administrator", "OK");
            }
        }
        private async void OnProjectSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                ProjectDetailList item = (ProjectDetailList)e.SelectedItem;
                if (item != null)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Projects", new Spectrum.View.MasterPages.WorkSpaceSelection(_objProfile, _lstModules, SelModuleID)));
                    //await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Projects", new Spectrum.View.MasterPages.ProjectsTasksList(_objProfile, _lstModules, SelModuleID, Convert.ToInt32(item.ProjectID), Convert.ToInt32(item.NumberOfTask), false)));
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


        private async void CancelProject_Tapped(System.Object sender, System.EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Projects", new Spectrum.View.MasterPages.WorkSpaceSelection(_objProfile, _lstModules, SelModuleID)));
        }

        private async void SaveProject_Tapped(System.Object sender, System.EventArgs e)
        {
            try
            {
                bool isValid = true;
                if (string.IsNullOrEmpty(txtProjectName.Text))
                {
                    await DisplayAlert("Project Name Required", "Please enter Project Name", "Ok");
                    isValid = false;
                }
                if (string.IsNullOrEmpty(txtTaskPrefixKey.Text))
                {
                    await DisplayAlert("Task Prefix Key Required", "Please enter Project Prefix Key", "Ok");
                    isValid = false;
                }
                if (string.IsNullOrEmpty(txtTaskNumber.Text))
                {
                    await DisplayAlert("Next Task Number Required", "Please enter Next Task Number ", "Ok");
                    isValid = false;
                }
                if (isValid)
                {
                    using (UserDialogs.Instance.Loading("Creating Project..."))
                    {
                        ProjectModelMobile objProject = new ProjectModelMobile();

                        objProject.AccountID = _objProfile.AccountID;
                        objProject.isSpecialLogin = _objProfile.IsSpecialLogin;
                        objProject.WorkSpaceID = _objProfile.WorkspaceID;
                        objProject.CompanyID = _curCompany.CompanyID;
                        objProject.TeamID = _curTeam.TeamID;
                        objProject.ProjectName = txtProjectName.Text;
                        objProject.ProjectDescription = txtProjectDescription.Text;
                        objProject.ProjectTypeID = Convert.ToInt32(_curProjectType.ProjectTypeID);
                        objProject.ProjectTypeCategoryID = Convert.ToInt32(_curProjectType.ProjectypeCategoryID);
                        objProject.ProjectManagerID = Guid.Parse(_ProjectManagerID);
                        objProject.CreatedBy = _objProfile.UserID;
                        objProject.ProjectStatusID = Convert.ToInt32(_ProjectStatusID);
                        objProject.ProjectKey = txtTaskPrefixKey.Text;
                        objProject.NextTaskNumber = Convert.ToInt32(txtTaskNumber.Text);



                        ProjectManagementViewModel objProjectList = await _objService.Save_ProjectDetails(objProject);
                        if (objProjectList != null)
                        {
                            if (objProjectList.ProjectListProfile != null && objProjectList.ProjectListProfile.ProjectID > 0)
                            {
                                await DisplayAlert("Success", "Project has been created successfully", "Ok");
                                await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Projects", new Spectrum.View.MasterPages.WorkSpaceSelection(_objProfile, _lstModules, SelModuleID)));
                            }
                            else
                            {
                                if (objProjectList.CustomMessage != null)
                                {
                                    await DisplayAlert(objProjectList.CustomMessage.CaptionText, objProjectList.CustomMessage.MessageDetailText, "Ok");
                                    return;
                                }
                                await DisplayAlert("Failure", "There are some issues in creating project. Please contact administrator", "Ok");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Connection Error", "Cannot process request due to connection problem, Please try again later", "OK");
            }

        }

        private async void txtProjectName_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            try
            {
                var char1 = "";
                var char2 = "";
                var char3 = "";
                string SingleVal = "";
                var txt = sender as Entry;
                if (txt != null)
                {
                    if (!string.IsNullOrEmpty(txt.Text))
                    {
                        string[] split_value = txt.Text.Trim().Replace(",", " ").Split(' ');
                        if (split_value != null && split_value.Length > 0)
                        {
                            if (split_value.Length == 1)
                            {
                                SingleVal = split_value[0];
                                if (SingleVal.Length == 1)
                                {
                                    char1 = split_value[0].Substring(0);
                                    char2 = split_value[0].Substring(0);
                                    char3 = split_value[0].Substring(0);
                                }
                                if (SingleVal.Length == 2)
                                {
                                    char1 = split_value[0].Substring(0, 1);
                                    char2 = split_value[0].Substring(1, 1);
                                    char3 = split_value[0].Substring(0, 1);
                                }
                                if (SingleVal.Length >= 3)
                                {
                                    char1 = split_value[0].Substring(0, 1);
                                    char2 = split_value[0].Substring(1, 1);
                                    char3 = split_value[0].Substring(2, 1);
                                }
                            }
                            else if (split_value.Length == 2)
                            {
                                char1 = split_value[0].Substring(0, 1);
                                char2 = split_value[0].Substring(split_value[0].Length - 1);
                                char3 = split_value[1].Substring(0, 1);
                            }
                            else if (split_value.Length >= 3)
                            {
                                char1 = split_value[0].Substring(0, 1);
                                char2 = split_value[1].Substring(0, 1);
                                char3 = split_value[2].Substring(0, 1);
                            }
                        }
                        txtTaskPrefixKey.Text = (char1 + char2 + char3).ToUpper();
                    }
                    else
                    {
                        txtTaskPrefixKey.Text = "";
                    }
                }
                else
                {
                    txtTaskPrefixKey.Text = "";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Connection Error", "Cannot process request due to connection problem, Please try again later", "OK");
            }
        }

        private async void ddlProjectManager_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                Picker picker = sender as Picker;
                _curProjectManager = picker.SelectedItem as UserProfile;
                _ProjectManagerID = Convert.ToString(_curProjectManager.UserID);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Specturm Administrator", "OK");
            }
        }

        private async void ddlProjectStatus_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                Picker picker = sender as Picker;
                _curProjectStatus = picker.SelectedItem as ProjectStatusProfile;
                _ProjectStatusID = _curProjectStatus.ProjectStatusID;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Specturm Administrator", "OK");
            }
        }

        private async void ddlTeam_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                Picker picker = sender as Picker;
                _curTeam = picker.SelectedItem as TeamProfile;
                _TeamID = _curTeam.TeamID;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Specturm Administrator", "OK");
            }
        }

        private async void ddlCompany_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                Picker picker = sender as Picker;
                _curCompany = picker.SelectedItem as CompanyProfile;
                _companyID = Convert.ToString(_curCompany.CompanyID);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Specturm Administrator", "OK");
            }
        }

        private async void ddlProjectType_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                Picker picker = sender as Picker;
                _curProjectType = picker.SelectedItem as ProjectTypeDetailProfile;
                _ProjectTypeCategoryID = _curProjectType.ProjectypeCategoryID;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Specturm Administrator", "OK");
            }
        }
    }

}
