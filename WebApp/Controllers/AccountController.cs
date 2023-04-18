using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers;

public class AccountController : Controller
{
	private readonly AuthService _authService;

    public AccountController(AuthService authService)
    {
        _authService = authService;
    }

    [Authorize]
	public IActionResult Index()
	{
		return View();
	}

	[HttpGet]
	public IActionResult SignUp()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> SignUp(RegisterAccountViewModel model)
	{
        if (ModelState.IsValid)
        {
            if (await _authService.SignUpAsync(model))
            {
                return RedirectToAction("SignIn");
            }
            else
            {
                ModelState.AddModelError("", "A User with the same email already exists");
            }

        }
        return View();
    }

	[HttpGet]
	public IActionResult SignIn()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> SignIn(LoginAccountViewModel model)
	{
		return View();
	}

	[Authorize]
	public new async Task<IActionResult> SignOut()
	{
		return LocalRedirect("/");
	}
}
