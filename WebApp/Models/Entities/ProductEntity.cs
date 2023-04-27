using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Entities;

public class ProductEntity
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public string ImageUrl { get; set; } = null!;
	public string Description { get; set; } = null!;

	[Column(TypeName = "money")]
	public decimal Price { get; set; } 
	public int? Discount { get; set; }
	public bool IsNew { get; set; }
	public bool IsFeatured { get; set; }
	public bool IsPopular { get; set; }
	public int CategoryId { get; set; }
	public CategoryEntity Category { get; set; } = null!;

}
