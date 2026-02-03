using Microsoft.EntityFrameworkCore;
using telecom.Modules.Telecom.Data;
using telecom.Modules.Customer.Models;

namespace telecom.Modules.Customer.Services;

public class RegisterPackageService
{
    private readonly TelecomContext _context;

    public RegisterPackageService(TelecomContext context)
    {
        _context = context;
    }

    public async Task<List<register_package>> GetAllAsync()
    {
        return await _context.register_package.ToListAsync();
    }

    public async Task<register_package?> GetByIdAsync(Guid uid)
    {
        return await _context.register_package.FindAsync(uid);
    }

    public async Task<register_package> CreateAsync(register_package model)
    {
        model.customer_uid = Guid.NewGuid();

        _context.register_package.Add(model);
        await _context.SaveChangesAsync();

        return model;
    }

    public async Task<bool> UpdateAsync(Guid uid, register_package model)
    {
        var existing = await _context.register_package.FindAsync(uid);
        if (existing == null) return false;
        existing.customer_uid = model.customer_uid;
        existing.package_uid = model.package_uid;
        existing.register_date = model.register_date;
        existing.expired_date = model.expired_date;
        _context.register_package.Update(existing);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid uid)
    {
        var existing = await _context.register_package.FindAsync(uid);
        if (existing == null) return false;

        _context.Remove(existing);
        await _context.SaveChangesAsync();

        return true;
    }
    

    public async Task<bool> RegisterPackageAsync(Guid? customer_uid, Guid? package_uid)
    {
        var now = DateTime.UtcNow;
        var activePackage = await _context.register_package
            .Where(x => x.customer_uid == customer_uid &&
                        x.expired_date > now)
            .FirstOrDefaultAsync();

        if (activePackage != null) return false;

        var register = new register_package
        {
            register_package_uid = Guid.NewGuid(),
            customer_uid = customer_uid,
            package_uid = package_uid,
            register_date = now,
            expired_date = now.AddDays(30) 
        };

        _context.register_package.Add(register);
        var customer = await _context.customer
            .FindAsync(customer_uid);

        customer?.register_package_uid = package_uid;
        if (customer != null)
        {
            customer.register_package_uid = package_uid;
            _context.customer.Update(customer);
        }
        await _context.SaveChangesAsync();

        return true;
    }
}
