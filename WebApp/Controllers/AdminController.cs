using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class AdminController : Controller
{
    [Authorize(Roles = "admin")]
    public IActionResult Index()
    {
        return View();
    }
}
