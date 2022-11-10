using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Acr.UserDialogs;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Spectrum.Model.ModelDataTypes.ProjectManagement;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Spectrum.Model.ModelDataTypes.ProjectManagement;
using Spectrum.Service;
using Spectrum.Service;
using Xamarin.Forms;
using Spectrum.Model.Chat;

namespace Spectrum.View.MasterPages.Chatting
{
    public partial class ChatDashbord : ContentPage
    {
        private List<MobileWorkspaceItem> _lstWorkSpaces { get; set; }
        MobileWorkspaceItem _curWorkSpace { get; set; }
        public MobileWorkSpaceViewModel _objWorkSpaceVM { get; set; }



        public List<ModuleMainPanel> _lstModules { get; set; }

        public ProjectTaskService _objService = new ProjectTaskService();
        public ChatServices _objChatService = new ChatServices();
        public UserProfileMob _objProfile { get; set; }

        List<MobileTeamProfile> lstTeams { get; set; }
        public List<MobileProjectListProfile> lstProject { get; set; }
        public List<ChatUserModel> lstUsers { get; set; }

        List<ChatDashboardSectionModel> lstSections { get; set; }

        public int SelModuleID { get; set; }
        public int SelSectionID { get; set; }
        int TextFontSize { get; set; }
        int ImageSize { get; set; }
        int RowHeightSize { get; set; }
        int FirstGridHeight { get; set; }
        int FirstGridRowHeieght { get; set; }
        public ChatDashbord()
        {
            InitializeComponent();
            Thread.Sleep(3000);
            SetPageDesign();
            BindWorkSpaces();

        }
        public ChatDashbord(UserProfileMob ObjUserProfile, List<ModuleMainPanel> lstModules, int selModule)
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
            BindWorkSpaces();
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

