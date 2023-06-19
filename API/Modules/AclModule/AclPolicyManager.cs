using System.Collections.Concurrent;
using System.Reflection;

namespace API.Modules.AclModule;

public class AclPolicyManager : IAclPolicyManager
{
    private readonly Dictionary<string, Type> _policyTypeDict = new Dictionary<string, Type>();
    private readonly IServiceProvider _serviceProvider;

    public AclPolicyManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IAclPolicy? Load(string policyName)
    {
        var type = _policyTypeDict[policyName];
        if (type == null)
        {
            return null;
        }
        //从IOC容器获取transient对象
        return _serviceProvider.GetRequiredService(type) as IAclPolicy;
    }

    public void Register(string policyName, Type policyType)
    {
        _policyTypeDict[policyName] = policyType;
    }
}
