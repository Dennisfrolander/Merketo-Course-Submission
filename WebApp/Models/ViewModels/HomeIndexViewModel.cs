namespace WebApp.Models.ViewModels;

public class HomeIndexViewModel
{
    public string ViewDataTitle = "Home";
    public ShowcaseViewModel ShowcaseViewModel { get; set; } = new ShowcaseViewModel();
    public GridCollectionViewModel BestCollection { get; set; } = new GridCollectionViewModel();
    public GridDiscountViewModel UpTosale { get; set; } = new GridDiscountViewModel();
    public CarouselWithProductCardsViewModel PopularCarousel { get; set; } = new CarouselWithProductCardsViewModel();
}
