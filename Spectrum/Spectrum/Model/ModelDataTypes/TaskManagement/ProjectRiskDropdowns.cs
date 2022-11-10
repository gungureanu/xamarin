using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class ProjectRiskDropdowns : BaseEntityOptional
    {

        public class RiskType
        {
            public int RiskTypeID { get; set; }
            public string RiskTypeName { get; set; }
        }

        public class RiskReviewPatterns
        {
            public int RiskReviewPatternID { get; set; }
            public string RiskReviewPattern { get; set; }
        }

        public class RiskMigrationStrategies
        {
            public int RiskMigrationStrategyID { get; set; }
            public string RiskMigrationStrategy { get; set; }
        }

        public class RiskStatus
        {
            public int RiskStatusID { get; set; }
            public string StatusName { get; set; }
        }
    }
}
