
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Spectrum.Model.ModelDataTypes.ProjectManagement;
using Spectrum.Service;
using Xamarin.Forms;

namespace Spectrum.View.MasterPages
{
    public partial class WorkSpaceSelection : ContentPage
    {
        private List<MobileWorkspaceItem> _lstWorkSpaces { get; set; }
        MobileWorkspaceItem _curWorkSpace { get; set; }
        public MobileWorkSpaceViewModel _objWorkSpaceVM { get; set; }
        public List<ModuleMainPanel> _lstModules { get; set; }

        public ProjectTaskService _objService = new ProjectTaskService();
        public UserProfileMob _objProfile { get; set; }

        List<MobileTeamProfile> lstTeams { get; set; }

        public int SelModuleID { get; set; }
        int TextFontSize { get; set; }
        int ImageSize { get; set; }
        int RowHeightSize { get; set; }
        int FirstGridHeight { get; set; }
        int FirstGridRowHeieght { get; set; }
        public WorkSpaceSelection()
        {
            InitializeComponent();
            Thread.Sleep(3000);
            SetPageDesign();
            //  BindWorkSpaces();
            BindWorkSpaces_New();
        }
        public  WorkSpaceSelection(UserProfileMob ObjUserProfile, List<ModuleMainPanel> lstModules, int selModule)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            _objProfile = ObjUserProfile;
            _lstModules = lstModules;
            SelModuleID = selModule;
            if (Device.Idiom == TargetIdiom.Phone)
            {
                TextFontSize = 16;
                ImageSize = 40;
                RowHeightSize = 40;
            }
            else
            {
                TextFontSize = 24;
                ImageSize = 50;
                RowHeightSize = 50;
            }
            SetPageDesign();
            Thread.Sleep(3000);
            //  BindWorkSpaces();
            BindWorkSpaces_New();
        }
        private async void SetPageDesign()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                stkMainHeader.HeightRequest = 60;
                stkMainHeader.Padding = new Thickness(0, 0, 0, 0);
                GrdHeader.RowDefinitions[0].Height = 0;
                GrdHeader.RowDefinitions[1].Height = 60;
                GrdHeader.Margin = new Thickness(0, 0, 30, 0);
            }
        }
        private async void BindWorkSpaces_New()
        {
            try
            {
                //using (UserDialogs.Instance.Loading("Loading..."))
                //{
                
                _objWorkSpaceVM = await _objService.Fetch_WorkspaceList_New(Convert.ToString(_objProfile.AccountID), Convert.ToString(_objProfile.UserID), _objProfile.WorkspaceID, 3);
                Thread.Sleep(3000);
                if (_objWorkSpaceVM != null)
                {
                    if (_objWorkSpaceVM.lstWorkSpaces != null && _objWorkSpaceVM.lstWorkSpaces.Count > 0)
                    {
                        _lstWorkSpaces = _objWorkSpaceVM.lstWorkSpaces;
                        for (int x = 0; x < _lstWorkSpaces.Count; x++)
                        {
                            _lstWorkSpaces[x].WorkspaceDescription = "Workspace: " + _lstWorkSpaces[x].WorkspaceName;
                        }
                        DDLWorkSpaces.ItemsSource = _lstWorkSpaces.OrderBy(x => x.WorkSpaceID).ToList();
                        _curWorkSpace = _lstWorkSpaces.Where(x => x.WorkSpaceID == _objProfile.WorkspaceID).FirstOrDefault();
                        DDLWorkSpaces.SelectedItem = _curWorkSpace;
                    }
                }
                //}
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Spectrum Administrator", "OK");
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

        private async void DDLWorkSpaces_Tapped(System.Object sender, System.EventArgs e)
        {
            DDLWorkSpaces.Focus();
        }

        private async void DDLWorkSpaces_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                Picker picker = sender as Picker;
                _curWorkSpace = picker.SelectedItem as MobileWorkspaceItem;
                _objProfile.WorkspaceID = _curWorkSpace.WorkSpaceID;
                //activityIndicator.IsVisible = true;

                BindTeamsDetail(0);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Spectrum Administrator", "OK");
            }
        }

        private async void BindTeamsDetail(int teamindex)
        {
            try
            {
                //Thread.Sleep(2500);
                Thread.Sleep(500);
                //using (UserDialogs.Instance.Loading("Loading..."))
                //{
                StackLayout Team1 = null;
                ActivityIndicator actind = null;
            RemoveStackChildLevel1:
                if (StkMainStack.Children.Count > 1)
                {
                    StkMainStack.Children.RemoveAt(1);
                    goto RemoveStackChildLevel1;
                }
                lstTeams = _objWorkSpaceVM.lstTeams.Where(x => x.WorkScpaceID == _curWorkSpace.WorkSpaceID).ToList();
                //lstTeams = await _objService.Fetch_TeamProject(Convert.ToString(_objProfile.UserID), Convert.ToString(_objProfile.CompanyID), Convert.ToString(_objProfile.AccountID), SelModuleID, _curWorkSpace.WorkSpaceID);
                if (lstTeams != null && lstTeams.Count > 0)
                {
                    for (int i = 0; i < lstTeams.Count; i++)
                    {
                        MobileTeamProfile curTeam = lstTeams[i];
                        StackLayout stkTeam = new StackLayout
                        {
                            BackgroundColor = Color.Transparent,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.StartAndExpand,
                            MinimumHeightRequest = RowHeightSize,
                            Margin = new Thickness(0, 15, 0, 0),
                            ClassId = curTeam.TeamID.ToString() + "_" + i.ToString()
                        };
                        stkTeam.@class = new List<string> { "Teams", curTeam.TeamID.ToString(), curTeam.TeamName.ToString(), curTeam.WorkScpaceID.ToString() };
                        Grid grdTeam = new Grid
                        {
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            BackgroundColor = Color.Transparent,
                        };
                        grdTeam.@class = new List<string> { "Teams", curTeam.TeamID.ToString(), curTeam.TeamName.ToString(), curTeam.WorkScpaceID.ToString() };
                        grdTeam.RowDefinitions.Add(new RowDefinition { Height = new GridLength(RowHeightSize, GridUnitType.Absolute) });
                        grdTeam.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ImageSize, GridUnitType.Absolute) });
                        //grdTeam.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });
                        grdTeam.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Star) });
                        Image LeftPartIcon = new Image
                        {
                            Source = i == teamindex ? "folder_icon_blue" : "folder_icon",
                            HeightRequest = ImageSize,
                            WidthRequest = ImageSize,
                            HorizontalOptions = LayoutOptions.Start
                        };
                        LeftPartIcon.@class = new List<string> { "Teams", curTeam.TeamID.ToString(), curTeam.TeamName.ToString(), curTeam.WorkScpaceID.ToString() };
                        //Image MiddlePartIcon = new Image
                        //{
                        //    Source = "open_book_grey",
                        //    HeightRequest = ImageSize,
                        //    WidthRequest = ImageSize,
                        //    HorizontalOptions = LayoutOptions.Start
                        //};
                        // MiddlePartIcon.@class = new List<string> { "Teams", curTeam.TeamID.ToString(), curTeam.TeamName.ToString(), curTeam.WorkScpaceID.ToString(), curTeam.IsDefault.ToString() };
                        Label lblTeamName = new Label
                        {
                            Text = curTeam.TeamName,
                            FontAttributes = FontAttributes.Bold,
                            FontSize = TextFontSize,
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Margin = new Thickness(0, 0, 0, 0),
                            LineBreakMode = LineBreakMode.TailTruncation
                        };
                        lblTeamName.@class = new List<string> { "Teams", curTeam.TeamID.ToString(), curTeam.TeamName.ToString(), curTeam.WorkScpaceID.ToString() };
                        var partStacktapGestureRecognizer = new TapGestureRecognizer();
                        partStacktapGestureRecognizer.Tapped += (s, e) =>
                        {
                            TeamTapped(s, e);
                        };
                        stkTeam.GestureRecognizers.Add(partStacktapGestureRecognizer);
                        grdTeam.Children.Add(LeftPartIcon, 0, 0);
                        // grdPart.Children.Add(MiddlePartIcon, 1, 0);
                        grdTeam.Children.Add(lblTeamName, 1, 0);
                        stkTeam.Children.Add(grdTeam);

                        ActivityIndicator actInProgress = new ActivityIndicator
                        {
                            Color = Color.Red,
                            HeightRequest = 30,
                            WidthRequest = 30,
                            IsRunning = true,
                            IsVisible = false,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        stkTeam.Children.Add(actInProgress);
                        //stkBook.@class = new List<string> { "books", curPart.sectionID.ToString(), curPart.bookName.ToString(), curPart.title.ToString(), curPart.displayOrder.ToString() };
                        //stkPart.Children.Add(stkBook);
                        StkMainStack.Children.Add(stkTeam);
                        //frmLoading.IsVisible = false;
                        if (i == teamindex)
                        {
                            Team1 = stkTeam;
                            actind = actInProgress;
                        }
                    }
                    activityIndicator.IsVisible = false;
                    // StackLayout stkTeam1 = StkMainStack.Children[1] as StackLayout;
                    BindProjects(Convert.ToString(lstTeams[teamindex].TeamID), Team1, null);
                    //}
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Spectrum Administrator", "OK");
            }
        }

        private async void TeamTapped(object sender, EventArgs e)
        {
            ActivityIndicator actTeam = null;
            try
            {
                StackLayout stk = sender as StackLayout;
                if (stk != null)
                {
                    var teamId = stk.ClassId.Split('_')[0];
                    int TeamIndex = Convert.ToInt32(stk.ClassId.Split('_')[1]);
                    Grid grd = stk.Children[0] as Grid;
                    // actTeam = stk.Children[1] as ActivityIndicator;
                    if (grd != null)
                    {
                        //actTeam.IsVisible = true;
                        Image img = grd.Children[0] as Image;
                        if (img != null)
                        {
                            if (img.Source.ToString().Replace("File: ", "") == "folder_icon")
                            {
                                img.Source = "folder_icon_blue";
                            RemoveStackChildLevel11:
                                if (stk.Children.Count > 2)
                                {
                                    stk.Children.RemoveAt(2);
                                    goto RemoveStackChildLevel11;
                                }
                                //frmLoading.IsVisible = true;
                                //  BindProjects(teamId, stk, actTeam);
                                BindTeamsDetail(TeamIndex);
                            }
                            else
                            {
                            RemoveStackChildLevel1:
                                if (stk.Children.Count > 2)
                                {
                                    stk.Children.RemoveAt(2);
                                    goto RemoveStackChildLevel1;
                                }
                                img.Source = "folder_icon";
                            }
                            //BindBooks(paraId);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                actTeam.IsVisible = false;
                throw ex;
            }
        }


        private async void BindProjects(string teamID, StackLayout stk, ActivityIndicator actProjects)
        {
            try
            {
                //using (UserDialogs.Instance.Loading("Loading..."))
                //{
                MobileTeamProfile _curTeam = lstTeams.Where(x => x.TeamID == Convert.ToInt64(teamID)).FirstOrDefault();
                List<MobileProjectListProfile> lstProjects = _curTeam.lstProject.Where(x => x.TeamID == Convert.ToInt64(teamID)).ToList();
                if (lstProjects != null && lstProjects.Count > 0)
                {
                    for (int i = 0; i < lstProjects.Count; i++)
                    {
                        MobileProjectListProfile curProjects = lstProjects[i];
                        StackLayout stkProject = new StackLayout
                        {
                            BackgroundColor = Color.Transparent,
                            MinimumHeightRequest = RowHeightSize,
                            Margin = new Thickness(35, 15, 0, 10),
                            ClassId = curProjects.ProjectID.ToString() + "_" + curProjects.TotalTask.ToString()
                        };
                        Grid grdProject = new Grid
                        {
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            BackgroundColor = Color.Transparent,
                        };
                        grdProject.RowDefinitions.Add(new RowDefinition { Height = new GridLength(RowHeightSize, GridUnitType.Absolute) });
                        grdProject.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ImageSize, GridUnitType.Absolute) });
                        //  grdProject.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });
                        grdProject.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40, GridUnitType.Star) });
                        grdProject.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });
                        grdProject.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Absolute) });
                        Image LeftPartIcon = new Image
                        {
                            Source = "project_icon",
                            HeightRequest = 20,
                            WidthRequest = 20,
                            HorizontalOptions = LayoutOptions.Start
                        };
                        // LeftPartIcon.@class = new List<string> { "Parts", curPart.sectionID.ToString(), curPart.bookName.ToString(), curPart.title.ToString(), curPart.displayOrder.ToString() };
                        //Image MiddlePartIcon = new Image
                        //{
                        //    Source = "project_icon",
                        //    HeightRequest = ImageSize,
                        //    WidthRequest = ImageSize,
                        //    HorizontalOptions = LayoutOptions.Start
                        //};
                        //   MiddlePartIcon.@class = new List<string> { "Parts", curPart.sectionID.ToString(), curPart.bookName.ToString(), curPart.title.ToString(), curPart.displayOrder.ToString() };
                        Label lblProjectName = new Label
                        {
                            Text = curProjects.ProjectName,
                            FontAttributes = FontAttributes.Bold,
                            FontSize = TextFontSize,
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Margin = new Thickness(0, 0, 0, 0),
                            LineBreakMode = LineBreakMode.TailTruncation
                        };
                        Frame frmTask = new Frame
                        {
                            Padding = 0,
                            HeightRequest = 50,
                            WidthRequest = 60,
                            HasShadow = false,
                            CornerRadius = 4,
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.EndAndExpand,
                            BackgroundColor = Color.FromHex("#f2a600")
                        };
                        Label lblTaskCount = new Label
                        {
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.White,
                            Text = curProjects.TaskCount.ToString()
                        };
                        frmTask.Content = lblTaskCount;
                        var partStacktapGestureRecognizer = new TapGestureRecognizer();
                        partStacktapGestureRecognizer.Tapped += (s, e) =>
                        {
                            ProjectTapped(s, e);
                        };
                        stkProject.GestureRecognizers.Add(partStacktapGestureRecognizer);
                        grdProject.Children.Add(LeftPartIcon, 0, 0);
                        grdProject.Children.Add(lblProjectName, 1, 0);
                        grdProject.Children.Add(frmTask, 2, 0);
                        stkProject.Children.Add(grdProject);
                        ActivityIndicator actInProgress = new ActivityIndicator
                        {
                            Color = Color.Red,
                            HeightRequest = 30,
                            WidthRequest = 30,
                            IsRunning = true,
                            IsVisible = false,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        stkProject.Children.Add(actInProgress);
                        stk.Children.Add(stkProject);
                    }
                }
                //   actProjects.IsVisible = false;
                //}
            }
            catch (Exception ex)
            {
                actProjects.IsVisible = false;
                //frmLoading.IsVisible = false;
                await DisplayAlert("Error", ex.Message.ToString(), "OK");
            }
        }

        private async void ProjectTapped(object sender, EventArgs e)
        {
            ActivityIndicator actProject = null;
            try
            {
                StackLayout stk = sender as StackLayout;
                if (stk != null)
                {
                    string[] ProjectVal = stk.ClassId.Split('_');
                    string ProjectID = ProjectVal[0].ToString();
                    string TotalTask = ProjectVal[1].ToString();
                    Grid grd = stk.Children[0] as Grid;
                    actProject = stk.Children[1] as ActivityIndicator;
                    if (grd != null)
                    {
                        Image img = grd.Children[0] as Image;
                        if (img != null)
                        {
                            //actProject.IsVisible = true;
                            if (img.Source.ToString().Replace("File: ", "") == "project_icon")
                            {
                                img.Source = "project_icon_blue";
                                await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Projects", new Spectrum.View.MasterPages.ProjectsTasksList(_objProfile, _lstModules, SelModuleID, Convert.ToInt32(ProjectID), Convert.ToInt32(TotalTask), false)));
                            }
                            else
                            {
                            RemoveStackChildrenLevel2:
                                if (stk.Children.Count > 2)
                                {
                                    stk.Children.RemoveAt(2);
                                    goto RemoveStackChildrenLevel2;
                                }
                                //else if (stk.Children.Count > 2)
                                //{
                                //    stk.Children.RemoveAt(1);
                                //}
                                img.Source = "project_icon";
                                actProject.IsVisible = false; ;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
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
    }
}

