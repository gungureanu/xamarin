using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class ProjectStateFields: BaseEntity
    {
        public string ProjectStateID { get; set; }
        public Int64 ProjectID { get; set; }
        public string ContractName { get; set; }
        public string ContractNumber { get; set; }
        public string ContractOwner { get; set; }
        public string ContractDescription { get; set; }
        public string CDTContact { get; set; }
        public string DepartmentName { get; set; }
        public string ProblemStatement { get; set; }
        public bool Section508Required { get; set; }
        public string ProjectRiskStatement { get; set; }
        public int BusinessStrategic { get; set; }
        public int Scope { get; set; }
        public string ScopeStatement { get; set; }
        public string Assumptions { get; set; }
        public string GovernanceBody { get; set; }
        public string ExecutiveSponsorName { get; set; }
        public int MetricMeasurement { get; set; }
        public bool Active { get; set; }

    }
}
