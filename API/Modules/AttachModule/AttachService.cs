using API.Modules.AttachModule.Domains;
using API.Modules.AttachModule.Dtos;
using Microsoft.AspNetCore.StaticFiles;

namespace API.Modules.AttachModule;

public class AttachService : IAttachService
{
    private readonly IStorageProtocolLoader _storageProtocolLoader;
    private readonly IAttachRepository _attachRepository;

    public AttachService(IStorageProtocolLoader storageProtocolLoader, IAttachRepository attachRepository)
    {
        _storageProtocolLoader = storageProtocolLoader;
        _attachRepository = attachRepository;   

    }

    public Attach Put(PutAttachCommand putCommand)
    {   
        var storageProtocol = _storageProtocolLoader.Load(putCommand.StorageProtocol)
            ?? throw new ArgumentNullException(nameof(putCommand.StorageProtocol));
        using var memoryStream = new MemoryStream();
        putCommand.Stream.CopyTo(memoryStream);
        var url = storageProtocol.Save(memoryStream);
        var contentTypeProvider = new FileExtensionContentTypeProvider();
        contentTypeProvider.TryGetContentType(putCommand.Name, out var mimeType);
        var attach = new Attach
        {
            ComponentType = putCommand.ComponentType,
            ComponentId = putCommand.ComponentId,
            Name = putCommand.Name,
            MimeType = mimeType ?? "application/octet-stream",
            StorageProtocol = putCommand.StorageProtocol,
            StorageUrl = url,
            Size = (int)memoryStream.Length,
            ExtensionType = putCommand.Extension?.Type,
            ExtensionObject = putCommand.Extension?.Encode(),
            CreateTime = DateTime.UtcNow,
            IsDeleted = false
        };
        _attachRepository.Add(attach);
        return attach;
    }
}
