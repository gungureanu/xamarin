using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class ModuleProjectsGroupHistory
    {
        public Int64 GroupHistoryID { get;set;} 
        public Int64 ProjectID  { get;set;} 
        public Int64 GroupID { get;set;}
        public Int64 GroupStatusID  { get;set;}   
        public DateTime StatusChangedDate  { get;set;}
        public Guid StatusChangedBy { get;set;} 
        public DateTime CreatedDate { get;set;}
        public DateTime ModifiedDate { get;set;}   
        public Guid CreatedBy { get;set;} 
        public Guid LastUpdatedBy  { get;set;}
        public string ImageName { get; set; }

        public string GroupStatusName { get; set; }
        public string UserName { get; set; }
        public string ImagePath { get; set; }


    }
}
