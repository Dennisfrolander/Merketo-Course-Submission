using WebApp.Helpers.Repositories.DataRepos;
using WebApp.Models.Contexts;
using WebApp.Models.Entities;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class ContactUsService
{
    private readonly DataContext _context;
    private readonly ContactUserRepository _userRepository;
    private readonly ContactInformationRepository _informationRepository;
    public ContactUsService(DataContext context, ContactUserRepository userRepository, ContactInformationRepository informationRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _informationRepository = informationRepository;
    }

    public async Task<bool> CreateAsync(RegisterContactUsViewModel model)
    {
        try
        {
            ContactUserEntity contactUserEntity = model;

            ContactInformationEntity contactInformationEntity = model;
            var SearchedUser = await _userRepository.GetAsync(x => x.Email == model.Email);

            if(SearchedUser != null)
            {
                contactInformationEntity.UserId = SearchedUser.Id;
                await _informationRepository.CreateAsync(contactInformationEntity);
            }
            else
            {
                await _userRepository.CreateAsync(contactUserEntity);
                contactInformationEntity.UserId = contactUserEntity.Id;
                await _informationRepository.CreateAsync(contactInformationEntity);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}
