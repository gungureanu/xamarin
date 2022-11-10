using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
namespace Spectrum.Model.ModelDataTypes
{
    public class TaskTimeSheetDate
    {
        public int Date { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Day { get; set; }
        public string MonthName { get; set; }
        public string MonthFullName { get; set; }
        public int DaysInMonth { get; set; }
        public int WeekDay { get; set; }
        public List<TaskTimeSheet> TaskTimeSheets = new List<TaskTimeSheet>();
        public DateTime TimesheetDate { get; set; }
        public int HoursTaken { get; set; }
        public int MinutesTaken { get; set; }
        public bool Billable { get; set; }
        public Guid UserID { get; set; }
        public Guid AccountID { get; set; }
        public int ModuleID { get; set; }
        public bool IsError { get; set; }

    }
    public class TaskTimeSheetHours
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public string Comments { get; set; }
    }
    public class TaskMonthList
    {
        public int MonthValue { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
        public int DaysInMonth { get; set; }
        public List<TaskTimeSheetDate> DateList { get; set; }
        public List<ProjectTaskDetailProfile> ProjectTask = new List<ProjectTaskDetailProfile>();
        public string TimesheetFor { get; set; }
        public string DisplayTimesheetFor { get; set; }
        public string FileName { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class TaskTimeSheet
    {
        public Int64 TaskTimeSheetID { get; set; }
        public string TSID { get; set; }
        public Int64 ProjectID { get; set; }
        public Int64 GroupID { get; set; }
        public Int64 TaskID { get; set; }
        public string TimeSheetDate { get; set; }
        public int HoursTaken { get; set; }
        public int MinutesTaken { get; set; }
        public string Comment { get; set; }
        public bool Billable { get; set; }
        public Guid UserID { get; set; }
        public Guid LastUpdatedBy { get; set; }

        public bool IsTimer { get; set; }
        public DateTime SubmittedDate { get; set; }
        public Guid AccountID { get; set; }
        public int ModuleID { get; set; }
        public int LanguageID { get; set; }
        public string UserImage { get; set; }
        public string UserName { get; set; }
        public int WorkspaceID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
        public static DateTime LastDayOfMonth_AddMethod(this DateTime value)
        {
            return value.Date.AddDays(1 - value.Day).AddMonths(1).AddDays(-1);
        }
        public static string ToMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }
    }
}
