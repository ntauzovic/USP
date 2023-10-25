using AutoMapper;
using MediatR;
using MongoDB.Entities;
using ProdajaAntivirusa.Application.Common.Dto.Vendor.Vendor;

namespace ProdajaAntivirusa.Application.Vendor.Queries;

public record GetVendorListQueryNP() : IRequest<VendorListDtoDetails>;

public class GetVendorListQueryNPHandler : IRequestHandler<GetVendorListQueryNP, VendorListDtoDetails>
{
    private readonly IMapper _mapper;

    public GetVendorListQueryNPHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<VendorListDtoDetails> Handle(GetVendorListQueryNP request, CancellationToken cancellationToken)
    {
        return _mapper.Map<VendorListDtoDetails>(await DB.Find<Domain.Entities.Vendor>()
            .ExecuteAsync(cancellationToken));
    }




    
}