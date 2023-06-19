using API.Commons.DataAccesses;
using API.Modules.AttachModule;
using API.Modules.AttachModule.Domains;

namespace API.Infrastructures.DataAccesses;

public class AttachRepository : RepositoryBase, IAttachRepository
{
    public AttachRepository(AppDbContext db, IUnitOfWork unitOfWork) : base(db, unitOfWork)
    {
    }

    public void Add(Attach attach)
    {
        Db.Attaches.Add(attach);
    }

    public Attach? GetById(int id)
    {
        return Db.Attaches.Where(e => e.Id == id).FirstOrDefault();
    }
}
