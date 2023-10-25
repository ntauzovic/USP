namespace ProdajaAntivirusa.Application.Common.Dto.Antivirus;

public record UpdateAntivirusDto(string AntivirusId, string? Name, int? Version,  bool? Active,string? Vendor,
    string? Opis, int? Cijena, string? DatumIzdavanja, string? LinkZaPreuzimanje )

{
    internal UpdateAntivirusDto UpdateAntivirus(string AntivirusId)
    {
        return this with { AntivirusId = AntivirusId };
    }

}