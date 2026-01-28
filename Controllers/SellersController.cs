using Microsoft.AspNetCore.Mvc;
using SalesApp.Services;

namespace SalesApp.Controllers;

public class SellersController : Controller
{
    private readonly SellerService _sellerService;

    public SellersController(SellerService sellerService)
    {
        _sellerService = sellerService;
    }

    // GET
    public IActionResult Index()
    {
        var list = _sellerService.FindAll();
        return View(list);
    }
}
