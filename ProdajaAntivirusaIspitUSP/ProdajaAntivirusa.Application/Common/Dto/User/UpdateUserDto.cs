namespace ProdajaAntivirusa.Application.Common.Dto.User;

public record UpdateUserDto(string _id, string? UserName,string? FirstName,string? LastName, string? Email,double Novac )

{
    internal UpdateUserDto AddLoggedInUser(string _id)
    {
        return this with { _id = _id };
    }
}