using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class ProjectGroupComments : BaseEntity
    {
        public Int64 Group_CommentID { get; set; }
        public Int64 GroupID { get; set; }
        public int GroupTypeID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string CommentText { get; set; }
        public string ImageName { get; set; }
        public string CustomDateTime { get; set; }
        public string ImagePath { get; set; }
    }
}
