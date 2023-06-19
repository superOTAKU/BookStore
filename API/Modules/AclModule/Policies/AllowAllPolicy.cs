using API.Modules.AclModule.Attributes;
using API.Modules.AclModule.Domains;
using API.Modules.AclModule.PolicyContextCodecs;

namespace API.Modules.AclModule.Policies;

[AclPolicy("AllowAll")]
public class AllowAllPolicy : IAclPolicy
{
    public const string Name = "AllowAll";

    public IAclPolicyContextCodec Codec => new NoopCodec();

    public bool AccessControl(AclRecord aclRecord)
    {
        Console.WriteLine("AllowAllPolicy Pass!!!");
        return true;
    }

}
