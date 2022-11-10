using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class DocumentUpload
    {
        public Int64 DocumentUploadID { get; set; }
        public int ModuleID { get; set; }
        public int SubModuleID { get; set; }
        public Int64 RecordID { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public string FilePath { get; set; }
        public string FileSize { get; set; }
        public string VersionNumber { get; set; }
        public string Description { get; set; }
        public string FileExtension { get; set; }
        public string SubModuleName { get; set; }
        public Guid CreatedBy { get; set; }
        public string UserName { get; set; }
        public string FileExtention { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}

