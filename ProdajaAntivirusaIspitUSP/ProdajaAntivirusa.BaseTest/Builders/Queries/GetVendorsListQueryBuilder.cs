using ProdajaAntivirusa.Application.Vendor.Queries;

namespace ProdajaAntivirusa.BaseTest.Builders.Queries;

public class GetVendorsListQueryBuilder
{
    private int _pageSize = 7;
    private int _pageNumber = 1;
    private string _searchQuery = "";

    public GetVendorListQuery Build() => new(_pageSize,
        _pageNumber,
        _searchQuery);

    public GetVendorsListQueryBuilder WithPageSize(int pageSize)
    {
        _pageSize = pageSize;
        return this;
    }

    public GetVendorsListQueryBuilder WithPageNumber(int pageNumber)
    {
        _pageNumber = pageNumber;
        return this;
    }

    public GetVendorsListQueryBuilder WithStringQuery(string searchQuery)
    {
        _searchQuery = searchQuery;
        return this;
    }
}