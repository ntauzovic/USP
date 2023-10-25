using MediatR;
using ProdajaAntivirusa.Application.Administrator.Commands;
using ProdajaAntivirusa.Application.Common.Dto.User;
using ProdajaAntivirusa.Application.Common.Interfaces;

namespace ProdajaAntivirusa.Application.MarketingEmployment.Commands;

public record CreateMarketingEmployment(string firstName,string lastName,string emailAddress,double novac) : IRequest;

public class CreateMarketingEmploymentHandler : IRequestHandler<CreateMarketingEmployment>
{
    
    private readonly IUserService _userService;

    public CreateMarketingEmploymentHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task Handle(CreateMarketingEmployment request, CancellationToken cancellationToken)
    {
        await _userService.CreateUserAsync(request.firstName,request.lastName,request.emailAddress,request.novac,
            new List<string> { ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.Marketing });
        
    }

    
}