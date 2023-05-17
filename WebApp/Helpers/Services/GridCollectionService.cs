using WebApp.Helpers.Repositories.DataRepos;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class GridCollectionService
{
    private readonly ProductService _productService;
	private readonly CategoryService _categoryService;

	public GridCollectionService(CategoryService categoryService, ProductService productService)
	{
		_categoryService = categoryService;
		_productService = productService;
	}

	public async Task<GridCollectionViewModel> GetNewAsync(string title)
	{
        try
        {
            GridCollectionViewModel viewModel = new()
            {
                Title = title
            };

            foreach (var category in await _categoryService.GetAllAsync())
            {
                viewModel.Categories.Add(category);
            }

            foreach (var product in await _productService.GetAllWithTagsAsync("New"))
            {
                viewModel.Products.Add(product);
            }

            return viewModel;
        }
        catch { return null!; }
	}

    public async Task<GridCollectionViewModel> GetNewAndFeaturedAsync(string title)
    {
        try
        {
            GridCollectionViewModel viewModel = new()
            {
                Title = title
            };

            foreach (var category in await _categoryService.GetAllAsync())
            {
                viewModel.Categories.Add(category);
            }

			foreach (var product in await _productService.GetAllWithTagsAsync("New", "Featured"))
			{
				viewModel.Products.Add(product);
			}

			return viewModel;
        }
        catch { return null!; }
    }


}
