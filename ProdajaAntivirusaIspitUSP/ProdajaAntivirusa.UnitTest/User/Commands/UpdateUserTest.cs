using AutoMapper;
using Moq;
using ProdajaAntivirusa.Application.Administrator.Commands;
using ProdajaAntivirusa.Application.Common.Dto.User;
using ProdajaAntivirusa.Application.Common.Interfaces;
using ProdajaAntivirusa.BaseTest.Builders.Command;
using Xunit;

namespace ProdajaAntivirusa.UnitTest.User.Commands;

public class UpdateUserTest
{
    
    [Fact]
    public Task UpdateUsersCommand_UpdateUserDto_ReturnUpdateUserDto()
    {
   const string exceptedId = "6534da46bb700489c662221d";
   const string exceptedUserName = "jovan12";
   const string exceptedFirstName = "Jovan";
   const string exceptedLastName = "Jovic";
   const string expectedEmail = "jovic@mic.rs";
   const double exceptedNovac = 20.20;

        var builder = new UpdateUserBuilder();

        // Act
        var updateUsersCommand = builder.Build();

        // Assert
        Assert.NotNull(updateUsersCommand);
        Assert.Equal(exceptedId, updateUsersCommand.user._id);
        Assert.Equal(exceptedUserName, updateUsersCommand.user.UserName);
        Assert.Equal(exceptedFirstName, updateUsersCommand.user.FirstName);

        Assert.Equal(exceptedLastName, updateUsersCommand.user.LastName);
        Assert.Equal(expectedEmail, updateUsersCommand.user.Email);
        Assert.Equal(exceptedNovac, updateUsersCommand.user.Novac);

        return Task.CompletedTask;
    }

}