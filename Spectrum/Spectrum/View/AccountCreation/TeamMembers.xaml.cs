using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spectrum.View.AccountCreation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamMembers : ContentPage
    {
        public TeamMembers()
        {
            InitializeComponent();
            SetPageDesign();
            bindMembers();
        }
        private async void SetPageDesign()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                StkMain.Margin = new Thickness(0, 16, 0, 0);
            }
        }
        private async void NEXT_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.UserInvitation());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async void INVITEUSER_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.UserInvitation());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public class TeamMember
        {
            public string ImageSource { get; set; }
            public string MemberName { get; set; }
            public string MemberEmailID { get; set; }
        }
        public void bindMembers()
        {
            try
            {
                List<TeamMember> lstTeamMember = new List<TeamMember>();
                lstTeamMember.Add(new TeamMember { ImageSource = "male_user_icon.png", MemberName = "Gabriel Ungureanu", MemberEmailID = "gabriel.ungureanu@khamelia.com" });
                lstTeamMember.Add(new TeamMember { ImageSource = "female_user_icon.png", MemberName = "Heidi Lucille Ungureanu", MemberEmailID = "heidi.ungureanu@khamelia.com" });
                lstTeamMember.Add(new TeamMember { ImageSource = "male_user_icon.png", MemberName = "Adrian Bogdan", MemberEmailID = "adrian.bogdan@khamelia.com" });
                lstTeamMember.Add(new TeamMember { ImageSource = "male_user_icon.png", MemberName = "Charles Moore", MemberEmailID = "charles.moore@khamelia.com" });
                lstTeamMember.Add(new TeamMember { ImageSource = "male_user_icon.png", MemberName = "Sandeep Agarwal", MemberEmailID = "sandeep.agarwal@khamelia.net" });
                lstTeamMember.Add(new TeamMember { ImageSource = "male_user_icon.png", MemberName = "Shariq Khan", MemberEmailID = "shariq.khan@khamelia.net" });
                listViewTeamMembers.ItemsSource = lstTeamMember;
                listViewTeamMembers.BindingContext = lstTeamMember;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.AboutBusiness());
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new View.AccountCreation.AboutBusiness());
        }

    }
}