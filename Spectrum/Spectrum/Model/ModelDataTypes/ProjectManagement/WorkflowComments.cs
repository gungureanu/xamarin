using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class WorkflowComments : BaseEntity
    {
        public int WorkflowCommentID { get; set; }
        public int WorkflowID { get; set; }
        public string CommentText { get; set; }
        public string UserName { get; set; }
        public string ImageName { get; set; }
        public string CustomDateTime { get; set; }
        public string ImagePath { get; set; }
    }
}
