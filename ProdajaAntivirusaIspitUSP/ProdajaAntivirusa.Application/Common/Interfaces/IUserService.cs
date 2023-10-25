using ProdajaAntivirusa.Domain.Entities;

namespace ProdajaAntivirusa.Application.Common.Interfaces;

public interface IUserService
{
    Task CreateUserAsync(string firstName,string lastName,string emailAddress,double novac, List<string> roles);
    Task<ApplicationUser?> GetUserAsync(string id);
    Task<ApplicationUser?> GetUserByEmailAsync(string id);
    Task<bool> IsInRoleAsync(ApplicationUser user, string roleName);
    Task DeleteUserAsync(string id);
    
    Task<List<ApplicationUser>> GetAllUsers();
    
    Task UpdateUser(ApplicationUser user);
    
    public async Task<List<ApplicationUser>> GetUsersWithPagination(int skip, int pageSize)
    {
        var allUsers = await GetAllUsers();
        var usersOnPage = allUsers.Skip(skip).Take(pageSize).ToList();
        return usersOnPage;
    }
    
    
}
