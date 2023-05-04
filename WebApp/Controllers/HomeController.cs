using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ShowcaseService _showcaseService;
    private readonly GridCollectionService _gridCollectionService;
    private readonly GridDiscountService _gridDiscountService;
    private readonly CarouselService _carouselService;

    public HomeController(ShowcaseService showcaseService, GridCollectionService gridCollectionService, GridDiscountService gridDiscountService, CarouselService carouselService)
    {
        _showcaseService = showcaseService;
        _gridCollectionService = gridCollectionService;
        _gridDiscountService = gridDiscountService;
        _carouselService = carouselService;
    }

    public async Task<IActionResult> Index()
    {
        var homeViewModel = new HomeIndexViewModel
        {
            ShowcaseViewModel = await _showcaseService.GetRandomFeaturedAsync("WELCOME TO BMERKETO SHOP"),
            BestCollection = await _gridCollectionService.GetNewAsync("Best Collection"),
            UpTosale = await _gridDiscountService.GetHighestDiscountAsync(),
            PopularCarousel = await _carouselService.GetPopular("Popular Products"),
        };
        return View(homeViewModel);
    }
}
