using AutoMapper;
using MediatR;
using ProdajaAntivirusa.Application.Administrator.Queries;
using ProdajaAntivirusa.Application.Common.Dto.User;
using ProdajaAntivirusa.Application.Common.Exceptions;
using ProdajaAntivirusa.Application.Common.Interfaces;
using ProdajaAntivirusa.Domain.Entities;

namespace ProdajaAntivirusa.Application.Administrator.Commands;

public record UpdateUsersCommand(UpdateUserDto user) : IRequest
{
}

public class UpdateUsersQueryHandler : IRequestHandler<UpdateUsersCommand>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UpdateUsersQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
    {

        var updatedUser = await _userService.GetUserAsync(request.user._id);
        if (updatedUser == null)
        {
            throw new NotFoundException("User not found");
        }

        _mapper.Map(request.user,updatedUser);

        await _userService.UpdateUser(updatedUser);
    }
}