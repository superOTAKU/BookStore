using API.Commons.DataAccesses;
using API.Modules.AclModule.Domains;
using API.Modules.AclModule.Dtos;

namespace API.Modules.AclModule;

public interface IAclRecordRepository : IRepository
{
    IEnumerable<AclRecord> GetRecords(string entityType, string entityId);

    void AddRecord(AclRecord aclRecord);

}
