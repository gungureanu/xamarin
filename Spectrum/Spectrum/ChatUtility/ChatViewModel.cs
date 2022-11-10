using Spectrum.ChatUtility;
using Spectrum.Model.ModelDataTypes;

using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Spectrum.ChatUtility
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private UserProfileMob _chatUser;


        private List<ConferenceUser> _totalUsers;
        private List<ConferenceUser> _confUser;
        private ConferenceMessage _confMsg;
        private string _name;
        private string _message;
        private ObservableCollection<MessageModel> _messages;
        private bool _isConnected;


        public UserProfileMob ChatUser
        {
            get
            {
                return _chatUser;
            }
            set
            {
                _chatUser = value;
                OnPropertyChanged();
            }
        }

        public List<ConferenceUser> ConfUser
        {
            get
            {
                return _confUser;
            }
            set
            {
                _confUser = value;
                OnPropertyChanged();
            }
        }


        public List<ConferenceUser> TotalUsers
        {
            get
            {
                return _totalUsers;
            }
            set
            {
                _totalUsers = value;
                OnPropertyChanged();
            }
        }

        public ConferenceMessage ConfMsg
        {
            get
            {
                return _confMsg;
            }
            set
            {
                _confMsg = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }


        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MessageModel> Messages
        {
            get
            {
                return _messages;
            }
            set
            {
                _messages = value;
                OnPropertyChanged();
            }
        }
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;
                OnPropertyChanged();
            }
        }

        private HubConnection hubConnection;

        public Command SendMessageCommand { get; }
        public Command ConnectCommand { get; }
        public Command ConnectMeCommand { get; }
        public Command ConnectParticipantCommand { get; }
        public Command DisconnectCommand { get; }

        public ChatViewModel(UserProfileMob objUser)
        {
            ChatUser = objUser;
            TotalUsers = new List<ConferenceUser>();
            ConferenceUser conu = new ConferenceUser
            {
                UserID = ChatUser.UserID,
                AccountID = ChatUser.AccountID,
                UserName = ChatUser.FirstName + " " + ChatUser.LastName,
                ProfilePath = ChatUser.ProfilePath,
                ConferenceCallID = 0,
                ConnectionId = "",
                InCall = false,
                IsVideoEnable = false,
                RoomID = "",
                WorkspaceID = ChatUser.WorkspaceID
            };
            TotalUsers.Add(conu);
            Application.Current.Properties["ChatUserData"] = TotalUsers;
            Messages = new ObservableCollection<MessageModel>();
            SendMessageCommand = new Command(async () => { await SendMessageToUser(); });
            ConnectCommand = new Command(async () => await Connect());
            ConnectMeCommand = new Command(async () => await ConnectMe());
            DisconnectCommand = new Command(async () => await Disconnect());

            IsConnected = false;

            hubConnection = new HubConnectionBuilder()
         .WithUrl($"https://uat.khamelia.com/ConnectionHub")
         .Build();


            hubConnection.On<string, Guid, string, Guid, int>("Join", (username, userid, profilePath, accountid, workspaceid) =>
                {
                    // Messages.Add(new MessageModel() { UserName = Name, MessageText = $"{username} has joined the chat", IsSystemMessage = true, MessageTime = System.DateTime.Now.ToString("hh:mm tt") });
                });

            hubConnection.On<ConferenceMessage>("ReceiveMessage_MiddleScreen_User", (objMessage) =>
            {
                MessageModel curMsg = new MessageModel();
                curMsg.UserID = Convert.ToString(objMessage.UserID);
                curMsg.UserName = Convert.ToString(objMessage.FromUserName);
                curMsg.MessageText = objMessage.Message;
                curMsg.MessageTime = objMessage.MessageDateTime.ToString("hh:mm tt");
                curMsg.IsOwnMessage = objMessage.UserID == ChatUser.UserID ? true : false;
                curMsg.IsOtherMessage = objMessage.UserID != ChatUser.UserID ? true : false;
                Messages.Add(curMsg);
            });


            hubConnection.On<string>("LeaveChat", (user) =>
            {
                // Messages.Add(new MessageModel() { UserName = Name, MessageText = $"{user} has left the chat", IsSystemMessage = true, MessageTime = System.DateTime.Now.ToString("hh:mm tt") });
            });

            //hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            //{
            //    Messages.Add(new MessageModel() { UserName = user, MessageText = message, IsSystemMessage = false, IsOwnMessage = Name == user, MessageTime = System.DateTime.Now.ToString("hh:mm tt") });
            //});


            hubConnection.On<List<ConferenceUser>>("UpdateUserList", (users) =>
            {
                ConferenceUser curUser = users.Where(x => x.UserID == TotalUsers[0].UserID).FirstOrDefault();
                if (curUser != null)
                {
                    TotalUsers[0].ConnectionId = curUser.ConnectionId;
                }
                if (users.Count > 1)
                {
                    foreach (ConferenceUser conuser in users)
                    {
                        if (conuser.UserID != TotalUsers[0].UserID)
                        {
                            TotalUsers.Add(conuser);
                        }
                    }
                }
                Application.Current.Properties["ChatUserData"] = users;
                ConfUser = users;
            });
            StartHubConnection();
        }

        async Task StartHubConnection()
        {
            await hubConnection.StartAsync();
            IsConnected = true;
        }


        async Task ConnectMe()
        {
            try
            {
                await hubConnection.InvokeAsync("Join", ChatUser.FirstName + " " + ChatUser.LastName, ChatUser.UserID, ChatUser.ProfileImageName, ChatUser.AccountID, ChatUser.WorkspaceID);
                IsConnected = true;
            }
            catch (Exception ex)
            {

            }
        }

        async Task SendMessageToUser()
        {
            await hubConnection.InvokeAsync("BroadcastMessageToUser", ConfMsg);
            //MessageModel curMsg = new MessageModel();
            //curMsg.UserID = Convert.ToString(ChatUser.UserID);
            //curMsg.UserName = ChatUser.FirstName + " " + ChatUser.LastName;
            //curMsg.MessageText = ConfMsg.Message;
            //curMsg.MessageTime = System.DateTime.Now.ToString("hh:mm tt");
            //curMsg.IsOwnMessage = true;
            //Messages.Add(curMsg);
        }

        async Task ConnectParticipant(UserProfileMob objParticipant)
        {
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("Join", objParticipant.UserName, objParticipant.UserID, objParticipant.ProfileImageName, objParticipant.AccountID, objParticipant.WorkspaceID);

            IsConnected = true;
        }
        //async Task SendMessageToUser(string user, string message)
        //{
        //    await hubConnection.InvokeAsync("SendMessage", user, message);
        //}


        async Task Connect()
        {
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("Join", Name);

            IsConnected = true;
        }

        //async Task SendMessage(string user, string message)
        //{
        //    await hubConnection.InvokeAsync("SendMessage", user, message);
        //}

        async Task Disconnect()
        {
            await hubConnection.InvokeAsync("LeaveChat", Name);
            await hubConnection.StopAsync();

            IsConnected = false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
