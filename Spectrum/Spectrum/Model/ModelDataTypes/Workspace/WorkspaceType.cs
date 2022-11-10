﻿using System;
using System.Collections.Generic;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;

namespace Spectrum.Model.ModelDataTypes
{
    public class WorkspaceItem : BaseEntity
    {
        public Guid AccountID { get; set; }
        public Guid CompanyID { get; set; }
        public Guid CustodianID { get; set; }
        public int ModuleID { get; set; }
        public int WorkSpaceID { get; set; }
        public int ParentWorkSpaceID { get; set; }
        public int LanguageID { get; set; }
        public int WorkspaceTypeID { get; set; }
        public string UserName { get; set; }
        public string WorkspaceTypes { get; set; }
        public string WorkspaceDescription { get; set; }
        public string WorkspaceName { get; set; }
        public string ParentWorkspaceName { get; set; }
        public string FileName { get; set; }
        public string WorkspaceIconName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDefault { get; set; }
        public string ReturnMessage { get; set; }
        public bool IsStopped { get; set; }
        public bool IsPaused { get; set; }
        public bool IsRunning { get; set; }
        public bool IsDeleted { get; set; }
        public bool Active { get; set; }
        public Int64 NoOfUser { get; set; }
        public CustomMessage CustomMessage = new CustomMessage();
        public bool IsGranted { get; set; }
        public bool IsDenied { get; set; }
        public bool IsUserDefaultWorkSpace { get; set; }
        public List<PortfolioProfile> PortfolioProfile = new List<PortfolioProfile>();
        public List<WorkspaceItem> WorkspaceList = new List<WorkspaceItem>();
        public List<ModuleMainTabs> ListModuleDetails = new List<ModuleMainTabs>();
        public List<ProjectListProfile> lstProject = new List<ProjectListProfile>();
        public List<TeamProfile> TeamList = new List<TeamProfile>();
        public List<PortfolioProfile> PortFolioList = new List<PortfolioProfile>();
        public List<WorkspaceItem> SubWorkspaceItemList = new List<WorkspaceItem>();
        public string Type { get; set; }
        public bool IsPortfolioWorkspace { get; set; }
        public bool IsSubworkspace { get; set; }
        public bool IsResourceAccount { get; set; }
    }

}
