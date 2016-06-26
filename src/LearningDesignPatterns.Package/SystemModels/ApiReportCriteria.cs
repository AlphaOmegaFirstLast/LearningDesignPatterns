using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningBeta08.Package.SystemModels
{
    public class ApiReportCriteria
    {
        public string Title{ get; set; }
        public List<ReportField> DisplayFields{ get; set; }
        public List<ReportField> GroupBy { get; set; }
        public List<ReportField> OrderBy { get; set; }
        public List<ReportFilter> ValueFilters{ get; set; }
        public List<ReportFilter> RangeFilters { get; set; }       
    }
}
