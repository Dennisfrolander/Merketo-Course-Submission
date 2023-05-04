using WebApp.Helpers.Repositories.DataRepos;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class GridDiscountService
{

    private readonly ProductRepository _productRepository;

    public GridDiscountService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<GridDiscountViewModel> GetHighestDiscountAsync()
    {

        //UpToSale is hardcoded for the moment, might do a table in the database for it later.
        GridDiscountViewModel viewModel = new()
        {
            UpToSale =
            {
                Title = "UP TO SELL",
                DiscountTitle = "50% OFF",
                Ingress = "Get the best price",
                Description = " Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki",
            }
        };


        var discountProducts = await _productRepository.GetAllAsync(x => x.Discount > 0);

        var sortedProducts = discountProducts.OrderByDescending(x => x.Discount).ToList();

        if (sortedProducts.Count >= 2)
        {
            viewModel.ProductCardOne = sortedProducts[0];
            viewModel.ProductCardTwo = sortedProducts[1];
            return viewModel;
        }
        else return null!;




    }
}
