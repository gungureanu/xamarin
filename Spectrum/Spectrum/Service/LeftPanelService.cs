using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Spectrum.APISettings;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Spectrum.Model.ModelDataTypes.Reports;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Spectrum.Service
{
    public class LeftPanelService
    {
        public string token { get; set; }
        public LeftPanelService()
        {
            if (Application.Current.Properties["WebToken"] != null)
            {
                token = Convert.ToString(Application.Current.Properties["WebToken"]);
            }
        }

        public async Task<List<ModuleMainPanel>> GetModuleNamesAsync(string AccountID, int PlanID, string RoleIDList, string isSpecialLogin, bool IsCommandAdmin, int ModuleID, string UserID, int SelectedWorkSpaceId)
        {
            List<ModuleMainPanel> lstModules = new List<ModuleMainPanel>();
            List<ModuleMainTabs> lstModuleTabs = new List<ModuleMainTabs>();
            try
            {
                string ParamList = "AccountID=" + AccountID + "&PlanID=" + PlanID + "&RoleIDList=" + RoleIDList + "&isSpecialLogin=" + isSpecialLogin + "&IsCommandAdmin=" + IsCommandAdmin + "&ModuleID=" + ModuleID + "&UserID=" + UserID + "&SelectedWorkSpaceId=" + SelectedWorkSpaceId + "";
                string baseURL = APIConfig.Get_API_BaseURL() + "/api/ModuleTabs?" + ParamList + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    lstModuleTabs = JsonConvert.DeserializeObject<List<ModuleMainTabs>>(responsecontent);
                }
                if (lstModuleTabs != null && lstModuleTabs.Count > 0 && lstModuleTabs[0].LstModuleMainPanel != null && lstModuleTabs[0].LstModuleMainPanel.Count > 0)
                {
                    lstModules = lstModuleTabs[0].LstModuleMainPanel;
                }
                return lstModules;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<Int32> SaveVisitorDataAsync(HelpDeskTicket objHelpDeskViewModel)
        //{
        //    Int32 RetVal = 0;
        //    try
        //    {
        //        string baseURL = APISettings.Get_API_BaseURL();
        //        var json = JsonConvert.SerializeObject(objHelpDeskViewModel);
        //        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
        //        HttpClient _client = new HttpClient();
        //        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        //        baseURL = baseURL + "SaveHelpDeskDetails";
        //        var task = await _client.PostAsync(baseURL, content);
        //        if (task.IsSuccessStatusCode)
        //        {
        //            var responsecontent = await task.Content.ReadAsStringAsync();
        //            RetVal = JsonConvert.DeserializeObject<Int32>(responsecontent);
        //        }
        //        return RetVal;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
