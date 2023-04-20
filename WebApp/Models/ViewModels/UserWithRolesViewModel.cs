using WebApp.Models.Interfaces;

namespace WebApp.Models.ViewModels;

public class UserWithRolesViewModel : IUserProfile
{
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string? PhoneNumber { get; set; }
	public string? ProfileImage { get; set; }
	public string? CompanyName { get; set; }
	public List<string> RoleName { get; set; } = null!;

}
