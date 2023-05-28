using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.DataContext;
using test.Helpers;
using test.Models;
using test.Src.Entity;

namespace test.Controllers;

public class FacultyController : Controller
{
    private readonly AppDbContext _context;

    public FacultyController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _context.Faculties.OrderBy(x => x.Id).ToListAsync();
        return View(list);
    }

    public async Task<IActionResult> Create()
    {
        return View(new FacultyVm());
    }

    [HttpPost]
    public async Task<IActionResult> Create(IFormFile image, FacultyVm model)
    {
        try
        {
            var fileName = await FileHelper.RecordFile(image);
            var faculty = new Faculty()
            {
                Name = model.Name,
                Description = model.Description
            };
            await _context.Faculties.AddAsync(faculty);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}