using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;
using WebApp.Helpers.Repositories.IdentityRepos;
using WebApp.Models.Contexts;
using WebApp.Models.Entities;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class AuthService
{
    private readonly IdentityContext _context;
    private readonly ProfileIdentityRepository _userIdentityRepository;
    private readonly AdressIdentityRepository _adressIdentityRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly SeedService _seedService;
    public AuthService(IdentityContext context, ProfileIdentityRepository userIdentityRepository, AdressIdentityRepository adressIdentityRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, SeedService seedService)
    {
        _context = context;
        _userIdentityRepository = userIdentityRepository;
        _adressIdentityRepository = adressIdentityRepository;
        _userManager = userManager;
        _signInManager = signInManager;
        _seedService = seedService;
    }

    public async Task<bool> SignUpAsync(RegisterAccountViewModel model)
    {
        try
        {
            await _seedService.SeedRoles();

            var roleName = "user";

            if(!await _userManager.Users.AnyAsync())
            {
                roleName = "admin";
            }

            IdentityUser identityUser = model;
            await _userManager.CreateAsync(identityUser, model.Password);

            await _userManager.AddToRoleAsync(identityUser, roleName);

            UserProfileEntity userProfileEntity = model;
            userProfileEntity.UserId = identityUser.Id;
            await _userIdentityRepository.CreateAsync(userProfileEntity);

            var adressEntitySearched = await _adressIdentityRepository.GetAsync(x => x.StreetName == model.StreetName && x.PostalCode == model.PostalCode && x.City == model.City);
            if (adressEntitySearched != null)
            {
                _context.ProfileAdresses.Add(new UserProfileAdressEntity
                {
                    UserId = identityUser.Id,
                    AdressId = adressEntitySearched.Id,
                });

                await _context.SaveChangesAsync();
            }
            else
            {
                AdressEntity adressEntity = model;
                await _adressIdentityRepository.CreateAsync(adressEntity);

                _context.ProfileAdresses.Add(new UserProfileAdressEntity
                {
                    UserId = identityUser.Id,
                    AdressId = adressEntity.Id,
                });
                await _context.SaveChangesAsync();
            }
            return true;
        }
        catch
        {
            return false;
        }

    }
    
    public async Task<bool> UserAlreadyExistsAsync(Expression<Func<IdentityUser, bool>> expression)
    {
        return await _userManager.Users.AnyAsync(expression);
    }

    public async Task<bool> SignInAsync(LoginAccountViewModel model)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            return result.Succeeded;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> SignOutAsync(ClaimsPrincipal user)
    {
        await _signInManager.SignOutAsync();

        if (_signInManager.IsSignedIn(user))
        {
            return true;
        }
        else { return false; }
    }
}
