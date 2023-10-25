﻿using MediatR;
using ProdajaAntivirusa.Application.Common.Dto.Auth;
using ProdajaAntivirusa.Application.Common.Interfaces;

namespace ProdajaAntivirusa.Application.Auth.Commands.CompleteLoginCommand;

public record CompleteLoginCommand(string ValidationToken) : IRequest<CompleteLoginResponseDto>;

public class CompleteLoginHandler : IRequestHandler<CompleteLoginCommand, CompleteLoginResponseDto>
{
    private readonly IAuthService _authService;

    public CompleteLoginHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<CompleteLoginResponseDto> Handle(CompleteLoginCommand request, CancellationToken cancellationToken) => await _authService.CompleteLoginAsync(request.ValidationToken);
}
