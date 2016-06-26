using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningBeta08.Package.SystemManagers;
using LearningBeta08.Package.SystemModels;

namespace LearningBeta08.Package.DesignPatterns.Singleton
{
    public class EagerLoadSingleton
    {
        private static readonly EagerLoadSingleton _instance = new EagerLoadSingleton();

        private EagerLoadSingleton()
        {
        }

        public static EagerLoadSingleton GetInstance()
        {
            return _instance;
        }

        public async Task<ApiResponse<string>> GetExample(string appBasePath)
        {
            var textFileManager = new TextFileManager();
            var example = await textFileManager.ReadText(appBasePath + "/App_Data/DesignPatternsExamples/EagerLoadSingleton.txt");
            return example;
        }
    }
}
