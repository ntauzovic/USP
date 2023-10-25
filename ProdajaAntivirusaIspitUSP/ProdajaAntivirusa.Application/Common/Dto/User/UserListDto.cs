using ProdajaAntivirusa.Application.Common.Dto.Vendor.Vendor;

namespace ProdajaAntivirusa.Application.Common.Dto.User;

public record UserListDto(IReadOnlyList<UserDto> users);
