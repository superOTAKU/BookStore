using API.Commons.DataAccesses;

namespace API.Infrastructures.DataAccesses;

public abstract class RepositoryBase : IRepository
{
    public RepositoryBase(AppDbContext db, IUnitOfWork unitOfWork)
    {
        Db = db;
        UnitOfWork = unitOfWork;
    }

    protected AppDbContext Db { get; set; }

    public IUnitOfWork UnitOfWork {get; init;}
}
