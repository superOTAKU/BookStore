using API.Commons.DataAccesses;
using API.Modules.AclModule;
using API.Modules.AclModule.Domains;

namespace API.Infrastructures.DataAccesses;

public class AclRecordRepository : RepositoryBase, IAclRecordRepository
{
    public AclRecordRepository(AppDbContext db, IUnitOfWork unitOfWork) : base(db, unitOfWork)
    {
    }

    public void AddRecord(AclRecord aclRecord)
    {
        Db.Add(aclRecord);
    }

    public IEnumerable<AclRecord> GetRecords(string entityType, string entityId)
    {
        return Db.AclRecords.Where(e => e.EntityType == entityType && e.EntityId == entityId);
    }
}
