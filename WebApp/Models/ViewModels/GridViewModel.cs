namespace WebApp.Models.ViewModels;

public class GridViewModel
{
    public string? Title { get; set; }
    public List<ProductCardViewModel> Cards { get; set; } = new List<ProductCardViewModel>();

    public string? ErrorMessage { get; set; }
}
