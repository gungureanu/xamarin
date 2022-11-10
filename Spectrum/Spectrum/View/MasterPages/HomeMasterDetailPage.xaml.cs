
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Spectrum.Model;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Spectrum.Service;
using Spectrum.View.ForgotPassword;
using Spectrum.View.MasterDetailPages;
using Xamarin.Forms;

namespace Spectrum.View.MasterPages
{
    public partial class HomeMasterDetailPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public UserProfileMob _objUserProfile { get; set; }
        public ContentPage _objPage { get; set; }
       public List<ModuleMainPanel> _lstModules { get; set; }
        public HomeMasterDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            this.Title = "Project Tasks";
            //this.Title = "Projcet Tasks";
        }
        public HomeMasterDetailPage(UserProfileMob objUserProfile, List<ModuleMainPanel> lstModules, string PageTitle, ContentPage objPage)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            _objUserProfile = objUserProfile;
            _lstModules = lstModules;
            _objPage = objPage;
            Title = PageTitle;
            lblWorkSpaceNameMasterPage.Text = _objUserProfile.WorkspaceName;
            lblCompanyNameMasterPage.Text = _objUserProfile.CompanyName;
            lblUserNameMasterPage.Text = _objUserProfile.EmailAddress;
            LoadModules(_lstModules);
        }

      
        private async void LoadModules(List<ModuleMainPanel> lstModules)
        {
            try
            {

                MasterPageItem mainPage = new MasterPageItem();
                if (lstModules != null && lstModules.Count > 0)
                {
                    _lstModules = lstModules;
                    menuList = new List<MasterPageItem>();
                    mainPage = new MasterPageItem();

                    mainPage.Title = "projects";
                    mainPage.Icon = "project_icon.png";
                    mainPage.TargetType = new Spectrum.View.MasterPages.ProjectsList(_objUserProfile, _lstModules, 3);

                    menuList.Add(mainPage);
                    foreach (ModuleMainPanel module in _lstModules)
                    {
                        if (module != null)
                        {
                            if (!string.IsNullOrEmpty(module.ModuleName))
                            {

                                mainPage = new MasterPageItem();
                                mainPage.Title = module.ModuleName;
                                //mainPage.LeftMargin = "20, 10, 0, 10";
                                //mainPage.BackgrondColor = "Transparent";
                                switch (module.ModuleName.ToLower().ToString().Trim())
                                {
                                    case "chat":
                                        mainPage.Icon = "chat_icon.png";
                                        //mainPage.TargetType = new Spectrum.View.MasterPages.Chatting.ChatDashbord(_objUserProfile, _lstModules, 5);
                                        mainPage.TargetType = new Spectrum.View.MasterPages.Chatting.OnlineChatDashboard(_objUserProfile, _lstModules, 5);

                                        menuList.Add(mainPage);
                                        break;

                                    //case "My Task":
                                    //    mainPage.Icon = "project_icon.png";
                                    //    menuList.Add(mainPage);
                                    //    break;


                                    default:
                                        break;
                                }


                            }
                        }

                    }

                              menuList.Add(new MasterPageItem() { Title = "Logout", Icon = "logout_icon.png", ModuleID = 0, TargetType = new Logout() });
                    navigationDrawerList.ItemsSource = menuList;
                    if (_objPage != null)
                    {
                        Detail = new NavigationPage(_objPage)
                        {
                            //BarTextColor = Color.White,
                            //BarBackgroundColor = Color.FromHex("#eae8ea")
                        };
                    }
                    else
                    {
                        //Detail = new NavigationPage(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objUserProfile, _lstModules, "Projects", new Spectrum.View.MasterPages.Chatting.OnlineChatDashboard(_objUserProfile, _lstModules, 5)));
                        Detail = new NavigationPage(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objUserProfile, _lstModules, "Projects", new Spectrum.View.MasterPages.WorkSpaceSelection(_objUserProfile, _lstModules, 3)));
                        {
                            //BarTextColor = Color.White,
                            //BarBackgroundColor = Color.FromHex("#eae8ea")
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops!", ex.Message.ToString(), "OK");
            }

        }
        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {

                var item = (MasterPageItem)e.SelectedItem;
                if (item != null)
                {

                    if (item.Title.ToString().Trim().ToLower() == "logout")
                    {

                        var response = await DisplayAlert("Sign Out!", "Do you want to sign out from the application?", "Yes", "No");
                        if (response)
                        {
                            Application.Current.Properties["WebToken"] = null;
                            Application.Current.Properties["UserEmail"] = null;
                            Application.Current.Properties["UserName"] = null;
                            Application.Current.Properties["AccountID"] = null;
                            Application.Current.Properties["UserID"] = null;
                            Application.Current.Properties["CompanyID"] = null;
                            Application.Current.Properties["LanguageID"] = 0;
                            await Application.Current.SavePropertiesAsync();

                            await Navigation.PushAsync(new Spectrum.Login());
                        }
                    }
                    else if (item.Title.ToString().Trim().ToLower() == "change password")
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objUserProfile, _lstModules, "Projects", new Spectrum.View.ChangePassword.ChangePassword(_objUserProfile, _lstModules)));
                    }
               
                    else if (item.Title.ToString().Trim().ToLower() == "projects")
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objUserProfile, _lstModules, "Projects", new Spectrum.View.MasterPages.WorkSpaceSelection(_objUserProfile, _lstModules, 3)));
                    }

                    //else if (item.Title.ToString().Trim().ToLower() == "timesheets")
                    //{
                    //    await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objUserProfile, _lstModules, "Timesheets", new Spectrum.View.MasterPages.Timesheets.MyTimesSheets(_objUserProfile, _lstModules, 4)));
                    //}

                    else if (item.Title.ToString().Trim().ToLower() == "chat")
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objUserProfile, _lstModules, "OnlineChatDashboard", new Spectrum.View.MasterPages.Chatting.OnlineChatDashboard(_objUserProfile, _lstModules, 5)));
                    }
                    //else if (item.Title.ToString().Trim().ToLower() == "chat")
                    //{
                    //    //await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objUserProfile, _lstModules, "ChatDashboard", new Spectrum.View.MasterPages.Chatting.ChatDashbord(_objUserProfile, _lstModules, 5)));
                    //     await Application.Current.MainPage.Navigation.PushAsync(new Spectrum.View.MasterPages.HomeMasterDetailPage(_objUserProfile, _lstModules, "ChatDashboard", new Spectrum.View.MasterPages.Chatting.OnlineChatDashboard(_objUserProfile, _lstModules, 5)));
                    //}

                }
                IsPresented = false;
            }
            catch
            {
                await DisplayAlert("Connection Error", "Cannot process request due to connection problem, Please try again later", "OK");
            }

        }
    }
}
