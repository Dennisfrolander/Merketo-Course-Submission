using WebApp.Models.Interfaces;

namespace WebApp.Models.Entities;

public class AdressEntity : IAdress
{
	public int Id { get; set; }
	public string StreetName { get; set; } = null!;
	public string PostalCode { get; set; } = null!;
	public string City { get; set; } = null!;
	public ICollection<UserProfileAdressEntity> Profiles { get; set; } = new HashSet<UserProfileAdressEntity>();
}
