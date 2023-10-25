using AutoMapper;
using MediatR;
using MongoDB.Entities;
using ProdajaAntivirusa.Application.Common;
using ProdajaAntivirusa.Application.Common.Dto.Antivirus;
using ProdajaAntivirusa.Application.Extensions.Antivirus;

namespace ProdajaAntivirusa.Application.Antivirus.Queries;

public record GetAntivirusListQuery(int pageSize,int pageNumber, string? search) : IRequest<AntivirusPagedListDto>;

public class GetAntivirusListQueryHandler : IRequestHandler<GetAntivirusListQuery, AntivirusPagedListDto>
{
    private readonly IMapper _mapper;

    public GetAntivirusListQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<AntivirusPagedListDto> Handle(GetAntivirusListQuery request, CancellationToken cancellationToken)
    {
        var res = await DB.PagedSearch<ProdajaAntivirusa.Domain.Entities.Antivirus>()
            .Sort(b => b.Name,
                Order.Ascending)
            .ApplyFiltersAntivirus(request)
            .Match(x=>x.Name.Contains(request.search!= null ? request.search: ""))
            .PageSize(request.pageSize)
            .PageNumber(request.pageNumber)
            .ExecuteAsync(cancellationToken);
        
        return _mapper.Map<AntivirusPagedListDto>(res.Results).AddPagination(new PaginationDto(res.TotalCount, res.PageCount));

    }


        

  
        
    }


