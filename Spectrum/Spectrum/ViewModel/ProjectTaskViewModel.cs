using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Spectrum.Model.ModelDataTypes;
using Spectrum.Model.ModelDataTypes.TaskManagement;
using Spectrum.Service;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace Spectrum.ViewModel
{
    public class ProjectTaskViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;
        private const int PageSize = 10;
        private bool canLoad = true;
        public bool CanShowList = true;
        public bool CanShowNoTask = false;
        private int pageIndex = 1;
        private string MainListName = "";
        private Entry _lblCanShwList;
        readonly ProjectTaskService _taskService = new ProjectTaskService();

        public InfiniteScrollCollection<ProjectTaskDetail> Items { get; }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ProjectTaskViewModel(UserProfileMob objProfile, int ModuleID, int _projectID, bool AllTasks, Entry lblCanShwList)
        {
            try
            {
                _lblCanShwList = lblCanShwList;
                if (canLoad)
                {
                    Items = new InfiniteScrollCollection<ProjectTaskDetail>
                    {
                        OnLoadMore = async () =>
                        {
                            IsBusy = true;
                            List<ProjectTaskDetail> items = new List<ProjectTaskDetail>();
                            if (AllTasks)
                            {
                                items = await _taskService.GetAllProjectTaskListAsync(_projectID, objProfile.CompanyID.ToString(), objProfile.GroupID, objProfile.UserID.ToString(), pageIndex, ModuleID, objProfile.AccountID.ToString(), objProfile.WorkspaceID, MainListName);
                            }
                            else
                            {
                                items = await _taskService.GetMyProjectTaskListAsync(_projectID, objProfile.CompanyID.ToString(), objProfile.GroupID, objProfile.UserID.ToString(), pageIndex, ModuleID, objProfile.AccountID.ToString(), objProfile.WorkspaceID, MainListName);
                            }
                            if (pageIndex == 1)
                            {
                                if (items == null || items.Count == 0)
                                {
                                    _lblCanShwList.Text = "0";
                                    CanShowList = false;
                                    CanShowNoTask = true;
                                }
                                else
                                {
                                    _lblCanShwList.Text = "1";
                                    CanShowList = true;
                                    CanShowNoTask = false;
                                }
                            }
                            pageIndex++;
                            if (items == null || items.Count == 0 || items.Count < 15)
                            {
                                canLoad = false;
                            }
                            else
                            {
                                canLoad = true;
                            }
                            IsBusy = false;

                            // return the items that need to be added
                            if (items != null && items.Count > 0)
                            {
                                MainListName = items[items.Count - 1].MainListName;
                                //for (int x = 0; x < items.Count; x++)
                                //{
                                //    //List<DocumentUpload> lstdocuements = await _taskService.GetTaskDocuentsAsync(ModuleID, "ProjectTask", Convert.ToInt32(items[x].TaskID), objProfile.UserID.ToString(), objProfile.AccountID.ToString());
                                //    //if (lstdocuements != null && lstdocuements.Count > 0)
                                //    //{
                                //    //    items[x].HasAttachment = true;
                                //    //}
                                //    if (items[x].ReadStatus.ToLower() == "unread")
                                //    {
                                //        items[x].IsRead = true;
                                //    }
                                //    else
                                //    {
                                //        items[x].IsRead = false;
                                //    }
                                //    // Items.AddRange(items);
                                //}
                            }
                            return items;
                        },
                        OnCanLoadMore = () =>
                        {
                            return canLoad;
                        }
                    };

                    DownloadDataAsync(objProfile, ModuleID, pageIndex, PageSize, AllTasks, _projectID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task DownloadDataAsync(UserProfileMob objProfile, int ModuleID, Int32 CurpageIndex, Int32 PageSize, bool AllTasks, int ProjectID)
        {
            try
            {


                //var items = await _taskService.GetAllProjectTaskListAsync(1, objProfile.CompanyID.ToString(), objProfile.GroupID, objProfile.UserID.ToString(), pageIndex, ModuleID, objProfile.AccountID.ToString(), objProfile.WorkspaceID);
                List<ProjectTaskDetail> items = new List<ProjectTaskDetail>();
                if (AllTasks)
                {
                    items = await _taskService.GetAllProjectTaskListAsync(ProjectID, objProfile.CompanyID.ToString(), objProfile.GroupID, objProfile.UserID.ToString(), pageIndex, ModuleID, objProfile.AccountID.ToString(), objProfile.WorkspaceID, MainListName);
                }
                else
                {
                    items = await _taskService.GetMyProjectTaskListAsync(ProjectID, objProfile.CompanyID.ToString(), objProfile.GroupID, objProfile.UserID.ToString(), pageIndex, ModuleID, objProfile.AccountID.ToString(), objProfile.WorkspaceID, MainListName);
                }
                if (pageIndex == 1)
                {
                    if (items == null || items.Count <= 0)
                    {
                        _lblCanShwList.Text = "0";
                        CanShowList = false;
                        CanShowNoTask = true;
                    }
                    else
                    {
                        _lblCanShwList.Text = "1";
                        CanShowList = true;
                        CanShowNoTask = false;
                    }
                }
                pageIndex++;
                if (items == null || items.Count < 15)
                {
                    canLoad = false;
                }
                if (items != null && items.Count > 0)
                {
                    MainListName = items[items.Count - 1].MainListName;
                    //for (int x = 0; x < items.Count; x++)
                    //{
                    //    //List<DocumentUpload> lstdocuements = await _taskService.GetTaskDocuentsAsync(ModuleID, "ProjectTask", Convert.ToInt32(items[x].TaskID), objProfile.UserID.ToString(), objProfile.AccountID.ToString());
                    //    //if (lstdocuements != null && lstdocuements.Count > 0)
                    //    //{
                    //    //    items[x].HasAttachment = true;
                    //    //}
                    //    if (items[x].ReadStatus.ToLower() == "unread")
                    //    {
                    //        items[x].IsRead = true;
                    //    }
                    //    else
                    //    {
                    //        items[x].IsRead = false;
                    //    }
                    //    //  Items.AddRange(items);
                    //}
                    Items.AddRange(items);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
