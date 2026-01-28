using SalesApp.Data;
using SalesApp.Models;

namespace SalesApp.Services;

public class DepartmentService
{
    private readonly SalesAppContext _context;
    public DepartmentService(SalesAppContext context)
    {
        _context = context;
    }

    public List<Department> FindAll()
    {
        return _context.Department.OrderBy(x => x.Name).ToList();
    }


}
