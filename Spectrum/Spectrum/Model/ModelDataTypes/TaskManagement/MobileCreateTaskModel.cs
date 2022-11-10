﻿using System;
namespace Spectrum.Model.ModelDataTypes
{
    public class MobileCreateTaskModel
    {
        public Int64 ProjectID { get; set; }
        public string TaskName { get; set; }
        public Int64 TaskTypeID { get; set; }
        public Int64 TaskTypeCategoryID { get; set; }
        public Int64 PriorityID { get; set; }
        public Guid ProjectManagerID { get; set; }
        public Guid TaskOwnerID { get; set; }
        public string Description { get; set; }
        public string SubmitDate { get; set; }
        public string DueDate { get; set; }
        public Guid AccountID { get; set; }
        public Guid UserID { get; set; }
        public Guid CompanyID { get; set; }
        public int ModuleID { get; set; }
        public int WorkspaceID { get; set; }

    }
}
