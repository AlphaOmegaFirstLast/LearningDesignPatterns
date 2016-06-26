using System.Threading.Tasks;
using LearningBeta08.Package.SystemModels;

namespace LearningBeta08.Package.SystemInterfaces
{
    public interface ITextFileManager
    {
        Task<ApiResponse<string>> ReadText(string fileName);
        Task<ApiResponse<string>> WriteText(string fileName, string txt);
    }
}