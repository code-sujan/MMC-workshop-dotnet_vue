using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.DataContext;
using test.Entity;
using test.Models;

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
        var list = await _context.ClassInfos.OrderBy(x => x.Id).ToListAsync();
        return View(list);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View(new ClassInfoVm());
    }

    [HttpPost]
    public async Task<IActionResult> Create(ClassInfoVm model)
    {
        try
        {
            var info = new ClassInfo
            {
                Name = model.Name,
                Description = model.Description,
                CreatedAt = DateTime.UtcNow
            };
            await _context.ClassInfos.AddAsync(info);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Update(long id)
    {
        try
        {
            var info = await _context.ClassInfos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (info == null) throw new Exception($"Class info with id {id} not found");
            var model = new ClassInfoVm()
            {
                Name = info.Name,
                Description = info.Description
            };
            return View(model);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Update(long id, ClassInfoVm model)
    {
        try
        {
            var info = await _context.ClassInfos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (info == null) throw new Exception($"Class info with id {id} not found");
            info.Name = model.Name;
            info.Description = model.Description;
            _context.ClassInfos.Update(info);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
}