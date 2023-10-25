namespace ProdajaAntivirusa.Application.Common.Dto.Vendor.Vendor;

public record VendorPagedListDto(List<VendorDetailsDto> Vendor, PaginationDto PaginationDto)
{

    internal VendorPagedListDto AddPagination(PaginationDto paginationDto)
    {
        return this with { PaginationDto = paginationDto };
    }
};
