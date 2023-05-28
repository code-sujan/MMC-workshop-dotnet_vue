using System.ComponentModel.DataAnnotations.Schema;

namespace test.Src.Entity;

[Table("campus_list")]
public class Campus
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}