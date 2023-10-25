using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using ProdajaAntivirusa.Application.Common.Interfaces;

namespace ProdajaAntivirusa.Application.Customer.Commands;

public record DeleteCustomerCommand(string id) : IRequest
{
   
}

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    
   
    private readonly IUserService _userService;

    public DeleteCustomerCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        await _userService.DeleteUserAsync(request.id);
    }
}