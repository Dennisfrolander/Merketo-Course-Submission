using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using WebApp.Models.Interfaces;
using WebApp.Models.ViewModels;

namespace WebApp.Models.Entities;

public class UserProfileEntity : IUserProfile
{
	[Key, ForeignKey(nameof(User))]
	public string UserId { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string? PhoneNumber { get; set; }
	public string? ProfileImage { get; set; }
	public string? CompanyName { get; set; }
	public IdentityUser User { get; set; } = null!; 
	public ICollection<UserProfileAdressEntity> Adresses { get; set; } = new HashSet<UserProfileAdressEntity>();

	public static implicit operator UserProfileViewModel(UserProfileEntity entity)
	{
		return new UserProfileViewModel
		{
			FirstName = entity.FirstName,
			LastName = entity.LastName,
			PhoneNumber = entity.PhoneNumber,
			ProfileImage = entity.ProfileImage,
			CompanyName = entity.CompanyName,
		};
	}
}
