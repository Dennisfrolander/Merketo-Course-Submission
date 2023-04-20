namespace WebApp.Models.Interfaces;

public interface IContactUser
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string? PhoneNumber { get; set; }
}
