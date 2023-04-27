using System.ComponentModel.DataAnnotations;
using WebApp.Models.Interfaces;

namespace WebApp.Models.ViewModels;

public class AdminChangeRoleOfUserViewModel
{
	public string? Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }
	public string? PhoneNumber { get; set; }
	public string? ProfileImage { get; set; }
	public string? CompanyName { get; set; }

	[Display(Name = "Change role")]
	[Required(ErrorMessage = "You need to provide a role")]
	public string RoleName { get; set; } = null!;
}
