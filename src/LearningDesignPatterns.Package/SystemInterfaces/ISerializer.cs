using LearningBeta08.Package.SystemModels;

namespace LearningBeta08.Package.SystemInterfaces
{
    public interface ISerializer
    {
        ApiResponse<T> Deserialize<T>(string json);
        ApiResponse<string> Serialize<T>(T obj);
    }
}