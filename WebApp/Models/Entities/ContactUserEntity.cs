using WebApp.Models.Interfaces;

namespace WebApp.Models.Entities;

public class ContactUserEntity : IContactUser
{
	public int Id { get; set; }
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string? PhoneNumber { get; set; }

	public ICollection<ContactInformationEntity> ContactInformation { get; set; } = new HashSet<ContactInformationEntity>();
}
