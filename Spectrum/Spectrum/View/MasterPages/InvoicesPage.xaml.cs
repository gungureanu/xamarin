using System;
using System.Collections.Generic;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Xamarin.Forms;

namespace Spectrum.View.MasterPages
{
    public partial class InvoicesPage : ContentPage
    {
        public UserProfileMob _objProfile { get; set; }
        public List<ModuleMainPanel> _lstModules { get; set; }
        public int SelModuleID { get; set; }
        public InvoicesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }
        public InvoicesPage(UserProfileMob ObjUserProfile, List<ModuleMainPanel> lstModules, int selModule)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            _objProfile = ObjUserProfile;
            _lstModules = lstModules;
            SelModuleID = selModule;
        }
    }
}
