using System;
using System.Collections.Generic;
using Spectrum.Model;
using Spectrum.Model.ModelDataTypes;
using Xamarin.Forms;

namespace Spectrum.View.ProjectTasks
{
    public partial class ProjectTaskPage : ContentPage
    {
        public UserProfileMob _userprofile;
        public ProjectTaskPage()
        {
            InitializeComponent();
        }

        public ProjectTaskPage(UserProfileMob objProfile)
        {
            InitializeComponent();
            _userprofile = objProfile;
        }
    }
}
