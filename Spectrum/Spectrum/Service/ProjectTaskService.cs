using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Spectrum.APISettings;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.ProjectManagement;
using Spectrum.Model.ModelDataTypes.TaskManagement;
using Spectrum.View.MasterPages;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Spectrum.Service
{
    public class ProjectTaskService
    {
        public string token { get; set; }
        public ProjectTaskService()
        {
            if (Application.Current.Properties["WebToken"] != null)
            {
                token = Convert.ToString(Application.Current.Properties["WebToken"]);
            }
        }


        public async Task<List<ProjectDetailList>> GetProjectListAsync(string userId, string companyId, int ModuleID, string AccountID, string RoleIDList, string isSpecialLogin, int SelectedworkspaceID, bool isCommandCenter, int LanguageID)
        {
            List<ProjectDetailList> lstProjects = new List<ProjectDetailList>();
            try
            {

                string ParamList = "userId=" + userId + "&companyId=" + companyId + "&ModuleID=" + ModuleID + "&AccountID=" + AccountID + "&RoleIDList=" + RoleIDList + "&isSpecialLogin=" + isSpecialLogin + "&SelectedworkspaceID=" + SelectedworkspaceID + "&isCommandCenter=" + isCommandCenter + "&LanguageID=" + LanguageID + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "/api/GetProjectList?" + ParamList + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    lstProjects = JsonConvert.DeserializeObject<List<ProjectDetailList>>(responsecontent);
                }

                return lstProjects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///api/ProjectManagement/BindProjectDetails
        public async Task<ProjectManagementViewModel> GetProjectDetailAsync(int ProjectID, string CompanyID, int GroupID, string UserID, int PageNo, int ModuleID, string AccountID, int SelectedworkspaceID)
        {
            ProjectManagementViewModel lstProjectDetais = new ProjectManagementViewModel();
            try
            {

                string ParamList = "ProjectID=" + ProjectID + "&CompanyID=" + CompanyID + "&GroupID=" + GroupID + "&UserID=" + UserID + "&PageNo=" + PageNo + "&ModuleID=" + ModuleID + "&AccountID=" + AccountID + "&SelectedworkspaceID=" + SelectedworkspaceID + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "/api/ProjectManagement/BindProjectDetails?" + ParamList + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    lstProjectDetais = JsonConvert.DeserializeObject<ProjectManagementViewModel>(responsecontent);
                }

                return lstProjectDetais;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProjectTaskDetail>> GetAllProjectTaskListAsync(int ProjectID, string CompanyID, int GroupID, string UserID, int PageNo, int ModuleID, string AccountID, int SelectedworkspaceID, string MainListName)
        {
            List<ProjectTaskDetail> lstProjectTasks = new List<ProjectTaskDetail>();
            try
            {

                string ParamList = "ProjectID=" + ProjectID + "&CompanyID=" + CompanyID + "&GroupID=" + GroupID + "&UserID=" + UserID + "&PageNo=" + PageNo + "&ModuleID=" + ModuleID + "&AccountID=" + AccountID + "&SelectedworkspaceID=" + SelectedworkspaceID + "&MainListName=" + MainListName + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "/api/ProjectManagement/BindAllProjectTasksList?" + ParamList + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    lstProjectTasks = JsonConvert.DeserializeObject<List<ProjectTaskDetail>>(responsecontent);
                }

                return lstProjectTasks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///api/ProjectManagement/BindMyProjectTasks
        public async Task<List<ProjectTaskDetail>> GetMyProjectTaskListAsync(int ProjectID, string CompanyID, int GroupID, string UserID, int PageNo, int ModuleID, string AccountID, int SelectedworkspaceID, string MainListName)
        {
            List<ProjectTaskDetail> lstProjectTasks = new List<ProjectTaskDetail>();
            try
            {

                string ParamList = "ProjectID=" + ProjectID + "&CompanyID=" + CompanyID + "&GroupID=" + GroupID + "&UserID=" + UserID + "&PageNo=" + PageNo + "&ModuleID=" + ModuleID + "&AccountID=" + AccountID + "&SelectedworkspaceID=" + SelectedworkspaceID + "&MainListName=" + MainListName + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "/api/ProjectManagement/BindMyProjectTasksList?" + ParamList + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    lstProjectTasks = JsonConvert.DeserializeObject<List<ProjectTaskDetail>>(responsecontent);
                }

                return lstProjectTasks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ////api/TaskManagement/Get_Edit_ProjectTask_DetailsbyID
        public async Task<dynamic> GetEditTaskDetailAsync(int ProjectID, string CompanyID, int GroupID, string UserID, int PageNo, int ModuleID, string AccountID, int SelectedworkspaceID)
        {
            dynamic objEditTask = null;
            try
            {

                string ParamList = "ProjectID=" + ProjectID + "&CompanyID=" + CompanyID + "&GroupID=" + GroupID + "&UserID=" + UserID + "&PageNo=" + PageNo + "&ModuleID=" + ModuleID + "&AccountID=" + AccountID + "&SelectedworkspaceID=" + SelectedworkspaceID + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "/api/TaskManagement/Get_Edit_ProjectTask_DetailsbyID?" + ParamList + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    objEditTask = JsonConvert.DeserializeObject<dynamic>(responsecontent);
                }

                return objEditTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ///api/TaskManagement/Get_SelectedTaskDetails

        public async Task<dynamic> GetSelectedTaskDetailAsync(int ProjectID, string CompanyID, int GroupID, string UserID, int PageNo, int ModuleID, string AccountID, int SelectedworkspaceID)
        {
            dynamic objEditTask = null;
            try
            {

                string ParamList = "ProjectID=" + ProjectID + "&CompanyID=" + CompanyID + "&GroupID=" + GroupID + "&UserID=" + UserID + "&PageNo=" + PageNo + "&ModuleID=" + ModuleID + "&AccountID=" + AccountID + "&SelectedworkspaceID=" + SelectedworkspaceID + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "/api/TaskManagement/Get_SelectedTaskDetails?" + ParamList + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    objEditTask = JsonConvert.DeserializeObject<dynamic>(responsecontent);
                }

                return objEditTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ///api/ProjectManagement/GetDocuments/{moduleID}/{subModuleName}/{recordID}/{AccountID}/{UserID}
        ///
        public async Task<List<DocumentUpload>> GetTaskDocuentsAsync(int moduleID, string subModuleName, int recordID, string UserID, string AccountID)
        {
            List<DocumentUpload> lstDocument = new List<DocumentUpload>();
            try
            {

                string ParamList = "moduleID=" + moduleID + "&subModuleName=" + subModuleName + "&recordID=" + recordID + "&UserID=" + UserID + "&AccountID=" + AccountID + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "/api/ProjectManagement/GetDocuments?" + ParamList + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    lstDocument = JsonConvert.DeserializeObject<List<DocumentUpload>>(responsecontent);
                }

                return lstDocument;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region functions for New Project Screen
        public async Task<MobileProjectDetailViewModel> Fetch_ProjectPageDDLS(int ModuleID, string UserID, string CompanyID, string AccountID, int WorkSpaceID, string IsSpecialLogin)
        {
            MobileProjectDetailViewModel objModel = new MobileProjectDetailViewModel();
            try
            {

                string ParamList = "moduleID=" + ModuleID + "&UserID=" + UserID + "&CompanyID=" + CompanyID + "&AccountID=" + AccountID + "&SelectedWorkSpaceId=" + WorkSpaceID + "&isSpecialLogin=" + IsSpecialLogin + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "/api/ProjectManagement/BindProjectScreenViewModel?" + ParamList + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    objModel = JsonConvert.DeserializeObject<MobileProjectDetailViewModel>(responsecontent);
                }

                return objModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProjectManagementViewModel> Save_ProjectDetails(ProjectModelMobile objProject)
        {
            ProjectListProfile objProjectData = new ProjectListProfile();
            ProjectManagementViewModel objProjectData2 = new ProjectManagementViewModel();
            try
            {
                string baseURL = APIConfig.Get_API_BaseURL() + "api/ProjectManagement/CreateNewProjectMobile";
                var json = JsonConvert.SerializeObject(objProject);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var task = await _client.PostAsync(baseURL, content);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    objProjectData = JsonConvert.DeserializeObject<ProjectListProfile>(responsecontent);
                    if (objProjectData.CustomMessage != null)
                    {
                        objProjectData2.CustomMessage = new CustomMessage();
                        objProjectData2.CustomMessage = objProjectData.CustomMessage;
                    }
                    else
                    {
                        objProjectData2 = JsonConvert.DeserializeObject<ProjectManagementViewModel>(responsecontent);
                    }
                }
                return objProjectData2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<WorkspaceItem>> Fetch_WorkspaceList(string AccountID, string UserID, int WorkSpaceID, int ModuleID)
        {
            List<WorkspaceItem> objModel = new List<WorkspaceItem>();
            try
            {

                string ParamList = "AccountID=" + AccountID + "&UserID=" + UserID + "&WorkspaceID=" + WorkSpaceID + "&moduleID=" + ModuleID + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "api/ProjectManagement/GetWorkspaceList?" + ParamList + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    objModel = JsonConvert.DeserializeObject<List<WorkspaceItem>>(responsecontent);
                }

                return objModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<MobileWorkSpaceViewModel> Fetch_WorkspaceList_New(string AccountID, string UserID, int WorkSpaceID, int ModuleID)
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

        public async Task<List<MobileTeamProfile>> Fetch_TeamProject(string UserID, string CompanyID, string AccountID, int ModuleID, int WorkSpaceID)
        {
            List<MobileTeamProfile> objModel = new List<MobileTeamProfile>();
            try
            {

                string ParamList = "UserID=" + UserID + "&companyID=" + CompanyID + "&AccountID=" + AccountID + "&ModuleID=" + ModuleID + "&SelectedWorkSpaceId=" + WorkSpaceID + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "api/ProjectManagement/GetTeamListMobile?" + ParamList + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    objModel = JsonConvert.DeserializeObject<List<MobileTeamProfile>>(responsecontent);
                }

                return objModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update_TaskReadStatus(string AccountID, string CompanyID, string UserID, Int64 ProjectID, Int64 TaskID, int ModuleID)
        {
            int retval = 0;
            try
            {
                string ParamList = "AccountID=" + AccountID + "&CompanyID=" + CompanyID + "&UserID=" + UserID + "&ProjectID=" + ProjectID + "&TaskID=" + TaskID + "&ModuleID=" + ModuleID + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "api/ProjectManagement/UpdateTaskReadStatus?" + ParamList + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    //  MobileTaskViewModel
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    retval = JsonConvert.DeserializeObject<int>(responsecontent);
                }
                return retval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Functions for New Task Screen
        public async Task<MobileTaskViewModel> GetNewTaskDDLs(Int64 ProjectID, string CompanyID, string UserID, string AccountID, int ModuleID, int WorkSpaceID)
        {
            MobileTaskViewModel retval = null;
            try
            {
                string ParamList = "ProjectID=" + ProjectID + "&CompanyID=" + CompanyID + "&UserID=" + UserID + "&AccountID=" + AccountID + "&ModuleID=" + ModuleID + "&SelectedWorkSpaceId=" + WorkSpaceID + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "api/TaskManagement/GetTaskScreenViewModel?" + ParamList + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    retval = new MobileTaskViewModel();
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    retval = JsonConvert.DeserializeObject<MobileTaskViewModel>(responsecontent);
                }
                return retval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MobileTaskResponse> Save_ProjectTask(MobileCreateTaskModel objTask)
        {
            MobileTaskResponse objTaskProfile = new MobileTaskResponse();
            try
            {
                string baseURL = APIConfig.Get_API_BaseURL() + "api/TaskManagement/CreateNewTaskMobile";
                var json = JsonConvert.SerializeObject(objTask);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var task = await _client.PostAsync(baseURL, content);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    objTaskProfile = JsonConvert.DeserializeObject<MobileTaskResponse>(responsecontent);

                }
                return objTaskProfile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Testing
        private readonly List<string> _data = new List<string>
        {
            "Mohamed", "Hassen", "Omar", "Ali", "Othman", "Adam", "Seif", "Hamed", "Paul",
            "David", "Fehmi", "Badr", "Hamza", "Nabil", "Hajer", "Sami", "Ahmed", "Amir",
            "Nebrass", "Karim", "Cherif", "Alaa", "Samar", "Narjess", "Iheb", "Safa",
            "Mohamed", "Hassen", "Omar", "Ali", "Othman", "Adam", "Seif", "Hamed", "Paul",
            "David", "Fehmi", "Badr", "Hamza", "Nabil", "Hajer", "Sami", "Ahmed", "Amir",
             "Mohamed", "Hassen", "Omar", "Ali", "Othman", "Adam", "Seif", "Hamed", "Paul",
            "David", "Fehmi", "Badr", "Hamza", "Nabil", "Hajer", "Sami", "Ahmed", "Amir",
            "Nebrass", "Karim", "Cherif", "Alaa", "Samar", "Narjess", "Iheb", "Safa",
            "Mohamed", "Hassen", "Omar", "Ali", "Othman", "Adam", "Seif", "Hamed", "Paul",
            "David", "Fehmi", "Badr", "Hamza", "Nabil", "Hajer", "Sami", "Ahmed", "Amir",
             "Mohamed", "Hassen", "Omar", "Ali", "Othman", "Adam", "Seif", "Hamed", "Paul",
            "David", "Fehmi", "Badr", "Hamza", "Nabil", "Hajer", "Sami", "Ahmed", "Amir",
            "Nebrass", "Karim", "Cherif", "Alaa", "Samar", "Narjess", "Iheb", "Safa",
            "Mohamed", "Hassen", "Omar", "Ali", "Othman", "Adam", "Seif", "Hamed", "Paul",
            "David", "Fehmi", "Badr", "Hamza", "Nabil", "Hajer", "Sami", "Ahmed", "Amir",
        };

        public async Task<List<string>> GetItemsAsync(int pageIndex, int pageSize)
        {
            await Task.Delay(2000);

            return _data.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
        #endregion
    }
}