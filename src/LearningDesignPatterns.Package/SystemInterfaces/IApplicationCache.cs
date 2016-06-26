using LearningBeta08.Package.SystemModels;

namespace LearningBeta08.Package.SystemInterfaces
{
    public interface IApplicationCache
    {
        ApiResponse<T> Get<T>(string key);
        ApiResponse<T> Get<T>(string key, bool isCacheSerialized);
        void Set(string key, object value , int cacheTimeMin = 20);
    }
}