
using Android.Content.PM;
using Spectrum.Dependencies;
using Spectrum.Droid;
using Xamarin.Forms;


[assembly: Dependency(typeof(VersionAndBuild_Android))]
namespace Spectrum.Droid
{
    public class VersionAndBuild_Android : IAppVersionAndBuild
    {
        PackageInfo _appInfo;
        public VersionAndBuild_Android()
        {
            var context = Android.App.Application.Context;
            _appInfo = context.PackageManager.GetPackageInfo(context.PackageName, 0);
        }
        public string GetVersionNumber()
        {
            return _appInfo.VersionName;
        }
        public string GetBuildNumber()
        {
            return _appInfo.VersionCode.ToString();
        }
    }
}