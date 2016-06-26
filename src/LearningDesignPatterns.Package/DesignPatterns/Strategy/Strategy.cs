﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using LearningBeta08.Package.SystemManagers;
using LearningBeta08.Package.SystemModels;
using Microsoft.AspNet.Mvc.ModelBinding.Validation;

namespace LearningBeta08.Package.DesignPatterns.Strategy
{
    public interface IStrategy
    {
        Task<ApiResponse<string>> GetExample(string appBasePath);
    }

    //----------------------------
    public class Strategy:IStrategy
    {
        private IStrategy _strategy;

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public async Task<ApiResponse<string>> GetExample(string appBasePath)
        {
            return await _strategy.GetExample(appBasePath);
        }
    }
    //-------------------------------

    public class Strategy1 : IStrategy
    {
        public async Task<ApiResponse<string>> GetExample(string appBasePath)
        {
            var textFileManager = new TextFileManager();
            var example = await textFileManager.ReadText(appBasePath + "/App_Data/DesignPatternsExamples/Strategy.txt");
            example.Data = "Called from Strategy1: " + Environment.NewLine + example.Data;
            return example;
        }
    }

    public class Strategy2 : IStrategy
    {
        public async Task<ApiResponse<string>> GetExample(string appBasePath)
        {
            var textFileManager = new TextFileManager();
            var example = await textFileManager.ReadText(appBasePath + "/App_Data/DesignPatternsExamples/Strategy.txt");
            example.Data = "Called from Strategy2: "+ Environment.NewLine + example.Data;
            return example;
        }
    }
}
