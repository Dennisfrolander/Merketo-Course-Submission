namespace WebApp.Models.ViewModels;

public class CarouselWithProductCardsViewModel
{
    public string? Title { get; set; }
    public List<ProductCardViewModel> ProductCards { get; set; } = new List<ProductCardViewModel>();
}
