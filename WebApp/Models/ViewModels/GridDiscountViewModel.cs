namespace WebApp.Models.ViewModels;

public class GridDiscountViewModel
{
    public DiscountCardViewModel UpToSale { get; set; } = new DiscountCardViewModel();
    public ProductCardViewModel ProductCardOne { get; set; } = new ProductCardViewModel();
    public ProductCardViewModel ProductCardTwo { get; set; } = new ProductCardViewModel();
}
