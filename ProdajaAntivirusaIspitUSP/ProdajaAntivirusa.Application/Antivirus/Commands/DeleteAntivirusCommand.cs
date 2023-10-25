using AutoMapper;
using MediatR;
using MongoDB.Entities;

namespace ProdajaAntivirusa.Application.Antivirus.Commands;

public record DeleteAntivirusCommand(string AntivirusId) : IRequest
{
    
}

public class DeleteAntivirusHandeler : IRequestHandler<DeleteAntivirusCommand>
{
    private readonly IMapper _mapper;

    public DeleteAntivirusHandeler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Handle(DeleteAntivirusCommand request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.Antivirus>(x => x.ID != null && x.ID.Equals(request.AntivirusId),
            cancellation: cancellationToken);
    }
}