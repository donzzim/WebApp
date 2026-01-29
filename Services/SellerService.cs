using SalesApp.Data;
using SalesApp.Models;
using Microsoft.EntityFrameworkCore;
using SalesApp.Services.Exceptions;

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
        _context.Add(seller);
        _context.SaveChanges();
    }

    public Seller FindById(int id)
    {
        return _context.Seller.Include(obj=>obj.Department).FirstOrDefault(obj => obj.Id == id);
    }

    public void Remove(int id)
    {
        var obj = _context.Seller.Find(id);
        _context.Seller.Remove(obj);
        _context.SaveChanges();
    }

    public void Update(Seller seller)
    {
        if (!_context.Seller.Any(obj => obj.Id == seller.Id))
        {
            throw new NotFoundException("Id not found");
        }

        try
        {
            _context.Update(seller);
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException e)
        {
            throw new DbConcurrencyException(e.Message);
        }
    }
}
