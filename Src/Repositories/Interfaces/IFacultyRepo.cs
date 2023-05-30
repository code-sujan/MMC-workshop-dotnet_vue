using test.Src.Entity;

namespace test.Repositories.Interfaces;

public interface IFacultyRepo
{
    IQueryable<Faculty> GetQueryable();
    Task<Faculty> FindOrThrowAsync(long id);
}