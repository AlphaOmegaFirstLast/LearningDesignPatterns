using System.Threading.Tasks;
using LearningBeta08.Package.SystemManagers;
using LearningBeta08.Package.SystemModels;

namespace LearningBeta08.Package.DesignPatterns.Singleton
{
    public class DoubleCheckLockSingleton
    {
        private static DoubleCheckLockSingleton _instance;
        private static readonly object _mylock = new object();

        private DoubleCheckLockSingleton()
        {
        }

        public static DoubleCheckLockSingleton GetInstance()
        {
            if (_instance == null)
            {
                lock (_mylock)
                {
                    if (_instance == null)
                    {
                        _instance = new DoubleCheckLockSingleton();
                    }
                }
            }
            return _instance;
        }

        public async Task<ApiResponse<string>> GetExample(string appBasePath)
        {
            var textFileManager = new TextFileManager();
            var example = await textFileManager.ReadText(appBasePath + "/App_Data/DesignPatternsExamples/DoubleCheckLockSingleton.txt");
            return example;
        }
    }
}
