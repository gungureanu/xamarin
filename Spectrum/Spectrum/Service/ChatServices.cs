using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Spectrum.Model;

using Spectrum.APISettings;
using Newtonsoft.Json;
using Xamarin.Forms;
using Spectrum.Model.Chat;
using Spectrum.Model.ModelDataTypes;

namespace Spectrum.Service
{
    public partial class ChatServices
    {
        public string token { get; set; }
        public ChatServices()
        {
            if (Application.Current.Properties["WebToken"] != null)
            {
                token = Convert.ToString(Application.Current.Properties["WebToken"]);
            }
            else
            {
                token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2MjU5MjQ5NzIsImlzcyI6ImtoYW1lbGlhLmNvbSIsImF1ZCI6ImtoYW1lbGlhLmNvbSJ9.dfrXxX-hniNoNDKChuzVKCHTVM76c5WN_ysuwxnHaZI";
            }
        }
        public async Task<List<ChatDashboardSectionModel>> GetChatDashboardSection(string AccountID, string CompanyID, string UserID, Int32 ModuleID, Int32 SelectedWorkSpaceId)
        {
            List<ChatDashboardSectionModel> lstChatSections = new List<ChatDashboardSectionModel>();
            try
            {
                lstChatSections.Add(new ChatDashboardSectionModel { SectionID = 1, SectionName = "Teams", SectionDisplayName = "TEAMS", AccountID = AccountID, CompanyID = CompanyID, UserID = UserID, ModuleID = ModuleID, WorkSpaceID = SelectedWorkSpaceId });
                lstChatSections.Add(new ChatDashboardSectionModel { SectionID = 2, SectionName = "Projects", SectionDisplayName = "PROJECTS", AccountID = AccountID, CompanyID = CompanyID, UserID = UserID, ModuleID = ModuleID, WorkSpaceID = SelectedWorkSpaceId });
                lstChatSections.Add(new ChatDashboardSectionModel { SectionID = 3, SectionName = "Users", SectionDisplayName = "USERS", AccountID = AccountID, CompanyID = CompanyID, UserID = UserID, ModuleID = ModuleID, WorkSpaceID = SelectedWorkSpaceId });
                return lstChatSections;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ChatTeamsModel>> GetTeamByAccountCompanyID(string AccountID, string CompanyID, string UserID, Int32 ModuleID, Int32 SelectedWorkSpaceId, string IsSpecialLogin)
        {
            List<ChatTeamsModel> lstGetTeam = null;
            try
            {

                string baseURL = APIConfig.Get_API_BaseURL() + "api/UserProfile/GetTeamByAccountCompanyID/" + AccountID + "/" + CompanyID + "/" + UserID + "/" + ModuleID + "/" + SelectedWorkSpaceId + "/" + IsSpecialLogin;
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    lstGetTeam = new List<ChatTeamsModel>();
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    lstGetTeam = JsonConvert.DeserializeObject<List<ChatTeamsModel>>(responsecontent);
                }
                return lstGetTeam;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<ChatUserModel>> Get_UsersList_Project_Team(Int32 ProjectID, string accountID, Int32 ModuleID, string UserID, Int32 SelectedWorkSpaceId)
        {
            List<ChatUserModel> lstchat = null;
            try
            {

                string baseURL = APIConfig.Get_API_BaseURL() + "api/UserProfile/Get_UsersList_Project_Team/" + ProjectID + "/" + accountID + "/" + ModuleID + "/" + UserID + "/" + SelectedWorkSpaceId;
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    lstchat = new List<ChatUserModel>();
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    lstchat = JsonConvert.DeserializeObject<List<ChatUserModel>>(responsecontent);
                }
                return lstchat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ChatUserModel>> GetUserBy_CompanyTeam(Int32 teamID, string AccountID, Int32 ModuleID, string UserID, Int32 SelectedWorkSpaceId)
        {
            List<ChatUserModel> lstCompantTeam = null;
            try
            {

                string baseURL = APIConfig.Get_API_BaseURL() + "api/UserProfile/GetUserBy_CompanyTeam/" + teamID + "/" + AccountID + "/" + ModuleID + "/" + UserID + "/" + SelectedWorkSpaceId;
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    lstCompantTeam = new List<ChatUserModel>();
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    lstCompantTeam = JsonConvert.DeserializeObject<List<ChatUserModel>>(responsecontent);
                }
                return lstCompantTeam;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //GetUsersList_Workspace
        public async Task<List<ChatProjectsModel>> GetProjectListForCompany(string AccountID, string CompanyID, string UserID, int ModuleID, int SelectedWorkSpaceId)
        {
            List<ChatProjectsModel> objProjectList = null;
            try
            {
                //string baseURL = APIConfig.Get_API_BaseURL() + "api/TimeSheet/GetTimesheetForAccount?CompanyID="+CompanyID+"&AccountID=" + AccountID + "&ModuleID=4&UserID="+ UserID +"&SelectedWorkSpaceId="+ SelectedWorkSpaceId + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "/api/ProjectManagement/GetProjectListForCompany/" + AccountID + "/" + CompanyID + "/" + UserID + "/" + ModuleID + "/" + SelectedWorkSpaceId + "";
                var json = JsonConvert.SerializeObject(objProjectList);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var task = await _client.PostAsync(baseURL, content);
                if (task.IsSuccessStatusCode)
                {
                    objProjectList = new List<ChatProjectsModel>();
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    objProjectList = JsonConvert.DeserializeObject<List<ChatProjectsModel>>(responsecontent);
                }
                return objProjectList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Returning Common Model for All Sections
        public async Task<List<ChatDashboardCommonModel>> GetTeamByAccountCompanyID_Common(string AccountID, string CompanyID, string UserID, Int32 ModuleID, Int32 SelectedWorkSpaceId, string IsSpecialLogin, int SectionID)
        {
            List<ChatTeamsModel> lstTeam = null;
            List<ChatDashboardCommonModel> lstCommon = null;
            try
            {

                string baseURL = APIConfig.Get_API_BaseURL() + "api/UserProfile/GetTeamByAccountCompanyID/" + AccountID + "/" + CompanyID + "/" + UserID + "/" + ModuleID + "/" + SelectedWorkSpaceId + "/" + IsSpecialLogin;
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    lstTeam = new List<ChatTeamsModel>();
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    lstTeam = JsonConvert.DeserializeObject<List<ChatTeamsModel>>(responsecontent);
                }
                if (lstTeam != null && lstTeam.Count > 0)
                {
                    lstCommon = new List<ChatDashboardCommonModel>();
                    foreach (ChatTeamsModel team in lstTeam)
                    {
                        lstCommon.Add(new ChatDashboardCommonModel
                        {
                            SectionID = SectionID,
                            AccountID = AccountID,
                            CompanyID = CompanyID,
                            UserID = UserID,
                            ModuleID = ModuleID,
                            WorkSpaceID = SelectedWorkSpaceId,
                            SectionItemID = Convert.ToString(team.teamID),
                            SectionItemText = Convert.ToString(team.teamName)
                        });
                    }
                }
                return lstCommon;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MobileWorkSpaceViewModel> Fetch_WorkspaceList_Chat(string AccountID, string UserID, int WorkSpaceID, int ModuleID)
        {
            MobileWorkSpaceViewModel obVM = null;
            try
            {

                string ParamList = "AccountID=" + AccountID + "&UserID=" + UserID + "&WorkspaceID=" + WorkSpaceID + "&moduleID=" + ModuleID + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "api/ProjectManagement/GetWorkspacePageData?" + ParamList + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    obVM = new MobileWorkSpaceViewModel();
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    obVM = JsonConvert.DeserializeObject<MobileWorkSpaceViewModel>(responsecontent);
                }

                return obVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ChatDashboardCommonModel>> GetProjectListForCompany(string AccountID, string CompanyID, string UserID, int ModuleID, int SelectedWorkSpaceId, int SectionID)
        {
            List<ChatProjectsModel> lstProjects = null;
            List<ChatDashboardCommonModel> lstCommon = null;
            try
            {
                //string baseURL = APIConfig.Get_API_BaseURL() + "api/TimeSheet/GetTimesheetForAccount?CompanyID="+CompanyID+"&AccountID=" + AccountID + "&ModuleID=4&UserID="+ UserID +"&SelectedWorkSpaceId="+ SelectedWorkSpaceId + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "/api/ProjectManagement/GetProjectListForCompany/" + AccountID + "/" + CompanyID + "/" + UserID + "/" + ModuleID + "/" + SelectedWorkSpaceId + "";
                var json = JsonConvert.SerializeObject(lstProjects);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var task = await _client.PostAsync(baseURL, content);
                if (task.IsSuccessStatusCode)
                {
                    lstProjects = new List<ChatProjectsModel>();
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    lstProjects = JsonConvert.DeserializeObject<List<ChatProjectsModel>>(responsecontent);
                }
                if (lstProjects != null && lstProjects.Count > 0)
                {
                    lstCommon = new List<ChatDashboardCommonModel>();
                    foreach (ChatProjectsModel project in lstProjects)
                    {
                        lstCommon.Add(new ChatDashboardCommonModel
                        {
                            SectionID = SectionID,
                            AccountID = AccountID,
                            CompanyID = CompanyID,
                            UserID = UserID,
                            ModuleID = ModuleID,
                            WorkSpaceID = SelectedWorkSpaceId,
                            SectionItemID = Convert.ToString(project.projectID),
                            SectionItemText = Convert.ToString(project.projectName),
                            //SectionItemExtraVal1=Convert.ToString(project.taskcou)

                        });
                    }
                }
                return lstCommon;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task<List<ChatUserModel>> GetUsersList_Workspace(string accountID, Int32 ModuleID, string UserID, Int32 SelectedWorkSpaceId)
        {
            List<ChatUserModel> lstchat = null;
            try
            {

                string baseURL = APIConfig.Get_API_BaseURL() + "api/UserProfile/GetUsersList_Workspace/" + accountID + "/" + ModuleID + "/" + UserID + "/" + SelectedWorkSpaceId;
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    lstchat = new List<ChatUserModel>();
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    lstchat = JsonConvert.DeserializeObject<List<ChatUserModel>>(responsecontent);
                }
                return lstchat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
    }
}
