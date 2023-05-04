using WebApp.Helpers.Repositories.DataRepos;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class CarouselService
{
    private readonly ProductRepository _productRepository;

    public CarouselService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<CarouselWithProductCardsViewModel> GetPopular(string title)
    {
        try
        {
            CarouselWithProductCardsViewModel carousel = new()
            {
                Title = title
            };

            List<ProductCardViewModel> popularProduct = new();

            foreach(var product in await _productRepository.GetAllAsync(x => x.IsPopular == true))
            {
                popularProduct.Add(product);
            }

            if(popularProduct.Count >= 18)
            {
                for (int i = 0; i < 18; i++)
                    carousel.ProductCards.Add(popularProduct[i]);
                
                return carousel;
            }
            else if (popularProduct.Count >= 12)
            {
                for (int i = 0; i < 12; i++)
                    carousel.ProductCards.Add(popularProduct[i]);
                return carousel;
            }
            else if (popularProduct.Count >= 6)
            {
                for (int i = 0; i < 6; i++)
                    carousel.ProductCards.Add(popularProduct[i]);
                return carousel;
            }
            else
            {
                return null!;
            }

           

            
        }
        catch { return null!; }
    }
}
