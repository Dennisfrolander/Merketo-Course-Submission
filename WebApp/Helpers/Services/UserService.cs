using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;
using WebApp.Helpers.Repositories.IdentityRepos;
using WebApp.Models.ViewModels;
namespace WebApp.Helpers.Services;

public class UserService
{
	private readonly UserManager<IdentityUser> _userManager;
	private readonly ProfileIdentityRepository _profileRepository;
	private readonly ProfileAdressRepository _profileAdressRepository;
	private readonly AdressIdentityRepository _adressRepository;
	public UserService(UserManager<IdentityUser> userManager, ProfileIdentityRepository profileRepository, ProfileAdressRepository profileAdressRepository, AdressIdentityRepository adressRepository)
	{
		_userManager = userManager;
		_profileRepository = profileRepository;

		_profileAdressRepository = profileAdressRepository;
		_adressRepository = adressRepository;
	}

	public async Task<IEnumerable<UserWithRolesViewModel>> GetAllUserWithRoles()
	{
		var userWithRoles = new List<UserWithRolesViewModel>();

		var allUsers = await _userManager.Users.ToListAsync();

		foreach (var user in allUsers)
		{
			List<string> role = (List<string>)await _userManager.GetRolesAsync(user);


			var UserProfile = await _profileRepository.GetAsync(x => x.UserId == user.Id);

			var userWithRole = new UserWithRolesViewModel
			{
				Id = user.Id,
				FirstName = UserProfile.FirstName,
				LastName = UserProfile.LastName,
				Email = user.Email!,
				PhoneNumber = UserProfile.PhoneNumber,
				ProfileImage = UserProfile.ProfileImage,
				CompanyName = UserProfile.CompanyName,
				RoleName = role[0]
			};

			userWithRoles.Add(userWithRole);
		}
		return userWithRoles;
	}

	public async Task<UserWithRolesViewModel> GetUserWithRolesAsync(string id)
	{
		var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
		if (user != null)
		{
			List<string> role = (List<string>)await _userManager.GetRolesAsync(user);

			var UserProfile = await _profileRepository.GetAsync(x => x.UserId == user.Id);

			var userWithRoles = new UserWithRolesViewModel
			{
				Id = user.Id,
				FirstName = UserProfile.FirstName,
				LastName = UserProfile.LastName,
				Email = user.Email!,
				PhoneNumber = UserProfile.PhoneNumber,
				ProfileImage = UserProfile.ProfileImage,
				CompanyName = UserProfile.CompanyName,
				RoleName = role[0]
			};
			return userWithRoles;
		}
		else
			return null!;
	}

	public async Task<bool> UserAlreadyExistsAsync(Expression<Func<IdentityUser, bool>> expression)
	{
		return await _userManager.Users.AnyAsync(expression);
	}

	public async Task<UserProfileViewModel> CurrentUser(ClaimsPrincipal user)
	{
		try
		{
			UserProfileViewModel userProfileViewModel = new();
			var identityUser = await _userManager.FindByEmailAsync(user.Identity!.Name!);

			if (identityUser != null)
			{
				var userprofile = await _profileRepository.GetAsync(x => x.UserId == identityUser.Id);

				var adressesWithAdressIdAndUserId = await _profileAdressRepository.GetAllAsync(x => x.UserId == userprofile.UserId);

				userProfileViewModel = new UserProfileViewModel
				{
					FirstName = userprofile.FirstName,
					LastName = userprofile.LastName,
					Email = identityUser.UserName!,
					PhoneNumber = userprofile.PhoneNumber,
					ProfileImage = userprofile.ProfileImage,
					CompanyName = userprofile.CompanyName,
				};

				if (adressesWithAdressIdAndUserId != null)
				{
					foreach (var Ids in adressesWithAdressIdAndUserId)
					{
						var adress = await _adressRepository.GetAsync(x => x.Id == Ids.AdressId);


						userProfileViewModel.Adresses.Add(new AdressViewModel
						{
							StreetName = adress.StreetName,
							City = adress.City,
							PostalCode = adress.PostalCode,
						});
					}
				}

			}
				return userProfileViewModel!;

		}
		catch { return null!; }
	}
}
