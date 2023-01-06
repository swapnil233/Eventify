using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    private IMediator _mediator;

    // Populate _mediator with the IMediator service if derived class doesn't have it already
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
