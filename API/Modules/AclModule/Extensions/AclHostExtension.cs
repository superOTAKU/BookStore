using API.Modules.AclModule.Attributes;

namespace API.Modules.AclModule.Extensions;

public static class AclHostExtension
{

    public static void AddAclPolicies(this IHost host)
    {
        var policyManager = host.Services.GetRequiredService<IAclPolicyManager>();
        // 扫描所有的Policy，注册到PolicyManager
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            var policyTypes = assembly.GetTypes()
                .Where(t => t.IsDefined(typeof(AclPolicyAttribute), false));
            foreach (var type in policyTypes)
            {
                var attribute = Attribute
                    .GetCustomAttribute(type, typeof(AclPolicyAttribute)) as AclPolicyAttribute;
                policyManager.Register(attribute!.Name, type);
            }
        }
        Console.WriteLine("Acl Policies Loaded");
    }

}
