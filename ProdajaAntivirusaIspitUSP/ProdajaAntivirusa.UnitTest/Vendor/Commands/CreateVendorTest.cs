using FluentAssertions;
using FluentAssertions.Execution;
using MongoDB.Entities;
using ProdajaAntivirusa.Application.Vendor.Queries;
using ProdajaAntivirusa.BaseTest;
using ProdajaAntivirusa.BaseTest.Builders.Command;
using ProdajaAntivirusa.BaseTest.Builders.Queries;
using ProdajaAntivirusa.BaseTest.Data;
using Xunit;

namespace ProdajaAntivirusa.UnitTest.Vendor.Commands;

public class CreateVendorTest : Base
{
    [Fact]
    public Task CreateVendorCommand_CreateVendorDto_ReturnVendorDto()
    {
        
        const string expectedEmail = "Microsoft@mic.rs";
        const string expectedName = "Microsoft";
        const bool expectedActive = true;
        const int expectedFounding_Year = 1990;
        
  
        var builder = new CreateVendorBuilder();

        // Act
        var createVendorCommand = builder.Build();

        // Assert
        Assert.NotNull(createVendorCommand);
        Assert.Equal(expectedName, createVendorCommand.vendor.Name);
        Assert.Equal(expectedActive, createVendorCommand.vendor.Active);
        Assert.Equal(expectedEmail, createVendorCommand.vendor.Email);
        Assert.Equal(expectedFounding_Year, createVendorCommand.vendor.Founding_Year);

        return Task.CompletedTask;
    }

    
}