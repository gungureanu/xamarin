using System;
using System.Collections.Generic;

namespace Spectrum.Model.ModelDataTypes
{
    public class FilterColumnDetail
    {
        public string operators { get; set; }
        public string field { get; set; }
        public int fieldOption { get; set; }
        public string filterValue { get; set; }
        public int columnOperatorId { get; set; }
        public string columnOperatorName { get; set; }
        public string type { get; set; }

    }

    public class FilterColumnConditionViewModel : BaseEntity
    {
        public Guid CompanyID { get; set; }
        public Guid AccountID { get; set; }
        public List<FilterColumnDetail> FilterColumnConditionList { get; set; }
        public List<string> WhereCondition { get; set; }
        public string filterName { get; set; }
        public bool isGlobalFilter { get; set; }
        public Guid UserID { get; set; }
        public int ModuleID { get; set; }
    }

    public class FilterDetails
    {
        public int FilterID { get; set; }
        public string FieldName { get; set; }
        public bool IsGlobal { get; set; }
        public string Active { get; set; }

        public List<FilterColumnDetail> FilterDetailList { get; set; }

    }
}
