using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;
using WordGenerator.Business;
using WordGenerator.Models;

namespace WordGenerator.Controllers
{
    public class GeneratorController : ApiController
    {
        #region Attributes
        private Generator Generator;
        private string ServerUrl;
        private int DegreeOfPararellism;
        #endregion

        #region Constructor
        public GeneratorController()
        {
            ServerUrl = WebConfigurationManager.AppSettings["WordProcessorUrl"];
            DegreeOfPararellism = int.Parse(WebConfigurationManager.AppSettings["SimultaneousTasks"]);
            Generator = new Generator();
            ServiceClient.ConsigureServer(ServerUrl);
        }
        #endregion

        [HttpGet]
        [Route("api/Generator/{quantity}")]
        public async Task<int> Generate(int quantity)
        {
            var messages = Generator.GetMessages(quantity);

            /*var paralel = messages.AsParallel().WithDegreeOfParallelism(DegreeOfPararellism);
            paralel.ForAll(async message =>
            {
                await ServiceClient.CreateMessageAsync(new Message { Input = message });
            });*/

            foreach(var message in messages)
                await ServiceClient.CreateMessageAsync(new Message { Input = message });   

            return messages.Count;
        }          
    }
}
