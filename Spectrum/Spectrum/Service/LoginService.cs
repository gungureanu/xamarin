using Spectrum.APISettings;
using Spectrum.Model;
using Spectrum.Model.ModelDataTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum.Service
{
    public class LoginService
    {
        public async Task<UserProfileMob> LoginUser(Model.UserModel objUser)
        {
            UserProfileMob objPofile = new UserProfileMob();
            try
            {
                string baseURL = APIConfig.Get_API_BaseURL() + "api/AppLogin";
                var json = JsonConvert.SerializeObject(objUser);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient _client = new HttpClient();
                var task = await _client.PostAsync(baseURL, content);
                if (task.IsSuccessStatusCode)
                {
                    var responsecontent = await task.Content.ReadAsStringAsync();
                    objPofile = JsonConvert.DeserializeObject<UserProfileMob>(responsecontent);
                }
                return objPofile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
