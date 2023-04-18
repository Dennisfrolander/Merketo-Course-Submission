using Microsoft.AspNetCore.Identity;
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
    public AuthService(IdentityContext context, ProfileIdentityRepository userIdentityRepository, AdressIdentityRepository adressIdentityRepository, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userIdentityRepository = userIdentityRepository;
        _adressIdentityRepository = adressIdentityRepository;
        _userManager = userManager;
    }

    public async Task<bool> SignUpAsync(RegisterAccountViewModel model)
    {
        IdentityUser identityUser = model;
        await _userManager.CreateAsync(identityUser);

        UserProfileEntity userProfileEntity = model;
        userProfileEntity.UserId = identityUser.Id;
        await _userIdentityRepository.CreateAsync(userProfileEntity);

        var adressEntitySearched = await _adressIdentityRepository.GetAsync(x => x.StreetName == model.StreetName && x.PostalCode == model.PostalCode && x.City == model.City);
        if(adressEntitySearched != null)
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
}
