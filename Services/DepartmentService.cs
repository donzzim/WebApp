using Microsoft.EntityFrameworkCore;
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

    public async Task<List<Department>> FindAllAsync()
    {
        return await _context.Department.OrderBy(x => x.Name).ToListAsync();
    }


}
