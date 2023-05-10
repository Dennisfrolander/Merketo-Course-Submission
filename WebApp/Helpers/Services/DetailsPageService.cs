
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class DetailsPageService
{
    private readonly ProductService _productService;
    private readonly RelatedGridService _relatedGridService;

    public DetailsPageService(ProductService productService, RelatedGridService relatedGridService)
    {
        _productService = productService;
        _relatedGridService = relatedGridService;
    }

    public async Task<DetailsPageViewModel> GetAsync(string name)
    {
        var viewModel = new DetailsPageViewModel
        {
            ProductDetailsCard = await _productService.GetDetailsAsync(name)
        };
        viewModel.RelatedGrid = await _relatedGridService.GetByCategoriesAsync(name, "Related Products", 4);

        return viewModel;
    }
}
