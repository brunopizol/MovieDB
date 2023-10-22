using Microsoft.AspNetCore.Mvc;

namespace MovieDB.WebApi.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        //    private readonly IRequestExecutor _executor;

        //    public GraphQLController(IRequestExecutor executor)
        //    {
        //        _executor = executor;
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> Post([FromBody] GraphQLRequest request)
        //    {
        //        var result = await _executor.ExecuteAsync(request);
        //        return Ok(result);
        //    }
    }
}
