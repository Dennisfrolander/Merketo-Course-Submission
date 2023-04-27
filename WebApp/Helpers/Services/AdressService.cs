using WebApp.Helpers.Repositories.IdentityRepos;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Services;

public class AdressService
{
    private readonly AdressIdentityRepository _adressIdentityRepository;
    private readonly ProfileAdressIdentityRepository _profileAdressIdentityRepository;
    public AdressService(AdressIdentityRepository adressIdentityRepository, ProfileAdressIdentityRepository profileAdressIdentityRepository)
    {
        _adressIdentityRepository = adressIdentityRepository;
        _profileAdressIdentityRepository = profileAdressIdentityRepository;
    }

    public async Task<AdressEntity> GetOrCreateAsync(AdressEntity model)
    {
        var entity = await _adressIdentityRepository.GetAsync(x => x.StreetName == model.StreetName && x.PostalCode == model.PostalCode && x.City == model.City);

        entity ??= await _adressIdentityRepository.CreateAsync(model);
        
        return entity;
    }

    public async Task CreateAdressAsync(UserProfileEntity userProfileEntity, AdressEntity adressEntity)
    {
        await _profileAdressIdentityRepository.CreateAsync(new UserProfileAdressEntity
        {
            UserId = userProfileEntity.UserId,
            AdressId = adressEntity.Id
        });
    }
}