        private async void BindWorkSpaces()
        {
            try
            {
                //using (UserDialogs.Instance.Loading("Loading..."))
                //{
                _objWorkSpaceVM = await _objChatService.Fetch_WorkspaceList_Chat(Convert.ToString(_objProfile.AccountID), Convert.ToString(_objProfile.UserID), _objProfile.WorkspaceID, 3);
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
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Spectrum Administrator", "OK");
            }
        }
        private async void DDLWorkSpaces_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                Picker picker = sender as Picker;
                _curWorkSpace = picker.SelectedItem as MobileWorkspaceItem;
                _objProfile.WorkspaceID = _curWorkSpace.WorkSpaceID;
                BindChatSections(0);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Spectrum Administrator", "OK");
            }
        }

        #region Functions for Chat Sections
        private async void BindChatSections(int sectionIndex)
        {
            try
            {
                Thread.Sleep(500);
                StackLayout Section1 = null;
                ActivityIndicator actind = null;
            RemoveStackChildLevel1:
                if (StkMainStack.Children.Count > 1)
                {
                    StkMainStack.Children.RemoveAt(1);
                    goto RemoveStackChildLevel1;
                }
                lstSections = await _objChatService.GetChatDashboardSection(Convert.ToString(_objProfile.AccountID), Convert.ToString(_objProfile.CompanyID), Convert.ToString(_objProfile.UserID), SelModuleID, _objProfile.WorkspaceID);
                if (lstSections != null && lstSections.Count > 0)
                {
                    for (int i = 0; i < lstSections.Count; i++)
                    {
                        ChatDashboardSectionModel curSection = lstSections[i];
                        StackLayout stkSection = new StackLayout
                        {
                            BackgroundColor = Color.Transparent,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.StartAndExpand,
                            MinimumHeightRequest = RowHeightSize,
                            Margin = new Thickness(0, 15, 0, 0),
                            ClassId = curSection.SectionID.ToString() + "_" + i.ToString()
                        };
                        stkSection.@class = new List<string> { "Sections", curSection.SectionID.ToString(), curSection.SectionName.ToString(), curSection.WorkSpaceID.ToString(), curSection.AccountID.ToString(), curSection.CompanyID.ToString() };
                        Grid grdSection = new Grid
                        {
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            BackgroundColor = Color.Transparent,
                        };
                        grdSection.@class = new List<string> { "Sections", curSection.SectionID.ToString(), curSection.SectionName.ToString(), curSection.WorkSpaceID.ToString(), curSection.AccountID.ToString(), curSection.CompanyID.ToString() };
                        grdSection.RowDefinitions.Add(new RowDefinition { Height = new GridLength(RowHeightSize, GridUnitType.Absolute) });
                        grdSection.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ImageSize, GridUnitType.Absolute) });
                        grdSection.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Star) });
                        Image LeftPartIcon = new Image
                        {
                            Source = i == sectionIndex ? "folder_icon_blue" : "folder_icon",
                            HeightRequest = ImageSize,
                            WidthRequest = ImageSize,
                            HorizontalOptions = LayoutOptions.Start
                        };
                        LeftPartIcon.@class = new List<string> { "Sections", curSection.SectionID.ToString(), curSection.SectionName.ToString(), curSection.WorkSpaceID.ToString(), curSection.AccountID.ToString(), curSection.CompanyID.ToString() };

                        Label lblSectionName = new Label
                        {
                            Text = curSection.SectionDisplayName,
                            FontAttributes = FontAttributes.Bold,
                            FontSize = TextFontSize,
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Margin = new Thickness(0, 0, 0, 0),
                            LineBreakMode = LineBreakMode.TailTruncation
                        };
                        lblSectionName.@class = new List<string> { "Sections", curSection.SectionID.ToString(), curSection.SectionName.ToString(), curSection.WorkSpaceID.ToString(), curSection.AccountID.ToString(), curSection.CompanyID.ToString() };
                        var partStacktapGestureRecognizer = new TapGestureRecognizer();
                        partStacktapGestureRecognizer.Tapped += (s, e) =>
                        {
                            SectionTapped(s, e);
                        };
                        stkSection.GestureRecognizers.Add(partStacktapGestureRecognizer);
                        grdSection.Children.Add(LeftPartIcon, 0, 0);
                        grdSection.Children.Add(lblSectionName, 1, 0);
                        stkSection.Children.Add(grdSection);

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
                        stkSection.Children.Add(actInProgress);
                        StkMainStack.Children.Add(stkSection);
                        //frmLoading.IsVisible = false;
                        if (i == sectionIndex)
                        {
                            Section1 = stkSection;
                            actind = actInProgress;
                        }
                    }
                    activityIndicator.IsVisible = false;

                    //BindProjects(Convert.ToString(lstTeams[teamindex].TeamID), Team1, null);
                    BindSectionData(Convert.ToString(lstSections[sectionIndex].SectionID), Section1, null);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", "Something went wrong. Please contact Spectrum Administrator", "OK");
            }
        }
        private async void SectionTapped(object sender, EventArgs e)
        {
            ActivityIndicator actSection = null;
            try
            {
                StackLayout stk = sender as StackLayout;
                if (stk != null)
                {
                    var SectionID = stk.ClassId.Split('_')[0];
                    int SectionIndex = Convert.ToInt32(stk.ClassId.Split('_')[1]);

                    Grid grd = stk.Children[0] as Grid;
                    actSection = stk.Children[1] as ActivityIndicator;
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
                            BindSectionData(SectionID, stk, actSection);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                actSection.IsVisible = false;
                throw ex;
            }
        }
        private async void BindSectionData(string SectionID, StackLayout stk, ActivityIndicator actProjects)
        {
            SelSectionID = Convert.ToInt32(SectionID);
            if (SectionID == "1")
            {
                lstTeams = _objWorkSpaceVM.lstTeams.Where(x => x.WorkScpaceID == _objProfile.WorkspaceID).ToList();
                BindTeamDetails(SectionID, stk, actProjects);
            }
            else if (SectionID == "2")
            {
                lstProject = new List<MobileProjectListProfile>();
                for (int x = 0; x < lstTeams.Count; x++)
                {
                    if (lstTeams[x] != null && lstTeams[x].lstProject != null && lstTeams[x].lstProject.Count > 0)
                    {
                        for (int y = 0; y < lstTeams[x].lstProject.Count; y++)
                        {
                            lstProject.Add(lstTeams[x].lstProject[y]);
                        }
                    }
                }

                BindProjectDetails(SectionID, stk, actProjects);
            }
            else if (SectionID == "3")
            {

                if (lstUsers == null && lstUsers.Count <= 0)
                {
                    lstUsers = await _objChatService.GetUsersList_Workspace(Convert.ToString(_objProfile.AccountID), SelModuleID, Convert.ToString(_objProfile.UserID), _objProfile.WorkspaceID);
                }

                BindUserDetails(SectionID, stk, actProjects);
            }
        }

        #endregion

        private async void BindTeamDetails(string SectionID, StackLayout stk, ActivityIndicator actProjects)
        {

            try
            {
                //MobileTeamProfile _curTeam = lstTeams.Where(x => x.TeamID == Convert.ToInt64(teamID)).FirstOrDefault();
                //List<MobileProjectListProfile> lstProjects = _curTeam.lstProject.Where(x => x.TeamID == Convert.ToInt64(teamID)).ToList();
                if (lstTeams != null && lstTeams.Count > 0)
                {
                    for (int i = 0; i < lstTeams.Count; i++)
                    {
                        MobileTeamProfile curTeam = lstTeams[i];
                        StackLayout stkTeam = new StackLayout
                        {
                            BackgroundColor = Color.Transparent,
                            MinimumHeightRequest = RowHeightSize,
                            Margin = new Thickness(35, 15, 0, 10),
                            ClassId = curTeam.TeamID.ToString() + "_" + i.ToString()
                        };
                        Grid grdTeam = new Grid
                        {
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            BackgroundColor = Color.Transparent,
                        };
                        grdTeam.RowDefinitions.Add(new RowDefinition { Height = new GridLength(RowHeightSize, GridUnitType.Absolute) });
                        grdTeam.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ImageSize, GridUnitType.Absolute) });
                        //  grdProject.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });
                        grdTeam.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40, GridUnitType.Star) });
                        grdTeam.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });
                        grdTeam.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Absolute) });
                        Image LeftPartIcon = new Image
                        {
                            Source = "team_folder_icon.png",
                            HeightRequest = 20,
                            WidthRequest = 20,
                            HorizontalOptions = LayoutOptions.Start
                        };
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
                        var partStacktapGestureRecognizer = new TapGestureRecognizer();
                        partStacktapGestureRecognizer.Tapped += (s, e) =>
                        {
                            TeamTapped(s, e);
                        };
                        stkTeam.GestureRecognizers.Add(partStacktapGestureRecognizer);
                        grdTeam.Children.Add(LeftPartIcon, 0, 0);
                        grdTeam.Children.Add(lblTeamName, 1, 0);
                        //grdTeam.Children.Add(frmTask, 2, 0);
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
                        stk.Children.Add(stkTeam);
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
                                BindTeamDetails(Convert.ToString(SelSectionID), stk, actTeam);
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


            //  BindWorkSpaces();
        }

        private async void BindProjectDetails(string teamID, StackLayout stk, ActivityIndicator actProjects)
        {
            try
            {

                if (lstProject != null && lstProject.Count > 0)
                {
                    for (int i = 0; i < lstProject.Count; i++)
                    {
                        MobileProjectListProfile curProjects = lstProject[i];
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
                                await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objProfile, _lstModules, "Chat", new Spectrum.View.MasterPages.Chatting.ChatDashbord(_objProfile, _lstModules, SelModuleID)));
                            }
                            else
                            {
                            RemoveStackChildrenLevel2:
                                if (stk.Children.Count > 2)
                                {
                                    stk.Children.RemoveAt(2);
                                    goto RemoveStackChildrenLevel2;
                                }
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



        private async void BindUserDetails(string SectionID, StackLayout stk, ActivityIndicator actProjects)
        {

            try
            {
                if (lstUsers != null && lstUsers.Count > 0)
                {
                    for (int i = 0; i < lstUsers.Count; i++)
                    {
                        ChatUserModel curUser = lstUsers[i];
                        StackLayout stkUser = new StackLayout
                        {
                            BackgroundColor = Color.Transparent,
                            MinimumHeightRequest = RowHeightSize,
                            Margin = new Thickness(35, 15, 0, 10),
                            ClassId = curUser.userID.ToString() + "_" + i.ToString()
                        };
                        Grid grnUser = new Grid
                        {
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            BackgroundColor = Color.Transparent,
                        };
                        grnUser.RowDefinitions.Add(new RowDefinition { Height = new GridLength(RowHeightSize, GridUnitType.Absolute) });
                        grnUser.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ImageSize, GridUnitType.Absolute) });
                        //  grdProject.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });
                        grnUser.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40, GridUnitType.Star) });
                        grnUser.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });
                        grnUser.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Absolute) });
                        Image LeftPartIcon = new Image
                        {
                            Source = "user_folder",
                            HeightRequest = 20,
                            WidthRequest = 20,
                            HorizontalOptions = LayoutOptions.Start
                        };
                        Label lblUserName = new Label
                        {
                            Text = curUser.userName,
                            FontAttributes = FontAttributes.Bold,
                            FontSize = TextFontSize,
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Margin = new Thickness(0, 0, 0, 0),
                            LineBreakMode = LineBreakMode.TailTruncation
                        };

                        var partStacktapGestureRecognizer = new TapGestureRecognizer();
                        partStacktapGestureRecognizer.Tapped += (s, e) =>
                        {
                            UserTapped(s, e);
                        };
                        GrdHeader.GestureRecognizers.Add(partStacktapGestureRecognizer);
                        grnUser.Children.Add(LeftPartIcon, 0, 0);
                        grnUser.Children.Add(lblUserName, 1, 0);
                        //grdTeam.Children.Add(frmTask, 2, 0);
                        stkUser.Children.Add(grnUser);
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
                        stkUser.Children.Add(actInProgress);
                        stk.Children.Add(stkUser);
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

        private async void UserTapped(object sender, EventArgs e)
        {

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
