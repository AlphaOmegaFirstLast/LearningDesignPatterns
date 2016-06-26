using LearningBeta08.Package.SystemModels;

namespace LearningBeta08.Package.SystemInterfaces
{
    public interface IXmlFileManager
    {
        ApiResponse<T> ReadXml<T>(string fileName);
        ApiResponse<T> WriteXml<T>(string fileName, T obj);
    }
}