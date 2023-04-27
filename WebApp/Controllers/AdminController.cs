using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers;

[Authorize(Roles = "admin")]
public class AdminController : Controller
{
	#region Services

	private readonly UserService _userService;
    private readonly AdminService _adminService;
	#endregion

	#region Constructor
	public AdminController(UserService userService, AdminService adminService)
    {
        _userService = userService;
        _adminService = adminService;
    }
	#endregion
	public IActionResult Index()
    {
        return View();
    }
	public IActionResult Profile()
    {
        
        return View();
    }
	#region Users - All, Create, Edit
	public async Task<IActionResult> AllUsers()
    {
        List<UserWithRolesViewModel> users = (List<UserWithRolesViewModel>)await _userService.GetAllUserWithRoles();

        return View(users);
    }

    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(AdminRegisterUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _userService.UserAlreadyExistsAsync(x => x.Email == model.Email))
                ModelState.AddModelError("", "A User with the same email already exists");
            else if (await _adminService.CreateUserAsync(model))
                return RedirectToAction("Allusers");
        }
        else
            ModelState.AddModelError("", "You have to put valid information in the required fields");
        return View();
    }

    [HttpGet]
    [Route("edit/{id}")]
    public async Task<IActionResult> EditUser(string id)
    {
        AdminChangeRoleOfUserViewModel model = await _userService.GetUserWithRolesAsync(id);
        return View(model);
    }

    [HttpPost]
    [Route("edit/{id}")]
    public async Task<IActionResult> EditUser (AdminChangeRoleOfUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _adminService.UpdateRole(model))
                return RedirectToAction("AllUsers");
            else
            {
				ModelState.AddModelError("", "Something wrong happened, try again.");
			}
        }
        else
        {
			ModelState.AddModelError("", "You have to put valid information in the required fields");
		}
        return View();
    }
    #endregion

    #region Products - 
    [HttpGet]
	public IActionResult Products()
    {
        return View();
    }

    [HttpGet]
    public IActionResult CreateProduct()
    {
        return View();
    }


	#endregion
}
