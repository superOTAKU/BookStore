namespace API.Modules.AttachModule.Domains;

public class ComponentKey
{
    public string Type { get; set; } = null!;
    public string Id { get; set; } = null!;

    public static ComponentKey Create(object type, object id)
    {
        return new ComponentKey
        {
            Type = type.ToString() ?? throw new ArgumentNullException(nameof(type)),
            Id = id.ToString() ?? throw new ArgumentNullException(nameof(id)),
        };
    }
}
