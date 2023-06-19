using API.Commons.Domains;

namespace API.Modules.AttachModule.Domains;

public class Attach : IHasCreateTime, ISoftDeleted
{
    public int Id { get; set; }

    public string ComponentType { get; set; } = null!;

    public string ComponentId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string MimeType { get; set; } = null!;

    public int Size { get; set; }

    /// <summary>
    /// 存储协议，扩展点1
    /// </summary>
    public string StorageProtocol { get; set; } = null!;

    public string StorageUrl { get; set; } = null!;

    /// <summary>
    /// 额外信息，扩展点2
    /// </summary>

    public string? ExtensionType { get; set; }

    public string? ExtensionObject { get; set; }

    public DateTime CreateTime { get; set; }
    public bool IsDeleted { get; set; }
}
