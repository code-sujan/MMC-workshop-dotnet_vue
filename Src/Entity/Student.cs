using System.ComponentModel.DataAnnotations.Schema;

namespace test.Src.Entity;

[Table("students")]
public class Student
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactNo { get; set; }
    
    public ClassInfo ClassInfo { get; set; }
    public long ClassInfoId { get; set; }
    
    public Faculty Faculty { get; set; }
    public long FacultyId { get; set; }
}