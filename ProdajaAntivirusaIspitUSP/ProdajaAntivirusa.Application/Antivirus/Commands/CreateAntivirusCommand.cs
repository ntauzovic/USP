using MediatR;
using MongoDB.Entities;
using ProdajaAntivirusa.Application.Common.Dto.Antivirus;
using ProdajaAntivirusa.Application.Common.Interfaces;
using ProdajaAntivirusa.Domain.Entities;

namespace ProdajaAntivirusa.Application.Antivirus.Commands;

public record CreateAntivirusCommand(AntivirusDetailsDto detailsDto) : IRequest
{
    
}

public class CreateAntivirusCommandHandler : IRequestHandler<CreateAntivirusCommand>


{
    
    private readonly IUserService _userService;

    public CreateAntivirusCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task Handle(CreateAntivirusCommand request, CancellationToken cancellationToken)
    {
        var vendor1 = await DB.Find<ProdajaAntivirusa.Domain.Entities.Vendor>()
            .OneAsync(request.detailsDto.Vendor,
                cancellationToken);

        if (vendor1 == null)
        {
            throw new Exception("Vendor not found");
        }

        

        var MarketingEmployment = new List<ProdajaAntivirusa.Domain.Entities.ApplicationUser>();
        foreach (var item in request.detailsDto.MarketingUser)
        {
            var user = await _userService.GetUserAsync(item);
                
            if (user == null)
            {
                throw new Exception("User is not found");
            }

            MarketingEmployment.Add(user);
        }
        
        

        

        var data = new Domain.Entities.Antivirus
        {
           Name = request.detailsDto.Name,
           Version = request.detailsDto.Version,
           Active = request.detailsDto.Active,
           Vendor = new One<ProdajaAntivirusa.Domain.Entities.Vendor>(vendor1),
           Opis = request.detailsDto.Opis,
           Cijean = request.detailsDto.Cijena,
           DatumIzdavanja = request.detailsDto.DatumIzdavanja,
           LinkZaPreuzimanje = request.detailsDto.LinkZaPreuzimanje
        };
        //await data.ApplicationUsers.AddAsync(users,cancellation:cancellationToken);
        //await data.OtherUsers.AddAsync(users,cancellation:cancellationToken);

        data.MarketingUser = new List<ApplicationUser>();
        
        data.MarketingUser.AddRange(MarketingEmployment);
        await data.SaveAsync(cancellation: cancellationToken);

        

    }
}