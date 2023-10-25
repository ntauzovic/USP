using AutoMapper;
using MongoDB.Entities;
using ProdajaAntivirusa.Application.Common;
using ProdajaAntivirusa.Application.Common.Dto.Antivirus;


namespace ProdajaAntivirusa.Application.Mappers.Antivirus;

public class MappingProfile : Profile
{
    public MappingProfile()
    {


        CreateMap<UpdateAntivirusDto, ProdajaAntivirusa.Domain.Entities.Antivirus>().ReverseMap();


        CreateMap<AntivirusDetailsDto, ProdajaAntivirusa.Domain.Entities.Antivirus>().ReverseMap();
        CreateMap< ProdajaAntivirusa.Domain.Entities.Antivirus, Task<AntivirusDetailsDto>>()
            .ConstructUsing(x => GetAntivirusDetails(x));

        CreateMap<IEnumerable< ProdajaAntivirusa.Domain.Entities.Antivirus>, AntivirusPagedListDto>()
            .ConstructUsing(x => ToAntivirusList(x));

    }


    private static async Task<AntivirusDetailsDto> GetAntivirusDetails(Domain.Entities.Antivirus antivirus )
    {
        return new AntivirusDetailsDto(antivirus.Name,
            antivirus.Version,
            antivirus.Active,
        (await antivirus.Vendor.ToEntityAsync())!.Name,
        antivirus.Opis,
            antivirus.Cijean,
            antivirus.DatumIzdavanja,
            antivirus.LinkZaPreuzimanje,
            antivirus.MarketingUser.Select(x => x.Email));


    }





    private static AntivirusPagedListDto ToAntivirusList(IEnumerable<ProdajaAntivirusa.Domain.Entities.Antivirus> antivirus)
    {

        var antivirusDto = antivirus.Select(x => GetAntivirusDetails(x).Result).ToList();
        return new AntivirusPagedListDto(antivirusDto,new PaginationDto(0, 0));
    }
}