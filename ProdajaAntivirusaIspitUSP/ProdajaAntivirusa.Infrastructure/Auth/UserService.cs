using System.Security.Claims;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Entities;
using ProdajaAntivirusa.Application.Common.Interfaces;
using ProdajaAntivirusa.Domain.Entities;
using ProdajaAntivirusa.Infrastructure.Exceptions;

namespace ProdajaAntivirusa.Infrastructure.Auth;

public class UserService : IUserService
{
    private readonly ApplicationUserManager _userManager;
    
    public UserService(ApplicationUserManager userManager)
    {
        _userManager = userManager;
    }

    public async Task CreateUserAsync(string firstName,string lastName,string emailAddress,double novac, List<string> roles)
    {
        var alreadyExist = await _userManager.FindByEmailAsync(emailAddress);
        
        if (alreadyExist != null)
            return;

        var user = new ApplicationUser
        {
            
            Email = emailAddress,
            UserName = firstName,
            LastName = lastName,
            Novac = novac,
            Pozicija = new List<string>()
        };
        


     

        try
        {
            user.Claims.Add(new MongoClaim { Type = ClaimTypes.Email, Value = emailAddress });
            user.Claims.AddRange(roles.Select(userRole => new MongoClaim
            {
                Type = ClaimTypes.Role, Value = userRole
            }));

            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                throw new AuthException("Could not create a new user",
                    new { Errors = result.Errors.ToList() });
            }

            var rolesResult = await _userManager.AddToRolesAsync(user,
                roles.Select(nr => nr.ToUpper()));

            if (!rolesResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);

                throw new AuthException("Could not add roles to user",
                    new { Errors = rolesResult.Errors.ToList() });
            }
            var newRoles = _userManager.GetRolesAsync(user).Result.ToList();
            user.Pozicija.AddRange(newRoles);
            await _userManager.UpdateAsync(user);
        }
        catch (Exception e)
        {
            await _userManager.DeleteAsync(user);

            throw new AuthException("Could not create a new user",
                e);
        }
    }
    public Task<ApplicationUser?> GetUserAsync(string id) => _userManager.FindByIdAsync(id);
    public Task<ApplicationUser?> GetUserByEmailAsync(string id) => _userManager.FindByEmailAsync(id);
    public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName) => _userManager.IsInRoleAsync(user,
        roleName);

    


    public async Task DeleteUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            throw new AuthException("User not found.");
        }

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            throw new AuthException("Could not delete user", new { Errors = result.Errors.ToList() });
        }
    }
    
    public async Task<List<ApplicationUser>> GetAllUsers()
    {
        var allUsers =  _userManager.Users.ToList();
        return allUsers;
    }

    public  Task UpdateUser(ApplicationUser user)
    {
        var updateUser = _userManager.UpdateAsync(user);
        return updateUser;
    }
}


