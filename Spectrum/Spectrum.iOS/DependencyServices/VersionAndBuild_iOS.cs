using System;
using Foundation;
using Spectrum.Dependencies;
using Spectrum.iOS;
using Spectrum.iOS.DependencyServices;
using Xamarin.Forms;
[assembly: Dependency(typeof(VersionAndBuild_iOS))]
namespace Spectrum.iOS.DependencyServices
{
    public class VersionAndBuild_iOS : IAppVersionAndBuild
    {
        public string GetBuildNumber()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        }

        public string GetVersionNumber()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();
        }
    }
}
