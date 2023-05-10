namespace WebApp.Models.ViewModels;

public class RelatedGridViewModel
{
    public string? Title { get; set; }
    public List<ProductCardViewModel> Cards { get; set; } = new List<ProductCardViewModel>();
}
