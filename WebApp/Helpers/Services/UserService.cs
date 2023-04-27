using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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
}
