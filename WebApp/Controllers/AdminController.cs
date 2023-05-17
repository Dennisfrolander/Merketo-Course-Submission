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
    private readonly ProductService _productService;
    private readonly TagService _tagService;
	#endregion

	#region Constructor
	public AdminController(UserService userService, AdminService adminService, ProductService productService, TagService tagService)
	{
		_userService = userService;
		_adminService = adminService;
		_productService = productService;
		_tagService = tagService;
	}
	#endregion

    public IActionResult CreateBlogPost()
    {
        return View();
    }


	#region Users - All, Create, Edit
	public async Task<IActionResult> AllUsers()
    {
        List<UserWithRolesViewModel> users = (List<UserWithRolesViewModel>)await _userService.GetAllUserWithRolesAsync();

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


    public async Task<IActionResult> DeleteUser(string id)
    {
        if(await _adminService.DeleteUser(id))
            return RedirectToAction("AllUsers");
        else
            return RedirectToAction("AllUsers");


	}
    #endregion

    #region Products - All, Create, Edit
    [HttpGet]
	public IActionResult Products()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> CreateProduct()
    {
        ViewBag.Tags = await _tagService.GetTagsAsync();
        return View();
    }

    [HttpPost]
	public async Task<IActionResult> CreateProduct(RegisterProductViewModel model, string[] tags)
	{
        if (ModelState.IsValid)
        {
            if (await _productService.CreateAsync(model))
            {
                await _tagService.AddProductTagsAsync(model, tags);
				return RedirectToAction("AllProducts");
			}
                
			ModelState.AddModelError("", "Product with the same name already exist.");
		}
        

		ModelState.AddModelError("", "You have to put valid information in the required fields");
		ViewBag.Tags = await _tagService.GetTagsAsync(tags);
		return View();
		

	}

	[HttpGet]
	public IActionResult AllProducts()
	{
		return View();
	}

	#endregion




}
