using System.Runtime.CompilerServices;
using WebApp.Models.Interfaces;
using WebApp.Models.ViewModels;

namespace WebApp.Models.Entities;

public class AdressEntity : IAdress
{
	public int Id { get; set; }
	public string StreetName { get; set; } = null!;
	public string PostalCode { get; set; } = null!;
	public string City { get; set; } = null!;
	public ICollection<UserProfileAdressEntity> Profiles { get; set; } = new HashSet<UserProfileAdressEntity>();

	public static implicit operator AdressViewModel(AdressEntity entity)
	{
		return new AdressViewModel
		{
			StreetName = entity.StreetName,
			PostalCode = entity.PostalCode,
			City = entity.City,
		};
	}
}
