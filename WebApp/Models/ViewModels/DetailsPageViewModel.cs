namespace WebApp.Models.ViewModels;

public class DetailsPageViewModel
{
    public ProductDetailsCardViewModel ProductDetailsCard { get; set; } = new ProductDetailsCardViewModel();

    public RelatedGridViewModel RelatedGrid { get; set; } = new RelatedGridViewModel();
}
