using Microsoft.EntityFrameworkCore;
using test.DataContext;
using test.Repositories.Interfaces;
using test.Src.Entity;

namespace test.Repositories;

public class ClassInfoRepo : IClassInfoRepo
{
    private readonly AppDbContext _context;

    public ClassInfoRepo(AppDbContext context)
    {
        _context = context;
    }
    
    public IQueryable<ClassInfo> GetQueryable()
    {
        return _context.ClassInfos;
    }

    public async Task<ClassInfo> FindOrThrowAsync(long id)
    {
        var info = await GetQueryable().FirstOrDefaultAsync(x => x.Id == id);
        if (info == null) throw new Exception($"Class info with id {id} not found");
        return info;
    }
}