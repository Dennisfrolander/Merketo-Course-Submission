namespace WebApp.Models.ViewModels;

public class GridCollectionViewModel
{
	public string Title { get; set; } = "";
	public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
	public List<ProductCardViewModel> Products { get; set; } = new List<ProductCardViewModel>();

}
