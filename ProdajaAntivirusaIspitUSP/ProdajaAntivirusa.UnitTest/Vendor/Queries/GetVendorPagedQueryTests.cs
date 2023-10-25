using FluentAssertions;
using FluentAssertions.Execution;
using MongoDB.Entities;
using ProdajaAntivirusa.Application.Vendor.Queries;
using ProdajaAntivirusa.BaseTest;
using ProdajaAntivirusa.BaseTest.Builders.Queries;
using ProdajaAntivirusa.BaseTest.Data;
using Xunit;

namespace ProdajaAntivirusa.UnitTest.Vendor.Queries;

public class GetVendorPagedQueryTests : Base
{
    [Fact]
    public async Task GetVendorPagedListQuery_Filters_ReturnvendorPagedList()
    {
        //Given (Arrange) - what is part of request
        var user = new VendorBuilder().Build();
        await user.SaveAsync();
    
        //When (Act) - what we do with that data
        var handler = new GetVendorListQueryHandler(Mapper);
        var query = new GetVendorsListQueryBuilder().Build();
        var response = await handler.Handle(query,
            new CancellationToken());
        
        //Then (Assert) - what is response
        using var _ = new AssertionScope();
    
        response.Should().NotBeNull();
        response.Vendor.Should().NotBeNull();
        response.Vendor.Should().HaveCount(1);
        
        await DB.Database("ProdajaAntivirusaTest").Client.DropDatabaseAsync("ProdajaAntivirusaTest");
    }
}
