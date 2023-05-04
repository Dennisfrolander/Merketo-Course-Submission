using WebApp.Helpers.Repositories.DataRepos;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class ShowcaseService
{
	private readonly ProductRepository _productRepository;

	public ShowcaseService(ProductRepository productRepository)
	{
		_productRepository = productRepository;
	}

	public async Task<ShowcaseViewModel> GetRandomFeaturedAsync(string ingress)
	{
		try
		{
			List<ShowcaseViewModel> listOfshowCaseViewModel = new();


			foreach (var product in await _productRepository.GetAllAsync(x => x.IsFeatured == true))
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
