using Application.DTO;
using Application.Features.Tenant.Queries.TenantGetQuery;
using Application.Features.Tenant.Queries.TenantListQuery;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Filters;

namespace WebApi.Controllers;

[Route("tenant")]
[ApiController]

public class TenantController : ControllerBase
{
    private readonly ISender _mediatr;

    public TenantController(ISender mediatr)
    {
        _mediatr = mediatr;
    }
    
    [ListResponseFilter<Tenant>]
    [HttpGet("list")]
    public async Task<ActionResult<PaginatedResponse<Tenant>>> List([FromQuery] TenantListQuery searchQuestionQuery)
    {
        var result = await _mediatr.Send(searchQuestionQuery);
        return result; 
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<PaginatedResponse<Tenant>>> Get([FromRoute] TenantGetQuery query)
    {
        var result =  await _mediatr.Send(query);
        if (result is not null)
        {
            return Ok(result);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost("create")]
    public async Task<ActionResult<Tenant>> Create([FromBody] RequestTenantDTO tenantDTO)
    {
        try
        {
    
            return NotFound();
        }
        catch (Exception e)
        {
            return NotFound(e);
        }
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<Tenant>> Update([FromBody] RequestTenantDTO tenantDto, [FromRoute(Name = "id")] int id)
    {
        try
        {

            return NotFound();
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }
    
}