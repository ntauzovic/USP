using MongoDB.Entities;
using ProdajaAntivirusa.Application.Vendor.Queries;
using ProdajaAntivirusa.Domain.Entities;

namespace ProdajaAntivirusa.Application.Extensions.User;

public static class VendorExtensions
{
    public static PagedSearch<Domain.Entities.Vendor, Domain.Entities.Vendor> ApplyFilters(
        this PagedSearch<Domain.Entities.Vendor,
            Domain.Entities.Vendor> query, GetVendorListQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.search))
        {
            query = (PagedSearch<ProdajaAntivirusa.Domain.Entities.Vendor>)query.Match(x => x.Name
                    .ToUpper()
                    .Contains(filters.search.ToUpper()));
        }

        return query;
    
    }
}