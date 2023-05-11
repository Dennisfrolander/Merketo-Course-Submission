using WebApp.Helpers.Repositories.DataRepos;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class RelatedGridService
{
    private readonly ProductRepository _productRepository;

    public RelatedGridService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<GridViewModel> GetByCategoriesAsync(string productName, string title, int numberOfCards)
    {
        try
        {

            List<ProductCardViewModel> products = new();

            var product = await _productRepository.GetAsync(x => x.Name == productName);


            foreach(var _product in await _productRepository.GetAllAsync(x => x.Category.CategoryName == product.Category.CategoryName))
                products.Add(_product);

            List<ProductCardViewModel> productsWithRestrictedNumberOfCards = new();

            if (products.Count < numberOfCards)
            {
                foreach (var _product in products)
                {
                    if(_product.Name != productName)
						productsWithRestrictedNumberOfCards.Add(_product);
				}   
            }
            else
            {
                for (int i = 0; i < numberOfCards; i++)
                    if (products[i].Name != productName)
                        productsWithRestrictedNumberOfCards.Add(products[i]);
            }


            GridViewModel relatedGridViewModel = new()
            {
                Title = title,
                Cards = productsWithRestrictedNumberOfCards,
                ErrorMessage = "No related products at the moment",
            };

            return relatedGridViewModel;
        }
        catch { return null!; }
    }
}
