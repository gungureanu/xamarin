using System;
using System.Collections.Generic;
namespace Spectrum.Model.ModelDataTypes
{
    public class ClockInActivity
    {
        public DateTime FirstDateOfWeek { get; set; }
        public DateTime CurrentDate { get; set; }
        public int BreakOut1Count { get; set; }
        public int BreakIn1Count { get; set; }
        public int BreakOut2Count { get; set; }
        public int BreakIn2Count { get; set; }
    }
    public class ClockInActivityDates
    {
        public ClockInActivityDates()
        {
            ClockInActivityStatusesList = new List<ClockInActivityStatus>();
        }
        public string Dates { get; set; }
        public string Day { get; set; }
        public bool IsCurrentDate { get; set; }
        public bool IsMultiple { get; set; }
        public List<ClockInActivityStatus> ClockInActivityStatusesList { get; set; }
        public string ClockDate { get; set; }
        public InAndOutBoard InAndOutBoardItem { get; set; }
    }
    public class ClockInActivityStatus
    {
        public int TaskTimerID { get; set; }
        public string Activity { get; set; }
        public string Time { get; set; }
        public DateTime StartTime { get; set; }
        public int ActivityDurationInSecond { get; set; }
        public int Rank { get; set; }
        public string MultiDurationStatus { get; set; }
        
    }
    public class PunchCardDetail
    {
        public Guid UserID { get; set; }
        public List<ClockInActivityDates> ClockInActivityDates = new List<ClockInActivityDates>();
        public List<ClockInActivityStatus> ClockActivitySummary = new List<ClockInActivityStatus>();      
        public ClockInActivity ClockInActivity { get; set; }
        public List<TaskMonthList> TaskMonthList = new List<TaskMonthList>();
        public CustomMessage CustomMessage = new CustomMessage();
        public List<ProjectTaskDetailProfile> ProjectTask = new List<ProjectTaskDetailProfile>();
        public List<TaskTimeSheet> TaskTimeSheet = new List<TaskTimeSheet>();
        public List<TimesheetAdministrationDetail> AdministrationData = new List<TimesheetAdministrationDetail>(); 
    }
    public class TimesheetAdministrationDetail
    {
        public Guid UserID { get; set; }
        public DateTime ClockInNow { get; set; }
        public string RegularHour { get; set; }
        public string OverheadHour { get; set; }
        public string MeetingHour { get; set; }
        public string PaidSickHour { get; set; }
        public string ClockDate { get; set; }
    }
}
