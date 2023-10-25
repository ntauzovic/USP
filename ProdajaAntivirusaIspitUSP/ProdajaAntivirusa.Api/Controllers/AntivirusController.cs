using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProdajaAntivirusa.Application.Antivirus.Commands;
using ProdajaAntivirusa.Application.Antivirus.Queries;

namespace ProdajaAntivirusa.Api.Controllers;


[Route("[controller]/[action]")]

public class AntivirusController : ApiControllerBase
{
    
    [HttpPost("CreateAntivirus")]
    [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Marketing)]
    public async Task<ActionResult> CreateAntivirus(CreateAntivirusCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    [HttpDelete("DeleteAntivirus")]
    [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Marketing)]
    public async Task<ActionResult> Delete(DeleteAntivirusCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    [HttpPut("UpdateAntivirus")]
    [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Marketing)]
    public async Task<ActionResult> UpdateAntivirus(UpdateAntivirusCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpGet("GetOneAntivirus")]
    [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Marketing)]
    public async Task<ActionResult> GetOneAntivirus([FromQuery] GetAntivirusQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpGet("List")]
    //[Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Marketing)]
    public async Task<ActionResult> List([FromQuery] GetAntivirusListQuery query) => Ok(await Mediator.Send(query));


}