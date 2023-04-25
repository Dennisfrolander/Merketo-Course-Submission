using Microsoft.AspNetCore.Identity;
using WebApp.Helpers.Repositories.IdentityRepos;
using WebApp.Models.Entities;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class AdminService
{
	private readonly ProfileIdentityRepository _userIdentityRepository;
	private readonly UserManager<IdentityUser> _userManager;
	private readonly AdressService _adressService;
	public AdminService(ProfileIdentityRepository userIdentityRepository, UserManager<IdentityUser> userManager, AdressService adressService)
	{
		_userIdentityRepository = userIdentityRepository;
		_userManager = userManager;
		_adressService = adressService;
	}
	public async Task<bool> CreateUserAsync(AdminRegisterUserViewModel model)
	{
		try
		{
			IdentityUser identityUser = model;

			var result = await _userManager.CreateAsync(identityUser, model.Password);

			if (result.Succeeded)
			{
				await _userManager.AddToRoleAsync(identityUser, model.RoleName);

				UserProfileEntity userProfileEntity = model;
				userProfileEntity.UserId = identityUser.Id;
				await _userIdentityRepository.CreateAsync(userProfileEntity);

				var adressEntity = await _adressService.GetOrCreateAsync(model);
				await _adressService.CreateAdressAsync(userProfileEntity, adressEntity);
			}

			return true;
		}
		catch { return false; }

	}

	public async Task<bool> UpdateRole(AdminChangeRoleOfUserViewModel model)
	{

		var user = await _userManager.FindByIdAsync(model.Id);
		if (user != null)
		{
			var roles = await _userManager.GetRolesAsync(user);
			await _userManager.RemoveFromRolesAsync(user, roles);
			await _userManager.AddToRoleAsync(user, model.RoleName);
			await _userManager.UpdateAsync(user);
			return true;
		}
		else
			return false;
		


	}
}
