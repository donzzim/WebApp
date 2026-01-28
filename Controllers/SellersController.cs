using Microsoft.AspNetCore.Mvc;

namespace SalesApp.Controllers;

public class SellersController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}