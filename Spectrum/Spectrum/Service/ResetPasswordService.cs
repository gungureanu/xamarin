using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Spectrum.APISettings;
using Spectrum.Model.ModelDataTypes;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Spectrum.Service
{
    public class ResetPasswordService
    {
        public string token { get; set; }
        public ResetPasswordService()
        {
            if (Application.Current.Properties["WebToken"] != null)
            {
                token = Convert.ToString(Application.Current.Properties["WebToken"]);
            }
        }

        public async Task<string> ResetUserPasswordAsync(PasswordManagerModel objModel)
        {
            string retval = "";
            try
            {
                string baseURL = APIConfig.Get_API_BaseURL() + "api/ResetUserPassword";
                var json = JsonConvert.SerializeObject(objModel);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient _client = new HttpClient();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var task = await _client.PostAsync(baseURL, content);
                if (task.IsSuccessStatusCode)
                {
                    retval = await task.Content.ReadAsStringAsync();
                    //retval = JsonConvert.DeserializeObject<string>(responsecontent);
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
