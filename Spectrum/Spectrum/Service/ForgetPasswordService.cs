using System;
using System.Net.Http;
using System.Threading.Tasks;
using Spectrum.APISettings;
using Spectrum.Model.ModelDataTypes;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Spectrum.Service
{
    public class ForgetPasswordService
    {
        public string token { get; set; }
        public ForgetPasswordService()
        {
            //if (Application.Current.Properties["WebToken"] != null)
            //{
            //    token = Convert.ToString(Application.Current.Properties["WebToken"]);
            //}
        }

        public async Task<UserAccountProfile> ResetUserPasswordAsync(string EmailAddress)
        {
            UserAccountProfile objUser = new UserAccountProfile();
            try
            {
                string baseURL = APIConfig.Get_API_BaseURL() + "api/ForgotUserPassword?EmailAddress=" + EmailAddress + "";
                HttpClient _client = new HttpClient();
                var task = await _client.GetAsync(baseURL);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    objUser = JsonConvert.DeserializeObject<UserAccountProfile>(responsecontent);
                }
                return objUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
