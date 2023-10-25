using MongoDB.Entities;

namespace ProdajaAntivirusa.Domain.Entities;

[Collection("vendor")]

public class Vendor : BaseEntity
{
    #region Constructors

    

    public Vendor()
    {
        //Name = name;
        //Active = active;
    }

    #endregion

    #region Properties

    [Field("name")]
    public string Name { get; set; }
    
    [Field("email")]
    public string Email { get; set; }
    [Field("foundingYear")]
    public int Founding_Year  { get; set; }

    #endregion

  
}