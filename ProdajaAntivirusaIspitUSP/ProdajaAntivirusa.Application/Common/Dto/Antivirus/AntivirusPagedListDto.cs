namespace ProdajaAntivirusa.Application.Common.Dto.Antivirus;

public record AntivirusPagedListDto(List<AntivirusDetailsDto> Antivirus, PaginationDto PaginationDto)
{

    internal AntivirusPagedListDto AddPagination(PaginationDto paginationDto)
    {
        return this with { PaginationDto = paginationDto };
    }
};
