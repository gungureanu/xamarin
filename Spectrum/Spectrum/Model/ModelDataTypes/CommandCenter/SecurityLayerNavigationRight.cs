using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class SecurityLayerNavigationRight
    {
        public SecurityLayerNavigationRight()
        {
            NavList = new List<SecurityLayerNavigationRight>();
        }
        public int ModuleID { get; set; }
        public int NavigationID { get; set; }
        public int CompareID { get; set; }
        public string NavigationName { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string Levels { get; set; }   
        public string IsGrantText { get; set; }
        public bool IsAllow { get; set; }
        public string FileName { get; set; }
        public int GroupID { get; set; }
        public Guid UserID { get; set; }
        public Guid AccountID { get; set; }
        public string NavRightSidePanelName { get; set; }
        public List<SecurityLayerNavigationRight> NavList { get; set; }
        public string CCIsGrantText { get; set; }
        public bool CCIsAllow { get; set; }
        public long RuleID { get; set; }
        public bool Active { get; set; }
        public int RoleID { get; set; }
        public string RuleType { get; set; }
    }
}
