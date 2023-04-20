using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.Interfaces;

namespace WebApp.Models.Entities;

public class ContactInformationEntity : IContactInformation
{
	[Key]
	public int Id { get; set; }

	[Column(TypeName = "nvarchar(500)")]
	public string Description { get; set; } = null!;
	public DateTime Created { get; set; } = DateTime.Now;
	public int UserId { get; set; }
	public ContactUserEntity User { get; set; } = null!;
}
