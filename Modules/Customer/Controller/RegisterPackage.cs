using Microsoft.AspNetCore.Mvc;
using telecom.Modules.Customer.Models;
using telecom.Modules.Customer.Services;

namespace telecom.Modules.Customer.Controllers;

[ApiController]
[Route("api/register_packages")]
public class RegisterPackageController : ControllerBase
{
    private readonly RegisterPackageService _registerPackageService;

    public RegisterPackageController(RegisterPackageService registerPackageService)
    {
        _registerPackageService = registerPackageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _registerPackageService.GetAllAsync());

    [HttpGet("{uid}")]
    public async Task<IActionResult> Get(Guid uid)
    {
        var result = await _registerPackageService.GetByIdAsync(uid);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(register_package model)
    {
        var result = await _registerPackageService.CreateAsync(model);
        return CreatedAtAction(nameof(Get),
            new { uid = result.customer_uid },
            result);
    }

    [HttpPut("{uid}")]
    public async Task<IActionResult> Update(Guid uid, register_package model)
    {
        var ok = await _registerPackageService.UpdateAsync(uid, model);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{uid}")]
    public async Task<IActionResult> Delete(Guid uid)
    {
        var ok = await _registerPackageService.DeleteAsync(uid);
        return ok ? NoContent() : NotFound();
    }
    [HttpPost("register")]
    public async Task<IActionResult> Subscribe([FromBody] register_request request)
    {
        var ok = await _registerPackageService.RegisterPackageAsync(request.customer_uid, request.package_uid);

        if (!ok)
            return BadRequest(new
            {
                message = "เกิดข้อผิดพลาด"
            });

        return Ok(new
        {
            message = "สมัครสำเร็จ"
        });
    }
}