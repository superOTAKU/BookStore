namespace API.Modules.AttachModule.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class StorageProtocolAttribute : Attribute
{
    public StorageProtocolAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }

}
