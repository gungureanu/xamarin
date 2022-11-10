using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Spectrum.APISettings;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Service;
using Newtonsoft.Json;
using Xamarin.Forms;

using System.Threading;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;

namespace Spectrum
{
    public partial class CheckLogin : ContentPage
    {
        public CheckLogin()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);

            DoLogin("", "");
        }

        public CheckLogin(string EmailAddress, string Password)
        {
            InitializeComponent();
            //stkProgressBar.WidthRequest = 220;
            //Thread.Sleep(500);
            DoLogin(EmailAddress, Password);

        }

        private async void DoLogin(string EmailAddress, string Password)
        {
            try
            {
                //stkProgressBar.WidthRequest = 220;
                if (string.IsNullOrEmpty(EmailAddress) || string.IsNullOrEmpty(Password))
                {
                    //stkProgressBar.WidthRequest = (double)Application.Current.MainPage.Width - (20);
                    //                    Thread.Sleep(500);
                    Navigation.InsertPageBefore(new Welcome(), this);
                    await Application.Current.MainPage.Navigation.PopAsync().ConfigureAwait(false);
                }
                else
                {
                    Model.UserModel objuserModel = new Model.UserModel();
                    objuserModel.EmailAddress = EmailAddress.Trim();
                    objuserModel.Password = Password.ToString();
                    objuserModel.UserIPAddress = DependencyService.Get<IIPAddressManager>().GetIPAddress();
                    UserProfileMob objProfile = new UserProfileMob();
                    string baseURL = APIConfig.Get_API_BaseURL() + "api/AppLogin";
                    var json = JsonConvert.SerializeObject(objuserModel);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpClient _client = new HttpClient();
                    var task = await _client.PostAsync(baseURL, content);
                    if (task.IsSuccessStatusCode)
                    {
                        //stkProgressBar.WidthRequest = (double)Application.Current.MainPage.Width / 2 - (20);
                        //    stkProgressBar.WidthRequest = 300;
                        var responsecontent = await task.Content.ReadAsStringAsync();
                        objProfile = JsonConvert.DeserializeObject<UserProfileMob>(responsecontent);
                    }
                    if (objProfile != null)
                    {
                        if (objProfile.UserExists.ToLower() == "trialrunning" || objProfile.UserExists.ToLower() == "success")
                        {
                            Application.Current.Properties["WebToken"] = Convert.ToString(objProfile.UserWebToken);
                            Application.Current.Properties["UserEmail"] = Convert.ToString(objProfile.EmailAddress);
                            Application.Current.Properties["Password"] = Password;
                            Application.Current.Properties["UserName"] = Convert.ToString(objProfile.UserName);
                            Application.Current.Properties["AccountID"] = Convert.ToString(objProfile.AccountID);
                            Application.Current.Properties["UserID"] = Convert.ToString(objProfile.UserID);
                            Application.Current.Properties["CompanyID"] = Convert.ToString(objProfile.PrimaryCompanyID);
                            Application.Current.Properties["LanguageID"] = Convert.ToString(6);

                            LeftPanelService objLeftservice = new LeftPanelService();
                            //          stkProgressBar.WidthRequest = 450;
                            List<ModuleMainPanel> lstModules = await objLeftservice.GetModuleNamesAsync(objProfile.AccountID.ToString(), objProfile.PlanID, objProfile.RoleIDList, objProfile.IsSpecialLogin, objProfile.IsCommandAdmin, 3, objProfile.UserID.ToString(), objProfile.WorkspaceID);

                            Navigation.InsertPageBefore(new Spectrum.View.MasterPages.HomeMasterDetailPage(objProfile, lstModules, "Project Tasks", null), this);
                            await Application.Current.MainPage.Navigation.PopAsync().ConfigureAwait(false);
                        }
                        else
                        {
                            //      stkProgressBar.WidthRequest = 450;
                            Navigation.InsertPageBefore(new Welcome(), this);
                            await Application.Current.MainPage.Navigation.PopAsync().ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        //stkProgressBar.WidthRequest = 450;
                        Navigation.InsertPageBefore(new Welcome(), this);
                        await Application.Current.MainPage.Navigation.PopAsync().ConfigureAwait(false);
                    }

                }
            }
            catch (Exception ex)
            {
                //stkProgressBar.WidthRequest = 450;
                Navigation.InsertPageBefore(new Welcome(), this);
                await Application.Current.MainPage.Navigation.PopAsync().ConfigureAwait(false);
            }
        }
    }
}
