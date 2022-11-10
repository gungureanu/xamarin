namespace Spectrum.Model.ModelDataTypes
{
    public class Indenting
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public int PreviousParentID { get; set; }
        public int ProjectID { get; set; }
        public int CountSubTask { get; set; }
        public int Level { get; set; }
        public bool ActionDone { get; set; }
    }
}
