using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Features;
using LearningBeta08.Package.SystemInterfaces;

namespace LearningBeta08.Package.SystemManagers
{
    public class SessionCache : ISessionCache
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        // ReSharper disable once InconsistentNaming
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public SessionCache(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Get(string key)
        {
           return _session.GetString(key);
        }

        public void Set(string key, string value)
        {
            _session.SetString(key,value);
        }
    }

}

