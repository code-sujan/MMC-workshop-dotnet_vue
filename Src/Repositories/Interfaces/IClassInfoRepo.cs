using test.Src.Entity;

namespace test.Repositories.Interfaces;

public interface IClassInfoRepo
{
    IQueryable<ClassInfo> GetQueryable();
    Task<ClassInfo> FindOrThrowAsync(long id);
}