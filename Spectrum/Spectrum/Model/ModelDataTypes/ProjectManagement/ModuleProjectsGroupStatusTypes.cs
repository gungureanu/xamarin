using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class ModuleProjectsGroupStatusTypes
    {
      public Int64 GroupStatusID { get;set;} 
      public string GroupStatusName { get;set;}
      public string Description { get;set;}
      public bool Active { get;set;} 
      public DateTime CreatedDate { get;set;}
      public DateTime ModifiedDate { get;set;}
      public Guid CreatedBy { get;set;}
      public Guid LastUpdatedBy {get;set;}
    }
}
