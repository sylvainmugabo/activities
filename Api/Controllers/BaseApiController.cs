using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController() : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>() ??
                                                  throw new InvalidOperationException("Mediator not registered");
    
    protected ActionResult HandleResult<T>(Result<T> result)
    {
        return result switch
        {
            { IsSuccess: true, Value: not null } => Ok(result.Value),
            { IsSuccess: false, Value: not null } => NotFound(result.Value),
            _ => BadRequest(result.Error)
        };
    }
}