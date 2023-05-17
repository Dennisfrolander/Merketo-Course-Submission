using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.ViewModels;

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
	public int CategoryId { get; set; }
	public CategoryEntity Category { get; set; } = null!;

	public ICollection<ProductTagEntity> Tags { get; set; } = new HashSet<ProductTagEntity>();

	public static implicit operator ProductCardViewModel(ProductEntity entity)
	{

		return new ProductCardViewModel
		{
			Name = entity.Name,
			ImageUrl = entity.ImageUrl,
			Price = entity.Price,
			Discount = entity.Discount,
			Category = new CategoryViewModel
			{
				Id = entity.Category.Id,
				Name = entity.Category.CategoryName,
			}
		};
	}

	public static implicit operator ProductDetailsCardViewModel(ProductEntity entity)
	{
		return new ProductDetailsCardViewModel
		{
			Name = entity.Name,
			Description = entity.Description,
			ImageUrl = entity.ImageUrl,
			Price = entity.Price,
			Discount = entity.Discount,
			Category = new CategoryViewModel
			{
				Id = entity.Category.Id,
				Name = entity.Category.CategoryName,
			}
		};
	}
}
