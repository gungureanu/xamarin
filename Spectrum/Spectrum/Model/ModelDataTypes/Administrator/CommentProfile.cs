using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class CommentProfile : BaseEntityOptional
    {
        public Guid AccountID { get; set; }
        public int WorkSpaceID { get; set; }        
        public Int64 RecordID { get; set; }
        public int LanguageID { get; set; }
        public int ModuleID { get; set; }
        public int SubModuleID { get; set; }
        public Int64 TaskCommentID { get; set; }
        public Int64 CommentID { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public string Description { get; set; }
        //public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }
        public string ImagePath { get; set; }
        public string CommentTo { get; set; }
    }
}
