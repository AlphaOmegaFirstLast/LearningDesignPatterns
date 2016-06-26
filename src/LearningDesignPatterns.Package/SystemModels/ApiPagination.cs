using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningBeta08.Package.SystemModels
{
    public class ApiPagination
    {
        public int TotalRecCount { get; set; }
        public int TotalPageCount { get; set; }
        public string CurrentPage { get; set; }

    }
}
