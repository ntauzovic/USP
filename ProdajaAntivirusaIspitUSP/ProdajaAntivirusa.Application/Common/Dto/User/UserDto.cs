namespace ProdajaAntivirusa.Application.Common.Dto.User;

public record UserDto(string? FirstName,string? LastName, string? Email, double? Novac, List<string>Pozicija);
