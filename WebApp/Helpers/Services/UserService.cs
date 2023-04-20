using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Helpers.Repositories.IdentityRepos;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class UserService
{
	private readonly UserManager<IdentityUser> _userManager;
	private readonly ProfileIdentityRepository _profileRepository;
	public UserService(UserManager<IdentityUser> userManager, ProfileIdentityRepository profileRepository)
	{
		_userManager = userManager;
		_profileRepository = profileRepository;
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
				FirstName = UserProfile.FirstName,
				LastName = UserProfile.LastName,
				PhoneNumber = UserProfile.PhoneNumber,
				ProfileImage = UserProfile.ProfileImage,
				CompanyName = UserProfile.CompanyName,
				RoleName = role
			};

			userWithRoles.Add(userWithRole);
		}
		return userWithRoles;
	}
}
