using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.Caching.Memory;
using LearningBeta08.Package.SystemInterfaces;
using LearningBeta08.Package.SystemModels;

namespace LearningBeta08.Package.SystemManagers
{
    public class ApplicationCache : IApplicationCache
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ISerializer _serializer;

        public ApplicationCache(IMemoryCache memoryCache, ISerializer serializer)
        {
            _memoryCache = memoryCache;
            _serializer = serializer;
        }

        public void Set(string key, object value, int cacheTimeMin=20)  // todo set default value from config
        {
            var cacheOptions = new MemoryCacheEntryOptions() { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheTimeMin) };          
            _memoryCache.Set(key, value, cacheOptions);
        }

        public ApiResponse<T> Get<T>(string key)
        {
            var response = new ApiResponse<T>();
            try
            {
                object value;
                var ok = _memoryCache.TryGetValue(key, out value);
                if (ok)
                {
                    response.Data = (T)value;
                }
            }
            catch (Exception e)
            {
                response.Status.SetError(-1, "Application Error. casting", e);
            }

            return response;
        }

        public ApiResponse<T> Get<T>(string cacheKey, bool isCacheSerialized)
        {
            var response = new ApiResponse<T>();
            if (isCacheSerialized)
            {
                var cacheResponse = Get<string>(cacheKey);
                if (cacheResponse.Status.Ok && cacheResponse.Data != null)
                {
                    response = _serializer.Deserialize<T>(cacheResponse.Data);

                }
                else
                {
                    response.Status = cacheResponse.Status;
                }
            }
            else
            {
                response = Get<T>(cacheKey);
            }

            return response;
        }

    }
}
