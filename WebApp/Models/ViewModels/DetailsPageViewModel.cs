namespace WebApp.Models.ViewModels;

public class DetailsPageViewModel
{
    public ProductDetailsCardViewModel ProductDetailsCard { get; set; } = new ProductDetailsCardViewModel();

    public GridViewModel RelatedGrid { get; set; } = new GridViewModel();

    public GridViewModel RecentlyViewed { get; set; } = new GridViewModel();
}
