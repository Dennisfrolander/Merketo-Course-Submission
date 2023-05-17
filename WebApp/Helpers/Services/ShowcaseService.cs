using WebApp.Helpers.Repositories.DataRepos;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class ShowcaseService
{
	private readonly ProductService _productService;

	public ShowcaseService(ProductService productService)
	{
		_productService = productService;
	}

	public async Task<ShowcaseViewModel> GetRandomFeaturedAsync(string ingress)
	{
		try
		{
			List<ShowcaseViewModel> listOfshowCaseViewModel = new();


			foreach (var product in await _productService.GetAllWithTagsAsync("Featured"))
			{
				listOfshowCaseViewModel.Add(product);
			}

			if (listOfshowCaseViewModel != null)
			{
				var random = new Random();

				var randomShowcase = listOfshowCaseViewModel[random.Next(listOfshowCaseViewModel.Count)];
				randomShowcase.Ingress = ingress;
				return randomShowcase;
			}
			else return null!;
		}
		catch
		{
			return null!;
		}

	}
}
