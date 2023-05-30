using System.ComponentModel.DataAnnotations.Schema;

namespace test.Src.Entity;

[Table("faculties")]
public class Faculty
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}