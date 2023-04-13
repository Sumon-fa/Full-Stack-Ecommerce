using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace backend.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[Route("api/v1/[controller]s")]

public abstract class ApiControllerBase : ControllerBase
{

}
