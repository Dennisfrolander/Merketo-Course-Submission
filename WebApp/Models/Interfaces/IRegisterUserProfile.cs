namespace WebApp.Models.Interfaces;

public interface IRegisterUserProfile : IUser, IAdress, ICompany
{
	public string Email { get; set; }
	public string Password { get; set; }
	public string ConfirmPassword { get; set; }
}
