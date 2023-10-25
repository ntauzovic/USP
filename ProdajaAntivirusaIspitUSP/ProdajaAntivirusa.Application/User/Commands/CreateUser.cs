using MediatR;
using ProdajaAntivirusa.Application.Common.Interfaces;

namespace ProdajaAntivirusa.Application.User.Commands;

public record CreateUser(string UserName,string lastName,string emailAddress,double novac) : IRequest;

public class CreateUserHandler : IRequestHandler<CreateUser>
{
    
    private readonly IUserService _userService;

    public CreateUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Handle(CreateUser request, CancellationToken cancellationToken)
    {
        await _userService.CreateUserAsync(request.UserName, request.lastName, request.emailAddress, request.novac,
            new List<string>
                { ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.User });
    }
}