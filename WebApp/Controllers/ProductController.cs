using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers;

public class ProductController : Controller
{
	private readonly ProductService _productService;
	private readonly DetailsPageService _detailsPageService;
	private readonly CookieService _cookieService;

	public ProductController(ProductService productService, DetailsPageService detailsPageService, CookieService cookieService)
	{
		_productService = productService;
		_detailsPageService = detailsPageService;
		_cookieService = cookieService;
	}

	public async Task<IActionResult> Index()
	{
		var products = await _productService.GetAllWithTagsAsync();
		return View(products);
	}

	public async Task<IActionResult> Details(string name)
	{
		DetailsPageViewModel page = await _detailsPageService.GetAsync(name);
		await _cookieService.SaveCookieAsync(name);
		if(page != null)
			return View(page);
		
		else 
			return RedirectToAction("Index");
	}
}
