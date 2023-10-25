using AutoMapper;
using ProdajaAntivirusa.Application.Common;
using ProdajaAntivirusa.Application.Common.Dto.Vendor.Vendor;

namespace ProdajaAntivirusa.Application.Mappers.Vendor;

public class MappingProfile : Profile
{
    
    public MappingProfile()
    {
        CreateMap<UpdateVendorDto, ProdajaAntivirusa.Domain.Entities.Vendor>().ReverseMap();


        CreateMap<VendorDetailsDto, ProdajaAntivirusa.Domain.Entities.Vendor>().ReverseMap();
        CreateMap< ProdajaAntivirusa.Domain.Entities.Vendor, Task<VendorDetailsDto>>()
            .ConstructUsing(x => GetVendorDetails(x));

        CreateMap<IEnumerable< ProdajaAntivirusa.Domain.Entities.Vendor>, VendorPagedListDto>()
            .ConstructUsing(x => VendorList(x));
        
        CreateMap<IEnumerable< ProdajaAntivirusa.Domain.Entities.Vendor>, VendorListDtoDetails>()
            .ConstructUsing(x => VendorListNPt(x));
    }
    
    private static async Task<VendorDetailsDto> GetVendorDetails( ProdajaAntivirusa.Domain.Entities.Vendor vendor)
    {
        return new VendorDetailsDto(vendor.Name,vendor.Email,vendor.Founding_Year,vendor.Active);

    }

    private static VendorPagedListDto VendorList(IEnumerable<ProdajaAntivirusa.Domain.Entities.Vendor> vendors)
    {
        var vendorDtos = vendors.Select(x => GetVendorDetails(x).Result).ToList();
        return new VendorPagedListDto(vendorDtos,new PaginationDto(0, 0));
    }
    
    private static VendorListDtoDetails VendorListNPt(IEnumerable<ProdajaAntivirusa.Domain.Entities.Vendor> vendors)
    {
        var vendor = vendors.Select(x => GetVendorDetails(x).Result).ToList();
        return new VendorListDtoDetails(vendor);
    }
    


}