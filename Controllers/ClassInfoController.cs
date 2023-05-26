using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.DataContext;
using test.Models;
using test.Src.Entity;

namespace test.Controllers;

public class ClassInfoController : Controller
{
    private readonly AppDbContext _context;
    public ClassInfoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var list = await _context.ClassInfos.ToListAsync();
        return View(list);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new ClassInfoVm());
    }

    [HttpPost]
    public async Task<IActionResult> Create(ClassInfoVm model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid data");
            }

            var classInfo = new ClassInfo()
            {
                Name = model.Name,
                Description = model.Description,
                CreatedAt = DateTime.UtcNow
            };
            await _context.ClassInfos.AddAsync(classInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
