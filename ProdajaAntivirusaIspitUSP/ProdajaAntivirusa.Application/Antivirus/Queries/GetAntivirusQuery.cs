using AutoMapper;
using MediatR;
using MongoDB.Entities;
using ProdajaAntivirusa.Application.Common.Dto.Antivirus;

namespace ProdajaAntivirusa.Application.Antivirus.Queries;

public record GetAntivirusQuery(string AntiviruId): IRequest<AntivirusDetailsDto>;


public class GetAntivrusQueryHandler : IRequestHandler<GetAntivirusQuery, AntivirusDetailsDto>
{
    private readonly IMapper _mapper;

    public GetAntivrusQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }


    public async Task<AntivirusDetailsDto> Handle(GetAntivirusQuery request, CancellationToken cancellationToken)
    {
        var antivirus = await DB.Find<ProdajaAntivirusa.Domain.Entities.Antivirus>()
            .OneAsync(request.AntiviruId,
                cancellationToken);

        if (antivirus == null)
        {
            throw new Exception("Antivirus do not exist!");
        }

        return await _mapper.Map<Task<AntivirusDetailsDto>>(antivirus);
    }


}

