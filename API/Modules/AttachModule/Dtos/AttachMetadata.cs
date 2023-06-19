namespace API.Modules.AttachModule.Dtos;

public class AttachMetadata
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string MimeType { get; set; } = null!;

    public int Size { get; set; }

    public object? ExtensionObject { get; set; }

}
