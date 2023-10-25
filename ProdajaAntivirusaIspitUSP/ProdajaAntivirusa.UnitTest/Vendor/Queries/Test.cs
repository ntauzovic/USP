using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using ProdajaAntivirusa.Application.Common.Dto.Vendor.Vendor;
using ProdajaAntivirusa.BaseTest;
using Xunit;

namespace ProdajaAntivirusa.UnitTest.Vendor.Queries;


    public class GetCarListQueryTests : Base
    {
        private const string BaseUrl = "/car/list";

        [Fact]
        public async Task GetCarListQuery_Filters_ReturnCarList()
        {
            //Given (Arrange) - what is part of request
        
            //When (Act) - what we do with that data
            var response = await AnonymousClient.GetAsync(BaseUrl);
    
            //Then (Assert) - what is response
            using var _ = new AssertionScope();
    
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        
            var result = await response.Content.ReadFromJsonAsync<VendorDetailsDto>();
        }
    }
