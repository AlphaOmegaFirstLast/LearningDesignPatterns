using System;
using System.Threading.Tasks;
using LearningBeta08.Package.SystemManagers;
using LearningBeta08.Package.SystemModels;

namespace LearningBeta08.Package.DesignPatterns.FactoryMethod
{
    //----------------------------
    public class FactoryMethod
    {
        protected string Name;

        public async Task<ApiResponse<string>> RunLogic(string appBasePath)
        {
            var product = GetProduct();    //product is overriden in the derived classes
            return await product.GetExample(appBasePath);
        }

        protected virtual FactoryMethod GetProduct()
        {
            Name = "Default object for the Factory";
            return this;
        }

        public async Task<ApiResponse<string>> GetExample(string appBasePath)
        {
            var textFileManager = new TextFileManager();
            var example = await textFileManager.ReadText(appBasePath + "/App_Data/DesignPatternsExamples/FactoryMethod.txt");
            example.Data = Name + " : " + Environment.NewLine + example.Data;
            return example;
        }
    }
    //----------------------------

    public class Product1 : FactoryMethod
    {
        protected override FactoryMethod GetProduct()
        {
            Name = "Product 1";
            return this;
        }
    }
    //----------------------------
    public class Product2 : FactoryMethod
    {
        protected override FactoryMethod GetProduct()
        {
            Name = "Product 2";
            return this;
        }
    }
}
