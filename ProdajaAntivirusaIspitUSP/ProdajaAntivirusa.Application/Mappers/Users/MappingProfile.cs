using AutoMapper;
using ProdajaAntivirusa.Application.Common.Dto.User;

namespace ProdajaAntivirusa.Application.Mappers.Users;

public class MappingProfile : Profile
{
    public MappingProfile()
    {


        CreateMap<UpdateUserDto, ProdajaAntivirusa.Domain.Entities.ApplicationUser>().ReverseMap();


        CreateMap<ProdajaAntivirusa.Domain.Entities.ApplicationUser, UserDto>()
            .ConstructUsing(x => GetUserDetails(x));

        CreateMap<List<ProdajaAntivirusa.Domain.Entities.ApplicationUser>, UserListDto>()
            .ConstructUsing(x => ToUsersList(x));

        CreateMap<List<ProdajaAntivirusa.Domain.Entities.ApplicationUser>, UserPagedListDto>()
            .ConvertUsing(users => ToUserPagedList(users, 1, 1));
    }


    private static UserPagedListDto ToUserPagedList(IEnumerable<ProdajaAntivirusa.Domain.Entities.ApplicationUser> users, int? pageNumber, int? pageSize)
    {
        var userDtosList = users.Select(user => GetUserDetails(user)).ToList();
    
        return new UserPagedListDto(userDtosList, pageNumber, pageSize)
        {
            Users = userDtosList
        };
    }
    private static UserDto GetUserDetails(Domain.Entities.ApplicationUser users)
    {
        return new UserDto(
            users.FirstName,
            users.LastName,
            users.Email,
            users.Novac,
            users.Pozicija
        );
    }


    private static UserListDto ToUsersList(IEnumerable<ProdajaAntivirusa.Domain.Entities.ApplicationUser> users)
    {

        var usersDtos = users.Select(GetUserDetails)
            .ToList();

        return new (usersDtos);
    }
    
    
    
}