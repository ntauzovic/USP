using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace ProdajaAntivirusa.Domain.Entities;


[CollectionName("Roles")]
public class ApplicationRole : MongoIdentityRole<Guid>
{
}