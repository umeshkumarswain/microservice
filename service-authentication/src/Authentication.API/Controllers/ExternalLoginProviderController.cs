using Microsoft.AspNetCore.Mvc;
using MediatR;
using Authentication.Application.Features.ExternalProviders.Queries;
using Authentication.Application.Abstractions;
namespace Authentication.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ExternalLoginProviderController : ControllerBase
{
    private readonly IMediator _mediator;



    public ExternalLoginProviderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetExternalLoginProviders()
    {
        var products = await _mediator.Send(new GetAllExternalLoginProviders());
        return Ok(products);
    }
}