using API.Commons.DataAccesses;

namespace API.Infrastructures.DataAccesses;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Commit()
    {
        _appDbContext.SaveChanges();
    }
}
