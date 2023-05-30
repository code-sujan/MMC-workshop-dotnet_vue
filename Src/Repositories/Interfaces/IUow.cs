namespace test.Repositories.Interfaces;

public interface IUow
{
    Task Commit();
}