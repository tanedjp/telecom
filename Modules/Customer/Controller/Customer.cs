using Microsoft.AspNetCore.Mvc;
using telecom.Modules.Customer.Models;
using telecom.Modules.Customer.Services;

namespace telecom.Modules.Customer.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()  => Ok(await _customerService.GetAllAsync());

    [HttpGet("{uid}")]
    public async Task<IActionResult> Get(Guid uid)
    {
        var result = await _customerService.GetByIdAsync(uid);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(customer model)
    {
        var result = await _customerService.CreateAsync(model);
        return CreatedAtAction(nameof(Get),
            new { uid = result.customer_uid },
            result);
    }

    [HttpPut("{uid}")]
    public async Task<IActionResult> Update(Guid uid, customer model)
    {
        var ok = await _customerService.UpdateAsync(uid, model);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{uid}")]
    public async Task<IActionResult> Delete(Guid uid)
    {
        var ok = await _customerService.DeleteAsync(uid);
        return ok ? NoContent() : NotFound();
    }
}