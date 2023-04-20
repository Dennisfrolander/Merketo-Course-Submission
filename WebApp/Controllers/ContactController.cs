using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers;

public class ContactController : Controller
{
	private readonly ContactUsService _contactUsService;

    public ContactController(ContactUsService contactUsService)
    {
        _contactUsService = contactUsService;
    }

    [HttpGet]
	public IActionResult Index()
	{
		return View();
	}

	[HttpPost]
    public async Task<IActionResult> Index(RegisterContactUsViewModel model)
    {
		if(ModelState.IsValid)
		{
			if (await _contactUsService.CreateAsync(model))
				return LocalRedirect("/");
		}
        else
            ModelState.AddModelError("", "Something went wrong, try again later.");
        return View();
    }
}
