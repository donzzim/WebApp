using Microsoft.AspNetCore.Mvc;
using SalesApp.Models;

namespace SalesApp.Controllers;

public class DepartmentsController: Controller
{
    public IActionResult Index()
    {
        List<Department> list = new List<Department>();
        list.Add(new Department{Id=1, Name="Electronics"});

        return View();
    }
}
