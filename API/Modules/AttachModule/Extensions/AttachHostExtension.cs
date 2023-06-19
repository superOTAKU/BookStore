using API.Modules.AttachModule.Attributes;

namespace API.Modules.AttachModule.Extensions;

public static class AttachHostExtension
{
    public static void RegisterStorageProtocols(this IHost host)
    {
        var storageProtocolLoader = host.Services.GetService<IStorageProtocolLoader>()
            ?? throw new ArgumentNullException("storage loader not found");
        var storageProtocols = host.Services.GetServices<IStorageProtocol>();
        foreach(var protocol in storageProtocols)
        {
            var type = protocol.GetType();
            var attribute = Attribute.GetCustomAttribute(type, typeof(StorageProtocolAttribute)) 
                as StorageProtocolAttribute ?? throw new ArgumentNullException(nameof(protocol));
            storageProtocolLoader.Register(attribute.Name, protocol.GetType());
        }
        Console.WriteLine("Storage Protocols is Registered!!!");
    }
}
