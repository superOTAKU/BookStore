namespace API.Modules.AclModule.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class AclPolicyAttribute : Attribute
{
    public AclPolicyAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
