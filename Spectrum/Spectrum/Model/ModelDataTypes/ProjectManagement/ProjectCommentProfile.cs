using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class ProjectCommentProfile 
    {
        public Int64 ProjectCommentID { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }

        public string ImagePath { get; set; }
    }
}
