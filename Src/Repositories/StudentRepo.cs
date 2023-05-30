using Microsoft.EntityFrameworkCore;
using test.DataContext;
using test.Repositories.Interfaces;
using test.Src.Entity;

namespace test.Repositories;

public class StudentRepo : IStudentRepo
{
    private readonly AppDbContext _context;

    public StudentRepo(AppDbContext context)
    {
        _context = context;
    }


    public IQueryable<Student> GetQueryable()
    {
        return _context.Set<Student>();
    }

    public async Task<Student> FindOrThrowAsync(long id)
    {
        var entity = await GetQueryable().FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) throw new Exception($"Invalid id {id} provided");
        return entity;
    }

    public async Task AddAsync(Student student)
    {
        await _context.Set<Student>().AddAsync(student);
    }
    
}