using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Spectrum.Model;

using Spectrum.APISettings;
using Newtonsoft.Json;
using Xamarin.Forms;
namespace Spectrum.Service
{
    public class AppUpdateService
    {
        public string token { get; set; }
        public AppUpdateService()
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

        public async Task<string> CheckAppUpdate(string AppName, string PlatformName, string AppBuild, string ApPVersion)
        {
            string retval = "";
            try
            {
                //string baseURL = APIData.Get_IfscURL() + IfscCode;
                string baseURL = APIConfig.Get_API_BaseURL() + "api/mobileApp/CheckUpdate/" + AppName + "/" + PlatformName + "/" + AppBuild + "/" + ApPVersion + "";
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    retval = JsonConvert.DeserializeObject<string>(responsecontent);
                }
                return retval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
