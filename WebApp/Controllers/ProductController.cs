using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;

namespace WebApp.Controllers;

public class ProductController : Controller
{
	private readonly ProductService _productService;

	public ProductController(ProductService productService)
	{
		_productService = productService;
	}

	public async Task<IActionResult> Index()
	{
		var products = await _productService.GetAllAsync();
		return View(products);
	}

	public async Task<IActionResult> Details(string name)
	{
		var product = await _productService.GetDetailsAsync(name);
		if(product != null)
			return View(product);
		
		else 
			return RedirectToAction("Index");
	}
}
