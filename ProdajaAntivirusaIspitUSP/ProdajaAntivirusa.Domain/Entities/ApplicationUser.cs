using MongoDbGenericRepository.Attributes;
using AspNetCore.Identity.MongoDbCore.Models;

namespace ProdajaAntivirusa.Domain.Entities;

[CollectionName("User")]
public class ApplicationUser : MongoIdentityUser<Guid>
{


    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public double Novac { get; set; }


    public List<string> Pozicija { get; set; }

    public ApplicationUser()
    {
        
    }

   
    
}