using DB = MongoDB.Entities.DB;
using IMapper = AutoMapper.IMapper;
using IRequest = MediatR.IRequest;
using AutoMapper;
using MediatR;
using MongoDB.Entities;
using ProdajaAntivirusa.Application.Common.Dto.Antivirus;
using ProdajaAntivirusa.Application.Common.Exceptions;


namespace ProdajaAntivirusa.Application.Antivirus.Commands;

public record UpdateAntivirusCommand(UpdateAntivirusDto antivirus) : IRequest
{
    
}


public class UpdateAntivirusHandler : MediatR.IRequestHandler<UpdateAntivirusCommand>
{
    private readonly IMapper _mapper;

    public UpdateAntivirusHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task Handle(UpdateAntivirusCommand request, CancellationToken cancellationToken)
    {
        var car = await DB.Find<Domain.Entities.Antivirus>().OneAsync(request.antivirus.AntivirusId,cancellationToken);

        if (car == null)
        {
            throw new NotFoundException("Not find cars with this id");
        }

         _mapper.Map(request.antivirus, car);
        await car.SaveAsync(cancellation: cancellationToken);
    }
}