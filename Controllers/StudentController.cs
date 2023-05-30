using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Models;
using test.Repositories.Interfaces;
using test.Src.Entity;

namespace test.Controllers;

public class StudentController : Controller
{
    private readonly IClassInfoRepo _classInfoRepo;
    private readonly IStudentRepo _studentRepo;
    private readonly IFacultyRepo _facultyRepo;
    private readonly IUow _uow;
    

    public StudentController(IClassInfoRepo classInfoRepo, IStudentRepo studentRepo, IFacultyRepo facultyRepo, IUow uow)
    {
        _classInfoRepo = classInfoRepo;
        _studentRepo = studentRepo;
        _facultyRepo = facultyRepo;
        _uow = uow;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _studentRepo.GetQueryable()
            .Include(x => x.ClassInfo)
            .Include(x => x.Faculty)
            .OrderBy(x => x.Id).ToListAsync();
        return View(list);
    }
    
    public async Task<IActionResult> New()
    {
        var model = new StudentVm()
        {
            ClassInfos = await _classInfoRepo.GetQueryable().ToListAsync(),
            Faculties = await _facultyRepo.GetQueryable().ToListAsync()
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> New(StudentVm model)
    {
        try
        {
            var student = new Student()
            {
                Name = model.Name,
                Address = model.Address,
                ContactNo = model.ContactNo,
                ClassInfo = await _classInfoRepo.FindOrThrowAsync(model.ClassInfoId),
                Faculty = await _facultyRepo.FindOrThrowAsync(model.FacultyId)
            };
            await _studentRepo.AddAsync(student);
            await _uow.Commit();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}