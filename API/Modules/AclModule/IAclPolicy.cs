using API.Modules.AclModule.Domains;

namespace API.Modules.AclModule;

public interface IAclPolicy
{

    bool AccessControl(AclRecord aclRecord);

    IAclPolicyContextCodec Codec { get; }

}
