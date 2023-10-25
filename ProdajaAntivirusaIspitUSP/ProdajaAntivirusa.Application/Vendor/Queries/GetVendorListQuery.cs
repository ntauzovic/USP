using AutoMapper;
using MediatR;
using MongoDB.Entities;
using ProdajaAntivirusa.Application.Common;
using ProdajaAntivirusa.Application.Common.Dto.User;
using ProdajaAntivirusa.Application.Common.Dto.Vendor.Vendor;
using ProdajaAntivirusa.Application.Extensions.User;

namespace ProdajaAntivirusa.Application.Vendor.Queries;

public record GetVendorListQuery(int pageSize,int pageNumber, string? search) : IRequest<VendorPagedListDto>;

public class GetVendorListQueryHandler : IRequestHandler<GetVendorListQuery, VendorPagedListDto>
{
    private readonly IMapper _mapper;

    public GetVendorListQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }


    
    public async Task<VendorPagedListDto> Handle(GetVendorListQuery request, CancellationToken cancellationToken)
    {
        var res = await DB.PagedSearch<Domain.Entities.Vendor>()
            .Sort(b => b.Name,
                Order.Ascending)
            .ApplyFilters(request)
            .Match(x=>x.Name.Contains(request.search!= null ? request.search: ""))
            .PageSize(request.pageSize)
            .PageNumber(request.pageNumber)
            .ExecuteAsync(cancellationToken);
        
        return _mapper.Map<VendorPagedListDto>(res.Results).AddPagination(new PaginationDto(res.TotalCount, res.PageCount));
    }
    
  
}


