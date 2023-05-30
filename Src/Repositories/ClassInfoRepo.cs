﻿using Microsoft.EntityFrameworkCore;
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
        var entity = await GetQueryable().FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) throw new Exception($"Invalid id {id} provided");
        return entity;
    }
}