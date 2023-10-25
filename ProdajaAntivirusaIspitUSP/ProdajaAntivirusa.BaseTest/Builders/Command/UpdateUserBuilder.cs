using ProdajaAntivirusa.Application.Administrator.Commands;
using ProdajaAntivirusa.Application.Common.Dto.User;

namespace ProdajaAntivirusa.BaseTest.Builders.Command;

public class UpdateUserBuilder
{
    private static string _id = "6534da46bb700489c662221d";
    private static string UserName = "jovan12";
    private static string FirstName = "Jovan";
    private static string LastName = "Jovic";
    private static string Email = "jovic@mic.rs";
    private static double Novac = 20.20;
    
    private UpdateUserDto _UpdateUserDto = new UpdateUserDto(_id,UserName,FirstName,LastName,Email,Novac);

    public UpdateUsersCommand Build() => new(_UpdateUserDto);
}