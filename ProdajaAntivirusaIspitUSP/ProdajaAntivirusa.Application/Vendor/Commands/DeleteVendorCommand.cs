using AutoMapper;
using MediatR;
using MongoDB.Entities;

namespace ProdajaAntivirusa.Application.Vendor.Commands;

public record DeleteVendorCommand(string id) : IRequest
{
    
}

public class DeleteVandorHandler : IRequestHandler<DeleteVendorCommand>
{


    private readonly IMapper _mapper;

    public DeleteVandorHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.Vendor>(x => x.ID != null && x.ID.Equals(request.id),cancellation:cancellationToken);
    }
}