using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Spectrum.APISettings;
using Spectrum.Dependencies;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Spectrum.Service;
using Spectrum.View.Updation;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace Spectrum
{
    public partial class MainPage : ContentPage
    {
        double MaxValue { get; set; }
        double progressMax { get; set; }
        double progress { get; set; }
        int counter { get; set; }
        bool isTimerRunning { get; set; }
        UserProfileMob objProfile { get; set; }
        AppUpdateService objservice { get; set; }
        List<ModuleMainPanel> lstModules { get; set; }
        public MainPage()
        {
            InitializeComponent();
            try
            {
                objservice = new AppUpdateService();
                string VersionNumber = DependencyService.Get<IAppVersionAndBuild>().GetVersionNumber();
                string BuildNumber = DependencyService.Get<IAppVersionAndBuild>().GetBuildNumber();
                CheckUpdates(VersionNumber, BuildNumber);

                if (Application.Current.Properties["UserEmail"] != null && Application.Current.Properties["Password"] != null)
                {
                    CheckLoginDetails(Convert.ToString(Application.Current.Properties["UserEmail"]), Convert.ToString(Application.Current.Properties["Password"]));
                    return;
                }
                Thread.Sleep(1000);
                MaxValue = 1;
                progressMax = 3;
                progress = 0;
                counter = 1;
                isTimerRunning = true;
                ShowProgress(0);
            }
            catch (Exception ex)
            {
                Thread.Sleep(1000);
                MaxValue = 1;
                progressMax = 3;
                progress = 0;
                counter = 1;
                isTimerRunning = true;
                ShowProgress(0);
            }
        }
        private async void CheckUpdates(string VersionNumber, string BuildNumber)
        {
            try
            {

                string retval = "";
                string AppName = APIConfig.Get_APP_Name();
                string AppPlatform = "";
                if (Device.RuntimePlatform == Device.iOS)
                {
                    AppPlatform = "IOS";
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    AppPlatform = "Android";
                }
                retval = await objservice.CheckAppUpdate(AppName, AppPlatform, BuildNumber, VersionNumber);
                if (!string.IsNullOrEmpty(retval))
                {
                    await Navigation.PushModalAsync(new CheckUpdate(AppName, AppPlatform, BuildNumber, VersionNumber), true);
                    await Application.Current.MainPage.Navigation.PopAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async void ShowProgress(int val)
        {
            try
            {
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    if (progress >= 1)
                    {
                        isTimerRunning = false;
                        //Navigation.PushAsync(new Views.ChapterDetails());
                        if (val == 1)
                        {
                            Application.Current.MainPage.Navigation.InsertPageBefore(new Spectrum.View.MasterPages.HomeMasterDetailPage(objProfile, lstModules, "Project Tasks", null), this);
                            Application.Current.MainPage.Navigation.PopAsync().ConfigureAwait(false);
                        }
                        else
                        {
                            Application.Current.MainPage.Navigation.InsertPageBefore(new Welcome(), this);
                            Application.Current.MainPage.Navigation.PopAsync().ConfigureAwait(false);
                        }

                    }
                    else
                    {
                        progress = MaxValue / progressMax;
                        progressMax--;
                        CtrlProgressBar.ProgressTo(progress, 600, Easing.Linear);
                        counter++;
                    }
                    return isTimerRunning;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void CheckLoginDetails(string Email, string Password)
        {
            try
            {
                Model.UserModel objuserModel = new Model.UserModel();
                objuserModel.EmailAddress = Email;
                objuserModel.Password = Password;
                objuserModel.UserIPAddress = DependencyService.Get<IIPAddressManager>().GetIPAddress();
                objProfile = new UserProfileMob();
                string baseURL = APIConfig.Get_API_BaseURL() + "api/AppLogin";
                var json = JsonConvert.SerializeObject(objuserModel);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient _client = new HttpClient();
                var task = await _client.PostAsync(baseURL, content);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    objProfile = JsonConvert.DeserializeObject<UserProfileMob>(responsecontent);
                }
                if (objProfile != null)
                {
                    if (objProfile.UserExists.ToLower() == "trialrunning" || objProfile.UserExists.ToLower() == "success")
                    {
                        objProfile.EmailAddress = Email;
                        Application.Current.Properties["WebToken"] = Convert.ToString(objProfile.UserWebToken);
                        Application.Current.Properties["UserEmail"] = Convert.ToString(objProfile.EmailAddress);
                        Application.Current.Properties["UserName"] = Convert.ToString(objProfile.UserName);
                        Application.Current.Properties["AccountID"] = Convert.ToString(objProfile.AccountID);
                        Application.Current.Properties["UserID"] = Convert.ToString(objProfile.UserID);
                        Application.Current.Properties["CompanyID"] = Convert.ToString(objProfile.PrimaryCompanyID);
                        Application.Current.Properties["LanguageID"] = Convert.ToString(6);

                        LeftPanelService objLeftservice = new LeftPanelService();
                        lstModules = await objLeftservice.GetModuleNamesAsync(objProfile.AccountID.ToString(), objProfile.PlanID, objProfile.RoleIDList, objProfile.IsSpecialLogin, objProfile.IsCommandAdmin, 3, objProfile.UserID.ToString(), objProfile.WorkspaceID);

                        Thread.Sleep(1000);
                        MaxValue = 1;
                        progressMax = 3;
                        progress = 0;
                        counter = 1;
                        isTimerRunning = true;
                        ShowProgress(1);

                        //await Application.Current.MainPage.Navigation.PushAsync(new View.MasterPages.HomeMasterDetailPage());
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        MaxValue = 1;
                        progressMax = 3;
                        progress = 0;
                        counter = 1;
                        isTimerRunning = true;
                        ShowProgress(0);
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                    MaxValue = 1;
                    progressMax = 3;
                    progress = 0;
                    counter = 1;
                    isTimerRunning = true;
                    ShowProgress(0);
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(1000);
                MaxValue = 1;
                progressMax = 3;
                progress = 0;
                counter = 1;
                isTimerRunning = true;
                ShowProgress(0);
            }
        }
    }
}
