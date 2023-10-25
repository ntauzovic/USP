using MongoDB.Entities;
using ProdajaAntivirusa.Application.Antivirus.Queries;
using ProdajaAntivirusa.Application.Vendor.Queries;

namespace ProdajaAntivirusa.Application.Extensions.Antivirus;

public static class VendorExtensions
{
    public static PagedSearch<Domain.Entities.Antivirus, Domain.Entities.Antivirus> ApplyFiltersAntivirus(
        this PagedSearch<Domain.Entities.Antivirus,
            Domain.Entities.Antivirus> query, GetAntivirusListQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.search))
        {
            query = (PagedSearch<ProdajaAntivirusa.Domain.Entities.Antivirus>)query.Match(x => x.Name
                    .ToUpper()
                    .Contains(filters.search.ToUpper()));
        }

        return query;
    
    }
}