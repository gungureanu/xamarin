using System;
namespace Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes
{
    public class RibbonBarButtonsProfile : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public Int64 RibbonBar_ButtonID { get; set; }
        public Int64 RibbonBar_SectionID { get; set; }
        //public Int64 RibbonBarButtonId { get; set; }
        //public Int64 RibbonBarSectionId { get; set; }
        public Int64 IconId { get; set; }
        public string ButtonType { get; set; }
        public string ButtonName { get; set; }
        public string ButtonToolTip { get; set; }
        public string Description { get; set; }
        public string CommandName { get; set; }
        public string ExecuteCode { get; set; }
        public Int64 DisplayOrder { get; set; }
        public Int64 LanguageId { get; set; }
        public bool EnableDropList { get; set; }
        public string IconAltText { get; set; }
        public string FileName { get; set; }
        public string IconCSS { get; set; }
        public bool Active { get; set; }

        //Added Thease Field due to Display the Privilages Check Or False 
        public bool IsCreate { get; set; }
        public bool IsView { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        //-----------------------------------------------------------------
        //=== FOR THE PURPOSE TO HIDE THE CHECK BOX ON APPS AND MODULE PAGE 
        //-----------------------------------------------------------------
        public bool IsChkCreate { get; set; }
        public bool IsChkView { get; set; }
        public bool IsChkEdit { get; set; }
        public bool IsChkDelete { get; set; }
     

    }
}
