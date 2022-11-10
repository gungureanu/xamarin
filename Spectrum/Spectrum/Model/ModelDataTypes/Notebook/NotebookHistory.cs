using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class NotebookHistory : BaseEntity
    {
        public int NotebookHistoryID { get; set; }
        public int NotebookID { get; set; }
        public int NotebookPageID { get; set; }
        public string NoteDetails { get; set; }
        public string NotebookName { get; set; }        
        public List<NotebookHistory> NotebookHistoryList { get; set; }
        public List<NotebookPage> NotebookPageList { get; set; }
        public string UserName { get; set; }
        public int ModuleID { get; set; }
        public Guid AccountID { get; set; }
        public int IsTodaysDate { get; set; }
    }
}
