using WebApp.Helpers.Repositories.DataRepos;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class GridCollectionService
{
	private readonly ProductRepository _productRepository;
	private readonly CategoryService _categoryService;

	public GridCollectionService(ProductRepository productRepository, CategoryService categoryService)
	{
		_productRepository = productRepository;
		_categoryService = categoryService;
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

            foreach (var product in await _productRepository.GetAllAsync(x => x.IsNew == true))
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

            foreach (var product in await _productRepository.GetAllAsync(x => x.IsNew == true && x.IsFeatured == true))
            {
                viewModel.Products.Add(product);
            }

            return viewModel;
        }
        catch { return null!; }
    }


}
