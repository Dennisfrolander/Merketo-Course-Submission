
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class DetailsPageService
{
    private readonly ProductService _productService;
    private readonly RelatedGridService _relatedGridService;
    private readonly CookieService _cookieService;
	public DetailsPageService(ProductService productService, RelatedGridService relatedGridService, CookieService cookieService)
	{
		_productService = productService;
		_relatedGridService = relatedGridService;
		_cookieService = cookieService;
	}

	public async Task<DetailsPageViewModel> GetAsync(string name)
    {
		var viewModel = new DetailsPageViewModel
		{
			ProductDetailsCard = await _productService.GetDetailsAsync(name),
			RelatedGrid = await _relatedGridService.GetByCategoriesAsync(name, "Related Products", 4),
			RecentlyViewed = new GridViewModel
			{
				Title = "Recently Viewed",
				Cards = _cookieService.GetProduct(),
				ErrorMessage = "No recenlty viewed at the moment",
			}
		};

		return viewModel;
    }
}
