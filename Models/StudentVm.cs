using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using test.Src.Entity;

namespace test.Models;

public class StudentVm
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactNo { get; set; }
    [Display(Name = "Class")]
    public long ClassInfoId { get; set; }
    [Display(Name = "Faculty")]
    public long FacultyId { get; set; }

    public List<ClassInfo> ClassInfos { get; set; } = new List<ClassInfo>();
    public SelectList ClassOptions => 
        new SelectList(ClassInfos, nameof(ClassInfo.Id), nameof(ClassInfo.Name));

    public List<Faculty> Faculties { get; set; } = new List<Faculty>();
    public SelectList FacultyOptions => 
        new SelectList(Faculties, "Id", "Name");
}