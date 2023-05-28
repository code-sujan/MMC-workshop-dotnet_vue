using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.DataContext;
using test.Models;
using test.Repositories.Interfaces;
using test.Src.Entity;

namespace test.Controllers;

public class ClassInfoController : Controller
{
    private readonly AppDbContext _context;
    private readonly IClassInfoRepo _classInfoRepo;
    public ClassInfoController(AppDbContext context, IClassInfoRepo classInfoRepo)
    {
        _context = context;
        _classInfoRepo = classInfoRepo;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var list = await _context.ClassInfos.OrderBy(x => x.Id).ToListAsync();
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

    [HttpGet]
    public async Task<IActionResult> Update(long id)
    {
        try
        {
            var info = await _classInfoRepo.FindOrThrowAsync(id);
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
            var info = await _classInfoRepo.FindOrThrowAsync(id);
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

    [HttpGet]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            var info = await _classInfoRepo.FindOrThrowAsync(id);
            _context.ClassInfos.Remove(info);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
