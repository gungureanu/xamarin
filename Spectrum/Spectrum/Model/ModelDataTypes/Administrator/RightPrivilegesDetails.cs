using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class RightPrivilegesDetails : BaseEntity
    {
        public Int32 RightPrivilegesID { get; set; }
        public Guid AccountID { get; set; }
        public Int32 RoleID { get; set; }
        public Int64 ModuleID { get; set; }
        public bool IsGrant { get; set; }
        //public Int64 SubModuleID { get;set;} 
        public Int64 RibbonbarControlID { get; set; }
        public bool IsCreate { get; set; }
        public bool IsView { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool Active { get; set; }

        public string ColumnName { get; set; }
        public bool ColumnValue { get; set; }
        public CustomMessage CustomMessage { get; set; }
        public Guid UserID { get; set; }
        public string SectionName { get; set; }
        public string RibbonBarSectionID { get; set; }
        public string FileName { get; set; }
        public string TableName { get; set; }
        public string ColumnsValue { get; set; }
        public string RibbonbarControlName { get; set; }
        public int GroupID { get; set; }
        public long RuleID { get; set; }
        public bool CCIsCreate { get; set; }
        public bool CCIsView { get; set; }
        public bool CCIsEdit { get; set; }
        public bool CCIsDelete { get; set; }
        public string PermissionFor { get; set; }
        public string RuleType { get; set; }

    }
}
