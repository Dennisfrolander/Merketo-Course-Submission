using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers;

public class AdminController : Controller
{
    private readonly UserService _userService;

	public AdminController(UserService userService)
	{
		_userService = userService;
	}

	[Authorize(Roles = "admin")]
    public IActionResult Index()
    {
        return View();
    }
	[Authorize(Roles = "admin")]
	public async Task<IActionResult> Profile()
    {
        
        return View();
    }
	[Authorize(Roles = "admin")]
	public async Task<IActionResult> Users()
    {
		List<UserWithRolesViewModel> users = (List<UserWithRolesViewModel>)await _userService.GetAllUserWithRoles();

		return View(users);
    }



	[Authorize(Roles = "admin")]
	public IActionResult Products()
    {
        return View();
    }
}
