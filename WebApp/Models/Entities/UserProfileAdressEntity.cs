using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Entities;

[PrimaryKey(nameof(UserId), nameof(AdressId))]
public class UserProfileAdressEntity
{
	[Key, ForeignKey(nameof(UserProfile))]
	public string UserId { get; set; } = null!;
	public UserProfileEntity UserProfile { get; set; } = null!;


	[Key, ForeignKey(nameof(Adress))]
	public int AdressId { get; set; }
	public AdressEntity Adress { get; set; } = null!;
}
