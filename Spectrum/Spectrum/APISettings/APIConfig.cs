using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.APISettings
{
    public static class APIConfig
    {
        public static string Get_API_BaseURL()
        {
           // return "https://khamelia.logixportfolio.in/";
            return "https://api.khamelia.com/";
        }
        public static string Get_ChatHubConnection()
        {
            return "https://uat.khamelia.com/ConnectionHub";
        }
        public static string Get_APP_Name()
        {
            return "Spectrum";
        }
        public static string ChatHubUrl()
        {
            return "Spectrum";
        }
    }
}
