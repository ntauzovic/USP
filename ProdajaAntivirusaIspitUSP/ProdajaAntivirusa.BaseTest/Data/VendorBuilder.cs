using ProdajaAntivirusa.Domain.Entities;

namespace ProdajaAntivirusa.BaseTest.Data;

public class VendorBuilder
{
    public Vendor Build()
    {
        return new Vendor()
        {
            Active = true,
            Email = "test@test.com",
            Name = "Test",
            Founding_Year = 2000
        };
    }
}