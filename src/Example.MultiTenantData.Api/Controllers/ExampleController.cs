using Microsoft.AspNetCore.Mvc;

using MediatR;

using Example.MultiTenantData.BusinessLogic.Requests;
using Microsoft.AspNetCore.Authorization;

namespace Example.MultiTenantData.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class ExampleController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExampleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet(Name = "GetAllWithSpecifiedTenant")]
    public async Task<IActionResult> GetAllWithSpecifiedTenant(string tenant)
    {
        if (string.IsNullOrEmpty(tenant))
        {
            return BadRequest();
        }

        var exampleResult = await _mediator.Send(new GetAllSegregatedEntitiesRequest());
        return this.GetResult(exampleResult);
    }

    [HttpGet(Name = "GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllSegregatedEntitiesRequest());
        return this.GetResult(result);
    }
}
