using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Acr.UserDialogs;
using Spectrum.Model.ModelDataTypes;

using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
using Spectrum.Service;
using Xamarin.Forms;
using Spectrum.ChatUtility;
using System.Runtime;
using System.Threading;
using Newtonsoft.Json;
using Spectrum.Model;

namespace Spectrum.View.MasterPages.Chatting
{
    public partial class OnlineChatDashboard : ContentPage
    {
        public UserProfileMob _objProfile { get; set; }
        public List<ModuleMainPanel> _lstModules { get; set; }
        public int SelModuleID { get; set; }
        //public TimeSheetsService TimeSheetService { get; set; }
        //public TimeSheetsViewModel ObjtimeSheets { get; set; }
        private List<WorkspaceItem> _lstWorkSpaces { get; set; }
        private WorkspaceItem _curWorkSpace { get; set; }
        public ContentPage _objPage { get; set; }
        int TextFontSize { get; set; }
        int ImageSize { get; set; }
        int RowHeightSize { get; set; }
        int FirstGridHeight { get; set; }
        int FirstGridRowHeieght { get; set; }
        //List<TimesheetListModel> lstTimesheets { get; set; }
        //List<TimesheetListModel> lstTimesheetsApproved { get; set; }
        //List<TimesheetListModel> lstTimesheetsPending { get; set; }

        List<UserProfileMob> lstParticipants { get; set; }
        public ProjectTaskService _objService = new ProjectTaskService();

        List<ParticipantsModel> chatParticipants { get; set; }

        ChatViewModel objCVM { get; set; }
        List<ConferenceUser> lstCurrentChatUsers;

        public OnlineChatDashboard()
        {
            InitializeComponent();
            //objCVM = new ChatViewModel();
            //this.BindingContext = objCVM;

        }

        //public OnlineChatDashboard(UserProfileMob ObjUserProfile, List<UserProfileMob> LstParticipants, List<ModuleMainPanel> lstModules, int selModule)
        public OnlineChatDashboard(UserProfileMob ObjUserProfile, List<ModuleMainPanel> lstModules, int selModule)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            Application.Current.Properties["ChatUserData"] = "";
            _objProfile = ObjUserProfile;
            _lstModules = lstModules;
            SelModuleID = selModule;
           // TimeSheetService = new TimeSheetsService();
            lstCurrentChatUsers = new List<ConferenceUser>();
            this.BindingContext = new ChatViewModel(_objProfile);
            objCVM = new ChatViewModel(_objProfile);
            //this.BindingContext = objCVM;
            //(this.BindingContext as ChatViewModel).ConnectMeCommand.Execute(null);
        }

        public async void BtnSend_Clicked(System.Object sender, System.EventArgs e)
        {
            BtnSend.IsEnabled = false;
            ConferenceMessage objMessage = new ConferenceMessage();
            objMessage.AccountID = _objProfile.AccountID;
            objMessage.FromUserName = _objProfile.UserName;
            objMessage.Message = txtMessageText.Text.Trim();
            objMessage.MessageDateTime = System.DateTime.Now;
            objMessage.ProfileImage = _objProfile.ProfileImageName;
            objMessage.UserID = _objProfile.UserID;
            objMessage.FileID = 0;
            objMessage.WorkspaceID = _objProfile.WorkspaceID;

            //List<Participant> lstParticipant = new List<Participant>();
            //if (Application.Current.Properties["ChatUserData"] != null)
            //{
            //    List<Participant> lstconuser = (List<Participant>)Application.Current.Properties["ChatUserData"];

            //    if (lstconuser != null && lstconuser.Count > 0)
            //    {
            //        Participant objME = lstconuser.Where(x => x.UserID == _objProfile.UserID).FirstOrDefault();
            //        Participant objOther = new Participant();
            //        if (lstconuser.Count > 1)
            //        {
            //            objOther = lstconuser.Where(x => x.UserID != _objProfile.UserID).FirstOrDefault();
            //        }

            //        if (objOther != null && objOther.UserID != Guid.Empty)
            //            lstParticipant.Add(new Participant { UserID = objOther.UserID, ConnectionID = objOther.ConnectionID, AccountID = objOther.AccountID, WorkspaceID = objOther.WorkspaceID });
            //        else
            //            lstParticipant.Add(new Participant { UserID = objME.UserID, ConnectionID = objME.ConnectionID, AccountID = objME.AccountID, WorkspaceID = objME.WorkspaceID });
            //        if (objME != null)
            //            lstParticipant.Add(new Participant { UserID = objME.UserID, ConnectionID = objME.ConnectionID, AccountID = objME.AccountID, WorkspaceID = objME.WorkspaceID });
            //        objMessage.ParticipantList = lstParticipant;
            //        (this.BindingContext as ChatViewModel).ConfMsg = objMessage;
            //        (this.BindingContext as ChatViewModel).SendMessageCommand.Execute(lstCurrentChatUsers);
            //        txtMessageText.Text = "";
            //    }
            //}
            List<ConferenceMessage> lstconfMsg = new List<ConferenceMessage>();
            if (Application.Current.Properties["ChatUserData"] != null)
            {
                List<ConferenceUser> lstconuser = (List<ConferenceUser>)Application.Current.Properties["ChatUserData"];

                if (lstconuser != null && lstconuser.Count > 0)
                {
                    ConferenceUser objME = lstconuser.Where(x => x.UserID == _objProfile.UserID).FirstOrDefault();
                    ConferenceUser objOther = new ConferenceUser();
                    if (lstconuser.Count > 1)
                    {
                        objOther = lstconuser.Where(x => x.UserID != _objProfile.UserID).FirstOrDefault();
                    }

                    if (objOther != null && objOther.UserID != Guid.Empty)
                        lstconfMsg.Add(new ConferenceMessage { UserID = objOther.UserID, ConnectionID = objOther.ConnectionId });
                    else
                        lstconfMsg.Add(new ConferenceMessage { UserID = objME.UserID, ConnectionID = objME.ConnectionId });
                    if (objME != null)
                        lstconfMsg.Add(new ConferenceMessage { UserID = objME.UserID, ConnectionID = objME.ConnectionId });
                    objMessage.ConferenceMessageList = lstconfMsg;
                    (this.BindingContext as ChatViewModel).ConfMsg = objMessage;
                    (this.BindingContext as ChatViewModel).SendMessageCommand.Execute(lstCurrentChatUsers);
                    txtMessageText.Text = "";
                }
            }
        }

        private async void txtMessageText_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessageText.Text))
            {
                if (txtMessageText.Text.Trim().Length > 0)
                    BtnSend.IsEnabled = true;
                else
                    BtnSend.IsEnabled = false;
            }
            else
            {
                BtnSend.IsEnabled = false;
            }
        }
    }
}
