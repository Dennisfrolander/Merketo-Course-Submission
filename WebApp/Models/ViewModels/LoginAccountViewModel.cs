using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModels;

public class LoginAccountViewModel
{
	[Required(ErrorMessage = "You need to provide an e-mail adress")]
	[DataType(DataType.EmailAddress)]
	[Display(Name = "E-mail*")]
	public string Email { get; set; } = null!;

	[Required(ErrorMessage = "You need to provide a password")]
	[DataType(DataType.Password)]
	[Display(Name = "Password*")]
	public string Password { get; set; } = null!;

	public bool RememberMe { get; set; }
}
