using Moq;
using ProdajaAntivirusa.Application.Common.Interfaces;
using ProdajaAntivirusa.Application.User.Commands;
using Xunit;

namespace ProdajaAntivirusa.UnitTest.User.Commands;

public class CreateUserTest
{
    [Fact]
    public async Task CreateUserCommand_Should_CreateUser()
    {
        // Arrange
        var userServiceMock = new Mock<IUserService>();
        var createUserHandler = new CreateUserHandler(userServiceMock.Object);

        var createUserRequest = new CreateUser("JohnDoe", "Doe", "john@example.com", 100.0);

        // Act
        await createUserHandler.Handle(createUserRequest, CancellationToken.None);

        // Assert
        userServiceMock.Verify(
            (mock) => mock.CreateUserAsync(
                createUserRequest.UserName,
                createUserRequest.lastName,
                createUserRequest.emailAddress,
                createUserRequest.novac,
                It.Is<List<string>>(roles => roles.Contains(ProdajaAntivirusa.Application.Common.Constants.ProdajaAntivirusaAuthorization.User))),
            Times.Once);
    }
}