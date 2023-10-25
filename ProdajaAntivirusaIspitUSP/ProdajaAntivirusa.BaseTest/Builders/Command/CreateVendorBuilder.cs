using ProdajaAntivirusa.Application.Common.Dto.Vendor.Vendor;
using ProdajaAntivirusa.Application.Vendor.Commands;

namespace ProdajaAntivirusa.BaseTest.Builders.Command;

public class CreateVendorBuilder
{
    private static string Name = "Microsoft";
    private static string Email = "Microsoft@mic.rs";
    private static int Founding_Year = 1990;
    private static bool Active = true;
    
    private VendorDetailsDto _vendorDto = new VendorDetailsDto(Name, Email,Founding_Year,Active);

    public CreateVendorCommand Build() => new(_vendorDto);
}