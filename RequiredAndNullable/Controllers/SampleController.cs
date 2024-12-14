using Microsoft.AspNetCore.Mvc;
using RequiredAndNullable.Models;

namespace RequiredAndNullable.Controllers;

[Route("[controller]")]
[ApiController]
public class SampleController : ControllerBase
{
    [HttpPost(Name = "PostSample")]
    public IActionResult Post([FromBody] SampleRequest request)
    {
        return Ok(request);
    }
}
