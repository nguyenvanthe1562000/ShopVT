using GraphQL;
using Microsoft.AspNetCore.Mvc;
using ShopVT.GraphQL;
using System;
using System.Threading.Tasks;

namespace ShopVT.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private IDocumentExecuter _documentExecuter;

        public GraphQLController(IDocumentExecuter documentExecuter)
        {
            _documentExecuter = documentExecuter;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GraphqlQuery query)
        {

            if (query == null) { throw new ArgumentNullException(nameof(query)); }
            var executionOptions = new ExecutionOptions
            {
                Query = query.Query
            };
            var result = await _documentExecuter.ExecuteAsync(executionOptions);
            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
