using System;
using System.Threading.Tasks;
using LearningBeta08.Package.DesignPatterns.Factory;
using LearningBeta08.Package.DesignPatterns.FactoryMethod;
using Microsoft.AspNet.Mvc;
using LearningBeta08.Package.DesignPatterns.Singleton;
using LearningBeta08.Package.DesignPatterns.Strategy;
using LearningBeta08.Package.SystemModels;
using Microsoft.Dnx.Runtime;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningDesignPatterns.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class apiDesignPatternsController : Controller
    {
        private readonly IApplicationEnvironment _applicationEnvironment;
        private const string htmlNewLine = "HtmlNewLine";
        public apiDesignPatternsController(IApplicationEnvironment applicationEnvironment)
        {
            _applicationEnvironment = applicationEnvironment;
        }

        [HttpGet]
        [Route("GetSimpleSingleton")]
        public async Task<string> GetSimpleSingleton()
        {
            var obj = SimpleSingleton.GetInstance();
            var response = await obj.GetExample(_applicationEnvironment.ApplicationBasePath);
            return response.Data;
        }

        [HttpGet]
        [Route("GetDoubleCheckLockSingleton")]
        public async Task<string> GetDoubleCheckLockSingleton()
        {
            var obj = DoubleCheckLockSingleton.GetInstance();
            var response = await obj.GetExample(_applicationEnvironment.ApplicationBasePath);
            return response.Data;
        }
        [HttpGet]
        [Route("GetEagerLoadSingleton")]
        public async Task<string> GetEagerLoadSingleton()
        {
            var obj = EagerLoadSingleton.GetInstance();
            var response = await obj.GetExample(_applicationEnvironment.ApplicationBasePath);
            return response.Data;
        }

        [HttpGet]
        [Route("GetStrategy/{id}")]
        public async Task<string> GetStrategy(int id)
        {
            var obj = new Strategy();
            switch (id)
            {
                case 1:
                    obj.SetStrategy(new Strategy1());
                    break;
                case 2:
                    obj.SetStrategy(new Strategy2());
                    break;
                default:
                    throw new Exception("Unknown Strategy");
            }

            var response = await obj.GetExample(_applicationEnvironment.ApplicationBasePath);
            return response.Data;
        }

        [HttpGet]
        [Route("GetFactory/{id}")]
        public async Task<string> GetFactory(int id)
        {
            var obj = new Factory();
            var product = obj.GetProduct(id);
            var response = await product.GetExample(_applicationEnvironment.ApplicationBasePath);
            return response.Data;
        }

        [HttpGet]
        [Route("GetFactoryMethod/{id}")]
        public async Task<string> GetFactoryMethod(int id)
        {
            switch (id)
            {
                case 1:
                    var obj1 = new Product1();
                    var response1 = await obj1.RunLogic(_applicationEnvironment.ApplicationBasePath);
                    return response1.Data;
                case 2:
                    var obj2 = new Product2();
                    var response2 = await obj2.RunLogic(_applicationEnvironment.ApplicationBasePath);
                    return response2.Data;
            }
            return "id is not recognised";
        }

    }
}
