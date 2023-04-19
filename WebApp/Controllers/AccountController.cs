using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
            if (await _authService.UserAlreadyExistsAsync(x => x.Email == model.Email))
                ModelState.AddModelError("", "A User with the same email already exists");

            else if (await _authService.SignUpAsync(model))
                return RedirectToAction("SignIn");

            else
                ModelState.AddModelError("", "Something went wrong");

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
		if (ModelState.IsValid)
		{
			if (await _authService.SignInAsync(model))
				return RedirectToAction("index");
			else
				ModelState.AddModelError("", "Incorrect email or password");
		}
		return View();
	}

	[Authorize]
	public new async Task<IActionResult> SignOut()
	{
        if (await _authService.SignOutAsync(User))
        {
            return LocalRedirect("/");
        }
        else
        {
            return RedirectToAction("index");
        }
    }
}
