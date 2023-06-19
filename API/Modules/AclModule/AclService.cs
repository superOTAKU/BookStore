using API.Modules.AclModule.Domains;
using API.Modules.AclModule.Dtos;

namespace API.Modules.AclModule;

public class AclService : IAclService
{
    private readonly IAclRecordRepository _aclRecordRepository;
    private readonly IAclPolicyManager _aclPolicyManager;

    public AclService(IAclRecordRepository aclRecordRepository, IAclPolicyManager aclPolicyManager)
    {
        _aclRecordRepository = aclRecordRepository;
        _aclPolicyManager = aclPolicyManager;
    }

    public bool AccessControl(string entityType, string entityId)
    {
        var records = _aclRecordRepository.GetRecords(entityType, entityId);
        if (records.Count() == 0)
        {
            return false;
        }
        return records.Any(record =>
        {
            var policy = _aclPolicyManager.Load(record.Policy) 
                ?? throw new ArgumentNullException($"policy {record.Policy} not found");
            return policy.AccessControl(record);
        });
    }

    public AclRecord AddAclRecord(AddAclRecordCommand command)
    {
        var policy = _aclPolicyManager.Load(command.Policy) 
            ?? throw new ArgumentNullException(nameof(command.Policy));
        AclRecord aclRecord = new AclRecord
        {
            EntityType = command.EntityType,
            EntityId = command.EntityId,
            Policy = command.Policy,
            PolicyContext = policy.Codec.Encode(command.PolicyContext),
            CreateTime = DateTime.UtcNow
        };
        _aclRecordRepository.AddRecord(aclRecord);
        // Service层不调用SaveChanges!!!使用UnitOfWork模式，每个UseCase作为一个工作单元
        return aclRecord;
    }

}
