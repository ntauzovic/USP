namespace ProdajaAntivirusa.Application.Common.Dto.Vendor.Vendor;

public record UpdateVendorDto(string vendroId, string? Name, string? Email,int? Founding_Year, bool? Active )

{
    internal UpdateVendorDto AddLoggedInVendor(string vendroId)
    {
        return this with { vendroId = vendroId };
    }
}

