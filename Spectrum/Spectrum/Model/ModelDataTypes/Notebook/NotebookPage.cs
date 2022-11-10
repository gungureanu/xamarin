using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class NotebookPage : BaseEntity
    {
        public int NotebookPageID { get; set; }
        public int NotebookID { get; set; }
        public int TeamID { get; set; }
        public string NotebookPageName { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public string NotebookName{ get; set; }
        public int ModuleID { get; set; }
        public Guid AccountID { get; set; }
    }

    public class VideoLinks : BaseEntity
    {
        public int VideoLinkID { get; set; }        
        public string VideoLinkFor { get; set; }
        public string VideoUrl { get; set; }      
    }
}
