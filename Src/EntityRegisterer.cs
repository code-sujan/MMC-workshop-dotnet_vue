using Microsoft.EntityFrameworkCore;
using test.Entity;

namespace test;

public static class EntityRegisterer
{
    public static ModelBuilder RegisterEntity(this ModelBuilder builder)
    {
        // builder.Entity<Student>();
        return builder;
    }
}