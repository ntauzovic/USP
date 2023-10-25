
using AutoMapper;
using MediatR;
using MongoDB.Entities;
using ProdajaAntivirusa.Application.Common.Dto.Vendor.Vendor;
using ProdajaAntivirusa.Application.Common.Exceptions;

namespace ProdajaAntivirusa.Application.Vendor.Commands;

public record UpdateVendorCommand(UpdateVendorDto Vendor) : IRequest
{
    
}

public class UpdateVendorHandler : IRequestHandler<UpdateVendorCommand>
{


    private readonly IMapper _mapper;

    public UpdateVendorHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
    {
        var vendor = await DB.Find<Domain.Entities.Vendor>().OneAsync(request.Vendor.vendroId);

        if (vendor == null)
        {
            throw new NotFoundException("Not found user");
        }

        _mapper.Map(request.Vendor, vendor);
        await vendor.SaveAsync(cancellation: cancellationToken);
    }
    
}