using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Interfaces;

namespace WebApp.Models.ViewModels;

public class RegisterProductViewModel : IProduct
{
	[Required(ErrorMessage = "You need to provide a product name")]
	[Display(Name = "Product Name*")]
	public string Name { get; set; } = null!;

	[Required(ErrorMessage = "You need to provide a description")]
	[Display(Name = "Description*")]
	public string Description { get; set; } = null!;

	[Required(ErrorMessage = "You need to provide a image url")]
	[Display(Name = "ImageUrl*")]
	public string ImageUrl { get; set; } = null!;

	[Required(ErrorMessage = "You need to provide a price")]
	[Display(Name = "Price*")]
	public decimal Price { get; set; }

	[Display(Name = "Discount in whole numbers, 10 = 10% (optional)")]
	public int? Discount { get; set; }

	[Required(ErrorMessage = "You need to provide a category")]
	[Display(Name = "Category*")]
	public int CategoryId { get; set; }

	public static implicit operator ProductEntity(RegisterProductViewModel model)
	{
		return new ProductEntity
		{
			Name = model.Name,
			Description = model.Description,
			ImageUrl = model.ImageUrl,
			Price = model.Price,
			Discount = model.Discount,
			CategoryId = model.CategoryId,
		};
	}
}
