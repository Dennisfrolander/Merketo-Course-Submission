using System.Text.Json;
using WebApp.Helpers.Repositories.DataRepos;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class CookieService
{
	private readonly ProductRepository _productRepository;
	private readonly IHttpContextAccessor _httpContextAccessor;

	public CookieService(ProductRepository productRepository, IHttpContextAccessor httpContextAccessor)
	{
		_productRepository = productRepository;
		_httpContextAccessor = httpContextAccessor;
	}

	public List<ProductCardViewModel> GetOrCreateProductCookies()
	{
		var productCardCookies = _httpContextAccessor.HttpContext!.Request.Cookies["Product-cookies-merketo"];
		List<ProductCardViewModel> productViewModels = new();

		if(productCardCookies != null)
		{
			foreach (var product in JsonSerializer.Deserialize<List<ProductCardViewModel>>(productCardCookies!)!)
			{
				productViewModels.Add(product);
			}
			return productViewModels;
		}
		else { return productViewModels; }
	}


	public void SetCookie(ProductCardViewModel model)
	{
		List<ProductCardViewModel> products = new();

		var cookies = _httpContextAccessor.HttpContext!.Request.Cookies["Product-cookies-merketo"];

		if (cookies != null)
		{
			products = JsonSerializer.Deserialize<List<ProductCardViewModel>>(cookies!)!;

			products.RemoveAll(p => p.Name == model.Name);


			if (products.Count >= 4)
			{
				products.RemoveAt(0);
			}
		}

		products.Add(model);


		var options = new CookieOptions
		{
			Expires = DateTime.Now.AddDays(1),
			Path = "/"
		};

		var json = JsonSerializer.Serialize(products);
		_httpContextAccessor.HttpContext!.Response.Cookies.Append("Product-cookies-merketo", json, options);
	}

	public async Task SaveCookieAsync(string name)
	{
		ProductCardViewModel product = await _productRepository.GetAsync(x => x.Name == name);

		if (product != null)
		{
			SetCookie(product);
		}
	}

	public List<ProductCardViewModel> GetProduct()
	{
		var hej = _httpContextAccessor.HttpContext!.Request.Cookies["Product-cookies-merketo"];

		if(hej != null)
		{
			List<ProductCardViewModel> products = new();
			foreach (var product in JsonSerializer.Deserialize<List<ProductCardViewModel>>(hej!)!)
			{
				products.Add(product);
			}
			return products.OrderByDescending(p => products.IndexOf(p)).ToList();
		}
		else
		{
			return null!;
		}


	}
}
