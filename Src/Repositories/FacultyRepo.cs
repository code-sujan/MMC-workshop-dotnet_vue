using Microsoft.EntityFrameworkCore;
using test.DataContext;
using test.Repositories.Interfaces;
using test.Src.Entity;

namespace test.Repositories;

public class FacultyRepo : IFacultyRepo
{
    private readonly AppDbContext _context;

    public FacultyRepo(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<Faculty> GetQueryable()
    {
        return _context.Set<Faculty>();
    }

    public async Task<Faculty> FindOrThrowAsync(long id)
    {
        var entity = await GetQueryable().FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) throw new Exception($"Invalid id {id} provided");
        return entity;
    }
}