using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LearningBeta08.Package.SystemInterfaces;
using LearningBeta08.Package.SystemModels;

namespace LearningBeta08.Package.SystemManagers
{
    public class CacheManager
    {
        private readonly IApplicationCache _cache;
        private readonly ITextFileManager _textFileManager;
        private readonly IXmlFileManager _xmlFileManager;
        private readonly ISerializer _serializer;

        public CacheManager(IApplicationCache cache, ITextFileManager textFileManager, IXmlFileManager xmlFileManager, ISerializer serializer)
        {
            _cache = cache;
            _textFileManager = textFileManager;
            _xmlFileManager = xmlFileManager;
            _serializer = serializer;
        }
        private ApiResponse<T> ReadFromCache<T>(CacheInfo cacheInfo)
        {
            var response = new ApiResponse<T>();
            if (cacheInfo.Read)
            {
                if (cacheInfo.IsSerialized)
                {
                    response = _serializer.Deserialize<T>(_cache.Get<string>(cacheInfo.CacheKey).Data); //todo handle error
                }
                else
                {
                    response = _cache.Get<T>(cacheInfo.CacheKey);
                }
            }
            return response;
        }
        //------------------------------------------------------------------------------------------------------------------
        private void WriteToCache<T>(CacheInfo cacheInfo, ApiResponse<T> response)
        {
            if (cacheInfo.Write && cacheInfo.CacheTimeMin > 0 && response.Status.Ok && response.Data != null)
            {
                if (cacheInfo.IsSerialized)
                {
                    var serializedData = _serializer.Serialize(response.Data);
                    _cache.Set(cacheInfo.CacheKey, serializedData, cacheInfo.CacheTimeMin);
                }
                else
                {
                    _cache.Set(cacheInfo.CacheKey, response.Data, cacheInfo.CacheTimeMin);
                }
            }

        }
        //------------------------------------------------------------------------------------------------------------------
        public async Task<ApiResponse<string>> ReadText(string fileName)
        {
            var cacheInfo = new CacheInfo(fileName);
            var response = ReadFromCache<string>(cacheInfo);

            if (!response.Status.Ok || response.Data == null)
            {
                response = await _textFileManager.ReadText(fileName);
                WriteToCache<string>(cacheInfo, response);
            }
            return response;
        }
        //------------------------------------------------------------------------------------------------------------------
        public ApiResponse<T> ReadXml<T>(string fileName)
        {
            var cacheInfo = new CacheInfo(fileName);
            var response = ReadFromCache<T>(cacheInfo);

            if (!response.Status.Ok || response.Data == null)
            {
                response = _xmlFileManager.ReadXml<T>(fileName);
                WriteToCache<T>(cacheInfo, response) ;
            }
            return response;
        }
        //------------------------------------------------------------------------------------------------------------------

    }
}
