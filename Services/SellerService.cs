using SalesApp.Data;
using SalesApp.Models;

namespace SalesApp.Services;

public class SellerService
{
    private readonly SalesAppContext _context;
    public SellerService(SalesAppContext context)
    {
        _context = context;
    }

    public List<Seller> FindAll()
    {
        return _context.Seller.ToList();
    }

    public void Insert(Seller seller)
    {
        seller.Department = _context.Department.First();
        _context.Add(seller);
        _context.SaveChanges();
    }
}
