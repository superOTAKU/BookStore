namespace API.Modules.AclModule;

public interface IAclPolicyManager
{
    void Register(string policyName, Type policyType);

    IAclPolicy? Load(string policyName);

}
