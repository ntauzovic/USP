
namespace ProdajaAntivirusa.Application.Common.Dto.Antivirus;

public record AntivirusDetailsDto(string Name, int Version,  bool Active,string Vendor,
    string Opis, int Cijena, string DatumIzdavanja,
    string LinkZaPreuzimanje, IEnumerable<string?>MarketingUser );