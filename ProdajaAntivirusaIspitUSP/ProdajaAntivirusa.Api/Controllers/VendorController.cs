using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProdajaAntivirusa.Api.Controllers;
using ProdajaAntivirusa.Application.Vendor.Commands;
using ProdajaAntivirusa.Application.Vendor.Queries;

namespace RentalCar.Api.Controllers;

[Route("[controller]/[action]")]

public class VendorController : ApiControllerBase
{
    [HttpPost("CreateVendor")]
    [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Marketing)]
    public async Task<ActionResult> CreateVendor(CreateVendorCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpPut("UpdateVendor")]
    [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Marketing)]
    public async Task<ActionResult> UpdateUser(UpdateVendorCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    
    
    [HttpDelete("DeleteVendor")]
    [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Marketing)]
    public async Task<ActionResult> Delete(DeleteVendorCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    [HttpGet("GetOneVendor")]
    [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Marketing)]

    public async Task<ActionResult> GetVendor([FromQuery] GetOneVendorsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    [HttpGet("GetAllVendor")]
    [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Marketing)]
    public async Task<ActionResult> PagedList([FromQuery] GetVendorListQuery query) => Ok(await Mediator.Send(query));

    [HttpGet("GetAllVendorNP")]
    [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Marketing)]
    public async Task<ActionResult> PagedList([FromQuery] GetVendorListQueryNP query) => Ok(await Mediator.Send(query));
    
}