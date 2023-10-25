namespace ProdajaAntivirusa.Application.Common.Dto.User;

public record UserPagedListDto(IReadOnlyList<UserDto> Users, int? PageNumber, int? PageSize);
