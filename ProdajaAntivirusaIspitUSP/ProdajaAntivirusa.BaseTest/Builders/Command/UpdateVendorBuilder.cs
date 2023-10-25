using ProdajaAntivirusa.Application.Common.Dto.Vendor.Vendor;
using ProdajaAntivirusa.Application.Vendor.Commands;

namespace ProdajaAntivirusa.BaseTest.Builders.Command;

public class UpdateVendorBuilder
{
    private static string vendorId = "6534da46bb700489c662221d";
    private static string Name = "Microsoft";
    private static string Email = "Microsoft@mic.rs";
    private static int Founding_Year = 1990;
    private static bool Active = true;
    
    private UpdateVendorDto _UpdateVendorDto = new UpdateVendorDto(vendorId,Name,Email,Founding_Year,Active);

    public UpdateVendorCommand Build() => new(_UpdateVendorDto);
}