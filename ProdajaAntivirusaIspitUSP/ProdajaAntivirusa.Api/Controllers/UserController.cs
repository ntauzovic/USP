using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProdajaAntivirusa.Application.Administrator.Commands;
using ProdajaAntivirusa.Application.Administrator.Queries;
using ProdajaAntivirusa.Application.Customer.Commands;
using ProdajaAntivirusa.Application.MarketingEmployment.Commands;
using ProdajaAntivirusa.Application.User.Commands;

namespace ProdajaAntivirusa.Api.Controllers;


public class UserController: ApiControllerBase
{
 
    /*[HttpPost("CreatUser")]
    public async Task<ActionResult> CreatUse(CreateUserCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    [HttpDelete("DeleteUser")]
    public async Task<ActionResult> Delete(DeleteUserCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpPut("UpdateUser")]
    public async Task<ActionResult> UpdateUser(UpdateUserCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpGet("PagedList")]
    [Authorize(Roles = RentalCarAuthorization.Administrator)]

    public async Task<ActionResult> PagedList([FromQuery] GetUserPagedQuery query) => Ok(await Mediator.Send(query));
    
    
   */
    
    [HttpPost("Registracija")]
    public async Task<ActionResult> CreateCustomer(CreateUser command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("CreateAdministrator")]
    [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Administrator)]
    public async Task<ActionResult> CreateAdministrator(CreateAdministrator command)
    {
        await Mediator.Send(command);
        return Ok();
    }

   [HttpPost("CreateMarketingEmployment")]
   [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Administrator)]
   public async Task<ActionResult> CreateMarketingEmployment(CreateMarketingEmployment command)
   {
       await Mediator.Send(command);
       return Ok();
   }
   [HttpPut("UpdateUser")]
   [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Administrator)]

   public async Task<ActionResult> UpdateUser(UpdateUsersCommand command)
   {
       await Mediator.Send(command);
       return Ok();
   }
   
   [HttpDelete("DeleteUser")]
   [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Administrator)]
   public async Task<ActionResult> Delete(DeleteCustomerCommand command)
   {
       await Mediator.Send(command);
       return Ok();
   }
   
   
   
   [HttpGet("GetOneUser")]
   [Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Administrator)]
   public async Task<ActionResult> GetOneUser([FromQuery] GetOneUserQuery query)
   {
       return Ok(await Mediator.Send(query));
   }
   
   [HttpGet("GetAllUsers")]
   //[Authorize(Roles = ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Administrator)]
   public async Task<ActionResult> allUsers([FromQuery] GetAllUsersQuery query) => Ok(await Mediator.Send(query));
}