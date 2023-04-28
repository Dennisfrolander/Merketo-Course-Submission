namespace WebApp.Models.ViewModels;

public class ProductDetailsCardViewModel
{
	public string Name { get; set; } = null!;
	public string ImageUrl { get; set; } = null!;
	public string Description { get; set; } = null!;

	public bool? New { get; set; }
	public bool? Featured { get; set; }
	public bool? Popular { get; set; }
	public decimal Price { get; set; }
	public int? Discount { get; set; }
	public CategoryViewModel Category { get; set; } = null!;
}
