using System;
using System.Net;
using System.Runtime.CompilerServices;
using Spectrum.Service;

[assembly: Xamarin.Forms.Dependency(typeof(Spectrum.Droid.DependencyServices.IPAddressManager))]

namespace Spectrum.Droid.DependencyServices
{
    public class IPAddressManager : IIPAddressManager
    {
        public string GetIPAddress()
        {
            IPAddress[] adresses = Dns.GetHostAddresses(Dns.GetHostName());

            if (adresses != null && adresses[0] != null)
            {
                return adresses[0].ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
