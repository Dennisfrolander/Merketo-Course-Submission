using WebApp.Helpers.Repositories.DataRepos;
using WebApp.Models.Entities;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class ProductService
{
	private readonly ProductRepository _productRepository;

	public ProductService(ProductRepository productRepository)
	{
		_productRepository = productRepository;
	}

	public async Task<bool> CreateAsync(RegisterProductViewModel model)
	{
		try
		{
			ProductEntity productEntity = model;
			await _productRepository.CreateAsync(productEntity);
			return true;
		}
		catch { return false; }
	}

	public async Task<IEnumerable<ProductCardViewModel>> GetAllAsync()
	{
		try
		{
			List<ProductCardViewModel> products = new();

			var productEntities = await _productRepository.GetAllAsync();

			foreach ( var productEntity in productEntities.OrderByDescending(x => x.Id))
			{
				products.Add( productEntity );
			}

			return products;
		}
		catch { return null!; }
	}


	public async Task<ProductDetailsCardViewModel> GetDetailsAsync(string name)
	{
		try
		{
			ProductDetailsCardViewModel productDetails = await _productRepository.GetAsync(x => x.Name == name);
			return productDetails!;
		}
		catch { return null!; }
	}
}
