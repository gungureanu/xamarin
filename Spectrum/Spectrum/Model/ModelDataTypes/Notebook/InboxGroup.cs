using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class InboxGroup
    {
        public int Id { get; set; }
        public string GroupDatename { get; set; }
        public DateTime GroupDate { get; set; }
        public bool GroupType { get; set; }
        public int TotalTask { get; set; }
        public List<TaskInbox> TaskInboxList = new List<TaskInbox>();
    }
}
