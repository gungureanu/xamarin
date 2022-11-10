using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class WorkFlowStep
    {
        public WorkFlowStep()
        {           
            //WorkflowStepNumber = new List<ddList>();           
            //ApprovalActionList = new List<ddList>();         
            //RejectedActionList = new List<ddList>();            
        }
        public Int64 WorkflowStepID { get; set; }
        public Int64 WorkflowID { get; set; }
        public string WorkflowStepName { get; set; }
        public int WorkflowStepNo { get; set; }
        public string WorkflowStepDescription { get; set; }
        public bool StepApproval { get; set; }
        public int ResolutionID { get; set; }
        public int ActiveTicket { get; set; }
        public string ColorCode { get; set; }
        public string BackgroundColorCode { get; set; }
        
        public string ResolutionName { get; set; }
        public int StepApprovalNumber { get; set; }
        public string StepApprovalAction { get; set; }
        public string StepRejectedAction { get; set; }
        public bool Active { get; set; }    
        public int TotalAction { get; set; }
        public string LastUpdatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public int WorkflowIsChanged { get; set; }
        public List<WorkflowResolution> WorkflowResolutionList = new List<WorkflowResolution>();
        //public List<ddList> WorkflowStepNumber { get; set; }
        public List<UserProfile2> UserProfileList = new List<UserProfile2>();
        //public List<ResourceProfile> ResourceProfileList = new List<ResourceProfile>();
        public List<UserProfile2> ResourceProfile = new List<UserProfile2>();
        //  public List<ddList> ApprovalActionList { get; set; }
        //public List<ddList> RejectedActionList { get; set; }        
        public string Users { get; set; }
        public Guid UserID { get; set; }
        public Guid AccountID { get; set; }
        public int ModuleID { get; set; }
        public string ApproverInSteps { get; set; }
        public int ApprovalAction { get; set; }
        public int RejectedAction { get; set; }
        public string ReturnMessage { get; set; }
        public CustomMessage CustomMessage = new CustomMessage();
        public int LanguageID { get; set; }
    }
    //public class ddList
    //{
    //    public int Value { get; set; }
    //    public string Text { get; set; }
    //}
}
