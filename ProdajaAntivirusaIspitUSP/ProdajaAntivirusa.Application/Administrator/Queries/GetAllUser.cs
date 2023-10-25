using AutoMapper;
using MediatR;
using ProdajaAntivirusa.Application.Common.Dto.User;
using ProdajaAntivirusa.Application.Common.Interfaces;
using ProdajaAntivirusa.Domain.Entities;

namespace ProdajaAntivirusa.Application.Administrator.Queries;

public class GetAllUsersQuery : IRequest<UserPagedListDto>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, UserPagedListDto>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<UserPagedListDto> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        // Vaš trenutni kod kako bi mogli pravilno proslediti pageNumber i pageSize u Mapper
        var pageNumber = 1;
        var pageSize = 4; 

        if (request.PageNumber > 0)
        {
            pageNumber = request.PageNumber;
        }
        if (request.PageSize > 0)
        {
            pageSize = request.PageSize;
        }

        var skip = (pageNumber - 1) * pageSize;

        var users = await _userService.GetUsersWithPagination(skip, pageSize);

        // Mapper će sada koristiti pageNumber i pageSize
        return _mapper.Map<UserPagedListDto>(users, opt => opt.Items["pageNumber"] = pageNumber);
    }
}