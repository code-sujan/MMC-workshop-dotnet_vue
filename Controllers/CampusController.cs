using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.DataContext;
using test.Entity;
using test.Models;

namespace test.Controllers;

public class CampusController : Controller
{
    private readonly AppDbContext _context;

    public CampusController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> GetList()
    {
        var list = await _context.CampusList.ToListAsync();
        return Ok(list);
    }

    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCampus(CampusVm model)
    {
        try
        {
            var campus = new Campus
            {
                Name = model.Name,
                Address = model.Address
            };
            await _context.CampusList.AddAsync(campus);
            await _context.SaveChangesAsync();
            return Ok("Success");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}