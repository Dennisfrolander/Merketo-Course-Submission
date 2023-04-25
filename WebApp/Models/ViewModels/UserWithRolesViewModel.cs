using WebApp.Models.Interfaces;

namespace WebApp.Models.ViewModels;

public class UserWithRolesViewModel : IUserProfile
{
	public string Id { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string? PhoneNumber { get; set; }
	public string? ProfileImage { get; set; }
	public string? CompanyName { get; set; }
	public string RoleName { get; set; } = null!;

	public static implicit operator AdminChangeRoleOfUserViewModel(UserWithRolesViewModel model)
	{
		return new AdminChangeRoleOfUserViewModel
		{
			Id = model.Id,
			FirstName = model.FirstName,
			LastName = model.LastName,
			Email = model.Email,
			PhoneNumber = model.PhoneNumber,
			ProfileImage = model.ProfileImage,
			CompanyName = model.CompanyName,
			RoleName = model.RoleName,
		};
	}

}
