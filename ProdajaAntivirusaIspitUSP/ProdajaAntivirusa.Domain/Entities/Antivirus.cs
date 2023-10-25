using MongoDB.Entities;

namespace ProdajaAntivirusa.Domain.Entities;


[Collection("antivirus")]

public class Antivirus : BaseEntity
{
    [Field("name")]
    public string Name { get; set; }
    
    
    [Field("version")]
    public int Version { get;  set; }

    
    [Field("vendor")]
    public One<Vendor> Vendor { get;  set; }

    
    [Field("cijena")]
    public int Cijean { get;  set; }


    [Field("opis")]
    public string Opis { get; set; }
    
    [Field("datumn_izdavanje")]
    public string DatumIzdavanja { get;  set; }
    
    [Field("link_za_preuzimanje")]
    public string LinkZaPreuzimanje { get; set; }

   
    public List<ApplicationUser> MarketingUser {  get;  set;}
    //public List<ApplicationUser> OtherUsers {  get;  set;}

    public Antivirus()
    {

    }

    
    
    public Antivirus AddVendor(One<Vendor> vendor)
    {
        Vendor = vendor;

        return this;
    }
}