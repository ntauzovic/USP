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

public class UpdateVendorTest : Base
{
    [Fact]
    public Task UpdateVendorCommand_UpdateVendorDto_ReturnUpdateVendorDto()
    
    {
        const string exceptionId = "6534da46bb700489c662221d";
        
        const string expectedEmail = "Microsoft@mic.rs";
        const string expectedName = "Microsoft";
        const bool expectedActive = true;
        const int expectedFounding_Year = 1990;
        
  
        var builder = new UpdateVendorBuilder();

        // Act
        var updateVendorCommand = builder.Build();

        // Assert
        Assert.NotNull(updateVendorCommand);
        Assert.Equal(exceptionId, updateVendorCommand.Vendor.vendroId);
        Assert.Equal(expectedName, updateVendorCommand.Vendor.Name);
        Assert.Equal(expectedActive, updateVendorCommand.Vendor.Active);
        Assert.Equal(expectedEmail, updateVendorCommand.Vendor.Email);
        Assert.Equal(expectedFounding_Year, updateVendorCommand.Vendor.Founding_Year);

        return Task.CompletedTask;
    }

    
}