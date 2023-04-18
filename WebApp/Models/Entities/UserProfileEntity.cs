using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.Interfaces;

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

}
