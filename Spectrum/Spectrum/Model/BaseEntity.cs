using System;
namespace Spectrum.Model
{
    public class BaseEntity
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public Int64 CreateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public Int64 LastModifiedBy { get; set; }
        public DateTime LastModificationDate { get; set; }
    }
}
