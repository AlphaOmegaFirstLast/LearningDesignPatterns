using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningBeta08.Package.SystemModels
{
    public class CacheInfo
    {
        public string CacheKey { get; set; } = string.Empty;
        public int CacheTimeMin { get; set; } = 60;
        public bool IsSerialized { get; set; } = false;
        public bool Read { get; set; } = true;
        public bool Write { get; set; } = true;

        public CacheInfo(string basicKey , dynamic param=null)
        {
            CacheKey = basicKey;
            if (param != null)
            {
                CacheKey = CacheKey + param.ToString();
            }
        }
    }
}
