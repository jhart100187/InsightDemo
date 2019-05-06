using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Composition;
using Insight.Clients.Types;
using Insight.Clients.Metadata;
using Insight.Clients.RestClients;
using Insight.Common.Extensions;

namespace Insight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExampleController : ControllerBase
    {
        private readonly IRestClient _client;

        public ExampleController(IEnumerable<Lazy<IRestClient, ClientMetadata>> restClients)
        {
            _client = restClients.GetClient(ClientType.RestClient) ??
                      throw new Exception($"Unable to find client with type {ClientType.RestClient.ToString()}");
                        //Placeholder Exception until a custom Exception class is created in future work
        }

        [HttpGet]
        public ActionResult<object> Get()
        {
            var response = _client.CreateClient("https://www.exampleurl.com")
                .AddAuthentication()
                .CreateRequest("/example/example", HTTPMethod.POST)
                .AddHeader("content-type", "application/json")
                .AddBody(new object())
                .Execute<object>();
            
            return Ok(response);
        }
    }
}
