using API.Modules.AttachModule.Domains;

namespace API.Modules.AttachModule.Dtos;

public class PutAttachCommand
{
    public string ComponentType { get; set; } = null!;

    public string ComponentId { get; set; } = null!;

    public string Name { get; set; } = null!;

    //AttachService不负责Dispose，请外部请求方负责
    public Stream Stream { get; set; } = null!;

    public string StorageProtocol { get; set; } = null!;

    public IExtensionObject? Extension { get; set; }

}
