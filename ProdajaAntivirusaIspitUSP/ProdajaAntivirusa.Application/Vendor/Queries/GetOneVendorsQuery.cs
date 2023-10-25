using AutoMapper;
using MediatR;
using MongoDB.Entities;
using ProdajaAntivirusa.Application.Common.Dto.Vendor.Vendor;

namespace ProdajaAntivirusa.Application.Vendor.Queries;

public record GetOneVendorsQuery(string vendorId): IRequest<VendorDetailsDto>;

public class GetAllVendorsQueryHandler : IRequestHandler<GetOneVendorsQuery, VendorDetailsDto>
{
    private readonly IMapper _mapper;

    public GetAllVendorsQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<VendorDetailsDto> Handle(GetOneVendorsQuery request, CancellationToken cancellationToken)
    {
        var vendor = await DB.Find<ProdajaAntivirusa.Domain.Entities.Vendor>()
            .OneAsync(request.vendorId,
                cancellationToken);
        if (vendor == null)
        {
            throw new Exception("Vendor do not exist!");
        }

        return await _mapper.Map<Task<VendorDetailsDto>>(vendor);
    }
}