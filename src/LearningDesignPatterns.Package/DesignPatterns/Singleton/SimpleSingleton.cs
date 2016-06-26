using System.Threading.Tasks;
using LearningBeta08.Package.SystemManagers;
using LearningBeta08.Package.SystemModels;

namespace LearningBeta08.Package.DesignPatterns.Singleton
{
    public class SimpleSingleton
    {
        private static SimpleSingleton _instance;

        private SimpleSingleton()
        {
        }

        public static SimpleSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SimpleSingleton();
            }
            return _instance;
        }

        public async Task<ApiResponse<string>> GetExample(string appBasePath)
        {
            var textFileManager = new TextFileManager();
            var example = await textFileManager.ReadText(appBasePath + "/App_Data/DesignPatternsExamples/SimpleSingleton.txt");
            return example;
        }
    }
}
