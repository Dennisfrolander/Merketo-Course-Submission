using WebApp.Models.Entities;

namespace WebApp.Models.ViewModels;

public class ProductCardViewModel
{
	public string Name { get; set; } = null!;
	public string ImageUrl { get; set; } = null!;
	public decimal Price { get; set; }
	public int? Discount { get; set; }
	public CategoryViewModel Category { get; set; } = null!;
	public List<string>? Tags { get; set; }


	public static implicit operator ShowcaseViewModel(ProductCardViewModel entity)
	{
		return new ShowcaseViewModel
		{
			Title = entity.Name,
			ImageUrl = entity.ImageUrl,
		};
	}

}
