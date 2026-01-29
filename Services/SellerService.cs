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

    public async Task<List<Seller>> FindAllAsync()
    {
        return await _context.Seller.ToListAsync();
    }

    public async Task InsertAsync(Seller seller)
    {
        _context.Add(seller);
        _context.SaveChangesAsync();
    }

    public async Task<Seller> FindByIdAsync(int id)
    {
        return await _context.Seller.Include(obj=>obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
    }

    public async Task RemoveAsync(int id)
    {
        var obj = await _context.Seller.FindAsync(id);
        _context.Seller.Remove(obj);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Seller seller)
    {
        bool hasAny = await _context.Seller.AnyAsync(obj => obj.Id == seller.Id);
        if (!hasAny)
        {
            throw new NotFoundException("Id not found");
        }

        try
        {
            _context.Update(seller);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            throw new DbConcurrencyException(e.Message);
        }
    }
}
