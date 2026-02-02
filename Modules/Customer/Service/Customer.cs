using Microsoft.EntityFrameworkCore;
using telecom.Modules.Telecom.Data;
using telecom.Modules.Customer.Models;

namespace telecom.Modules.Customer.Services;

public class CustomerService
{
    private readonly TelecomContext _context;

    public CustomerService(TelecomContext context)
    {
        _context = context;
    }

    public async Task<List<customer>> GetAllAsync()
    {
        return await _context.customer.ToListAsync();
    }

    public async Task<customer?> GetByIdAsync(Guid uid)
    {
        return await _context.customer.FindAsync(uid);
    }

    public async Task<customer> CreateAsync(customer model)
    {
        model.customer_uid = Guid.NewGuid();

        _context.customer.Add(model);
        await _context.SaveChangesAsync();

        return model;
    }

    public async Task<bool> UpdateAsync(Guid uid, customer model)
    {
        var existing = await _context.customer.FindAsync(uid);
        if (existing == null) return false;
        existing.customer_first_name = model.customer_first_name;
        existing.customer_last_name = model.customer_last_name;
        existing.phone_number = model.phone_number;
        existing.email = model.email;
        existing.main_addr_no = model.main_addr_no;
        existing.main_addr_building = model.main_addr_building;
        existing.main_addr_soi = model.main_addr_soi;
        existing.main_addr_moo = model.main_addr_moo;
        existing.main_addr_province = model.main_addr_province;
        existing.main_addr_district = model.main_addr_district;
        existing.main_addr_sub_district = model.main_addr_sub_district;
        existing.main_addr_postcode = model.main_addr_postcode;
        existing.is_main_doc = model.is_main_doc;
        existing.doc_addr_no = model.doc_addr_no;
        existing.doc_addr_building = model.doc_addr_building;
        existing.doc_addr_soi = model.doc_addr_soi;
        existing.doc_addr_moo = model.doc_addr_moo;
        existing.doc_addr_province = model.doc_addr_province;
        existing.doc_addr_district = model.doc_addr_district;
        existing.doc_addr_sub_district = model.doc_addr_sub_district;
        existing.doc_addr_postcode = model.doc_addr_postcode;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid uid)
    {
        var existing = await _context.customer.FindAsync(uid);
        if (existing == null) return false;

        _context.Remove(existing);
        await _context.SaveChangesAsync();

        return true;
    }
}
