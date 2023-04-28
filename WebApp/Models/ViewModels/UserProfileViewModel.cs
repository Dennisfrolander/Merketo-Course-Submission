namespace WebApp.Models.ViewModels;

public class UserProfileViewModel
{
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string? PhoneNumber { get; set; }
	public string? ProfileImage { get; set; }
	public string? CompanyName { get; set; }
	public List<AdressViewModel> Adresses { get; set; } = new List<AdressViewModel>();
}
