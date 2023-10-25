using AutoMapper;
using MediatR;
using MongoDB.Entities;
using ProdajaAntivirusa.Application.Common.Dto.Vendor.Vendor;

namespace ProdajaAntivirusa.Application.Vendor.Commands;


public record CreateVendorCommand(VendorDetailsDto vendor) : IRequest;

public class CreateVendorHandler : IRequestHandler<CreateVendorCommand>
{
    private readonly IMapper _mapper;
    
    public CreateVendorHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task Handle(CreateVendorCommand request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<ProdajaAntivirusa.Domain.Entities.Vendor>(request.vendor);
        await data.SaveAsync(cancellation: cancellationToken);
    }
}
