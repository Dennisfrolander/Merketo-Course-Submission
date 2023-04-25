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

    private readonly ProfileIdentityRepository _userIdentityRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly SeedService _seedService;
    private readonly AdressService _adressService;
    public AuthService(ProfileIdentityRepository userIdentityRepository, AdressIdentityRepository adressIdentityRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, SeedService seedService, ProfileAdressIdentityRepository profileAdressIdentityRepository, AdressService adressService)
    {
        _userIdentityRepository = userIdentityRepository;
        _userManager = userManager;
        _signInManager = signInManager;
        _seedService = seedService;
        _adressService = adressService;
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
            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(identityUser, roleName);

                UserProfileEntity userProfileEntity = model;
                userProfileEntity.UserId = identityUser.Id;
                await _userIdentityRepository.CreateAsync(userProfileEntity);

                var adressEntity = await _adressService.GetOrCreateAsync(model);
                await _adressService.CreateAdressAsync(userProfileEntity, adressEntity);
            }



            //var adressEntitySearched = await _adressIdentityRepository.GetAsync(x => x.StreetName == model.StreetName && x.PostalCode == model.PostalCode && x.City == model.City);
            //if (adressEntitySearched != null)
            //{
            //    _context.ProfileAdresses.Add(new UserProfileAdressEntity
            //    {
            //        UserId = identityUser.Id,
            //        AdressId = adressEntitySearched.Id,
            //    });

            //    await _context.SaveChangesAsync();
            //}
            //else
            //{
            //    AdressEntity adressEntity = model;
            //    await _adressIdentityRepository.CreateAsync(adressEntity);

            //    _context.ProfileAdresses.Add(new UserProfileAdressEntity
            //    {
            //        UserId = identityUser.Id,
            //        AdressId = adressEntity.Id,
            //    });
            //    await _context.SaveChangesAsync();
            //}
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
