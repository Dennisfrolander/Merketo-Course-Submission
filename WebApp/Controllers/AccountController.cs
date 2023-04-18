using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers;

public class AccountController : Controller
{
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
