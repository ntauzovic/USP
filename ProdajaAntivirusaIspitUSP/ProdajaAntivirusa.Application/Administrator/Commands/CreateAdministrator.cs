using MediatR;
using ProdajaAntivirusa.Application.Common.Dto.User;
using ProdajaAntivirusa.Application.Common.Interfaces;

namespace ProdajaAntivirusa.Application.Administrator.Commands;

public record CreateAdministrator(string firstName,string lastName,string emailAddress,double novac) : IRequest;

public class CreateAdministratorHandler : IRequestHandler<CreateAdministrator>
{
    
    private readonly IUserService _userService;

    public CreateAdministratorHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task Handle(CreateAdministrator request, CancellationToken cancellationToken)
    {
        await _userService.CreateUserAsync(request.firstName,request.lastName,request.emailAddress,request.novac,
            new List<string> { ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Marketing });}
}