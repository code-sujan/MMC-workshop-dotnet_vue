using test.Src.Entity;

namespace test.Repositories.Interfaces;

public interface IStudentRepo
{
    IQueryable<Student> GetQueryable();
    Task<Student> FindOrThrowAsync(long id);
    Task AddAsync(Student student);
}