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
//using Xamarin.Forms.Markup;

namespace Spectrum.View.MasterPages
{
    public partial class ProjectsList : ContentPage
    {
        public UserProfileMob _objProfile { get; set; }
        public List<ModuleMainPanel> _lstModules { get; set; }
        public int SelModuleID { get; set; }
        private List<WorkspaceItem> _lstWorkSpaces { get; set; }
        private WorkspaceItem _curWorkSpace { get; set; }
        public ProjectTaskService _objService = new ProjectTaskService();
        List<ProjectDetailList> Items { get; set; }
        public ProjectsList()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }

        public ProjectsList(UserProfileMob ObjUserProfile, List<ModuleMainPanel> lstModules, int selModule)
        {
            InitializeComponent();
            try
            {
                NavigationPage.SetHasNavigationBar(this, false);
                NavigationPage.SetHasBackButton(this, false);
                _objProfile = ObjUserProfile;
                _lstModules = lstModules;
                SelModuleID = selModule;
                //ScrProjectPanel.HeightRequest = (double)Application.Current.MainPage.Height - (80 + 78);
                ScrProjectPanel.HeightRequest = (double)Application.Current.MainPage.Height - (110);
                BindWorkSpaces();
                BindProjecDetail();
            }
            catch (Exception ex)
            {
                DisplayAlert("Oops", "Something went wrong. Please contact Specturm Administrator", "Ok");
            }
        }
        private async void BindProjecDetail()
        {
            try
            {
                using (UserDialogs.Instance.Loading("Loading"))
                {
                    Items = await _objService.GetProjectListAsync(_objProfile.UserID.ToString(), _objProfile.CompanyID.ToString(), SelModuleID, _objProfile.AccountID.ToString(), _objProfile.RoleIDList, _objProfile.IsSpecialLogin, _objProfile.WorkspaceID, _objProfile.IsCommandAdmin, _objProfile.LanguageID);
                    if (Items != null && Items.Count > 0)
                    {
                    RemoveProjectData:
                        if (StkProjectList.Children.Count > 0)
                        {
                            StkProjectList.Children.RemoveAt(0);
                            goto RemoveProjectData;
                        }
                        stkNoProjects.IsVisible = false;
                        ScrProjectPanel.IsVisible = true;
                        for (int x = 0; x < Items.Count; x++)
                        {
                            //for (int y = 0; y < 20; y++)
                            //{
                            var frmProject = new Frame
                            {
                                Padding = new Thickness(0),
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                VerticalOptions = LayoutOptions.Start,
                                HeightRequest = 80,
                                BackgroundColor = Color.FromHex("#f2a600"),
                                Margin = new Thickness(10, 5, 10, 0),
                                CornerRadius = 8,
                                ClassId = Items[x].ProjectID.ToString()
                            };
                            var curProjectGrid = new Grid
                            {
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                VerticalOptions = LayoutOptions.CenterAndExpand,
                            };

                            curProjectGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) });
                            curProjectGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50, GridUnitType.Absolute) });
                            curProjectGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Star) });

                            var innerStacktapGestureRecognizer = new TapGestureRecognizer();
                            innerStacktapGestureRecognizer.Tapped += (s, e) =>
                            {
                                ProjectTapped(s, e);
                            };
                            frmProject.GestureRecognizers.Add(innerStacktapGestureRecognizer);
                            var imgprojectIcon = new Image
                            {
                                Source = "puzzle_piece",
                                HeightRequest = 60,
                                WidthRequest = 60,
                                VerticalOptions = LayoutOptions.CenterAndExpand,
                                HorizontalOptions = LayoutOptions.CenterAndExpand
                            };
                            curProjectGrid.Children.Add(imgprojectIcon, 0, 0);
                            Label lblProjectName = new Label
                            {
                                Text = Items[x].ProjectName,
                                VerticalOptions = LayoutOptions.CenterAndExpand,
                                HorizontalOptions = LayoutOptions.StartAndExpand,
                                TextColor = Color.FromHex("#FFFFFF"),
                                FontAttributes = FontAttributes.Bold,
                                FontSize = 26,
                                HorizontalTextAlignment = TextAlignment.Start,
                                VerticalTextAlignment = TextAlignment.Center,
                                LineBreakMode = LineBreakMode.TailTruncation,
                                HeightRequest = 80
                            };
                            curProjectGrid.Children.Add(lblProjectName, 1, 0);
                            frmProject.Content = curProjectGrid;
                            StkProjectList.Children.Add(frmProject);
                            // }
                        }
                    }
                    else
                    {
                        ScrProjectPanel.IsVisible = false;
                        stkNoProjects.IsVisible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Specturm Administrator", "OK");
                return;
            }
        }
        public async void ProjectTapped(object sender, EventArgs e)
        {
            try
            {
                var project = sender as Frame;
                string ProjectID = project.ClassId;
                if (!string.IsNullOrEmpty(ProjectID))
                {
                    ProjectDetailList _item = Items.Where(x => x.ProjectID == Convert.ToInt64(ProjectID)).FirstOrDefault();
                    await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Projects", new Spectrum.View.MasterPages.ProjectsTasksList(_objProfile, _lstModules, SelModuleID, Convert.ToInt32(ProjectID), Convert.ToInt32(_item.NumberOfTask), false)));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Connection Error", "Cannot process request due to connection problem, Please try again later", "OK");
            }
        }
        private async void OnProjectSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                ProjectDetailList item = (ProjectDetailList)e.SelectedItem;
                if (item != null)
                {
                    //await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.ProjectsTasksList(_objProfile, _lstModules, SelModuleID, Convert.ToInt32(item.ProjectID), false));
                    await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Projects", new Spectrum.View.MasterPages.ProjectsTasksList(_objProfile, _lstModules, SelModuleID, Convert.ToInt32(item.ProjectID), Convert.ToInt32(item.NumberOfTask), false)));
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

        private async void New_Project_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {

                await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Projects", new Spectrum.View.MasterPages.NewProject(_objProfile, _lstModules, SelModuleID)));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Connection Error", "Cannot process request due to connection problem, Please try again later", "OK");
            }
        }

        private void CreateNewProject_Tapped(System.Object sender, System.EventArgs e)
        {
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
        }

        private async void DDLWorkSpaces_Tapped(System.Object sender, System.EventArgs e)
        {
            DDLWorkSpaces.Focus();
        }

        private async void DDLWorkSpaces_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                Picker picker = sender as Picker;
                _curWorkSpace = picker.SelectedItem as WorkspaceItem;
                _objProfile.WorkspaceID = _curWorkSpace.WorkSpaceID;
                // activityIndicator.IsVisible = true;
                BindProjecDetail();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Specturm Administrator", "OK");
            }
        }

        private async void BindWorkSpaces()
        {
            try
            {
                _lstWorkSpaces = await _objService.Fetch_WorkspaceList(Convert.ToString(_objProfile.AccountID), Convert.ToString(_objProfile.UserID), _objProfile.WorkspaceID, 3);
                if (_lstWorkSpaces != null && _lstWorkSpaces.Count > 0)
                {
                    DDLWorkSpaces.ItemsSource = _lstWorkSpaces.OrderBy(x => x.WorkSpaceID).ToList();
                    _curWorkSpace = _lstWorkSpaces.Where(x => x.WorkSpaceID == _objProfile.WorkspaceID).FirstOrDefault();
                    DDLWorkSpaces.SelectedItem = _curWorkSpace;
                    BindProjecDetail();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Specturm Administrator", "OK");
            }
        }
    }

}
