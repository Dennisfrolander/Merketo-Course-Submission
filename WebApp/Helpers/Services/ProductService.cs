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
			var exist = await _productRepository.GetAsync(x => x.Name == model.Name);
			if (exist == null)
			{
				await _productRepository.CreateAsync(productEntity);
				return true;
			}
			return false;

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

	#region GetAllWithTags

	public async Task<IEnumerable<ProductCardViewModel>> GetAllWithTagsAsync()
	{
		try
		{
			List<ProductCardViewModel> products = new();

			var productEntities = await _productRepository.GetAllWithTagsAsync();


			foreach (var productEntity in productEntities.OrderByDescending(x => x.Id))
			{
				var tagList = new List<string>();
				foreach (var tag in productEntity.Tags)
				{
					tagList.Add(tag.Tag.TagName);
				}
				ProductCardViewModel product = productEntity;
				product.Tags = tagList;
				products.Add(product);
			}

			return products;
		}
		catch { return null!; }
	}

	public async Task<IEnumerable<ProductCardViewModel>> GetAllWithTagsAsync(string tagName)
	{
		try
		{
			List<ProductCardViewModel> products = new();

			var productEntities = await _productRepository.GetAllWithTagsAsync(x => x.Tags.Any(t => t.Tag.TagName == tagName));


			foreach (var productEntity in productEntities.OrderByDescending(x => x.Id))
			{
				var tagList = new List<string>();
				if(productEntity.Tags != null)
				{
					foreach (var tag in productEntity.Tags)
					{
						tagList.Add(tag.Tag.TagName);
					}
				}
				ProductCardViewModel product = productEntity;
				product.Tags = tagList;
				products.Add(product);
			}

			return products;
		}
		catch { return null!; }
	}

	public async Task<IEnumerable<ProductCardViewModel>> GetAllWithTagsAsync(string tagNameOne, string tagNameTwo)
	{
		try
		{
			List<ProductCardViewModel> products = new();

			var productEntities = await _productRepository.GetAllWithTagsAsync(x => x.Tags.Any(t => t.Tag.TagName == tagNameOne && t.Tag.TagName == tagNameTwo));


			foreach (var productEntity in productEntities.OrderByDescending(x => x.Id))
			{
				var tagList = new List<string>();
				if (productEntity.Tags != null)
				{
					foreach (var tag in productEntity.Tags)
					{
						tagList.Add(tag.Tag.TagName);
					}
				}
				ProductCardViewModel product = productEntity;
				product.Tags = tagList;
				products.Add(product);
			}

			return products;
		}
		catch { return null!; }
	}
#endregion

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
