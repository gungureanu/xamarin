namespace Spectrum.Model.ModelDataTypes
{
    public class CustomMessage
    {
        public bool IsAuthorized { get; set; }
        public int CaptionIconID { get; set; }
        public string FileName { get; set; }
        public string ActionMethod { get; set; }
        public string CaptionText { get; set; }
        public string MessageDetailText { get; set; }
        public string Description { get; set; }
        public bool ReturnMessage { get; set; }
        public string EmailAddress { get; set; }
        public string Status { get; set; }
    }
}
