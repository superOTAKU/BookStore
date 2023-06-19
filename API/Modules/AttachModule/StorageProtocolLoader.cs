namespace API.Modules.AttachModule;

public class StorageProtocolLoader : IStorageProtocolLoader
{
    private readonly Dictionary<string, Type> _storageProtocols = new Dictionary<string, Type>();
    private readonly IServiceProvider _serviceProvider;

    public StorageProtocolLoader(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IStorageProtocol? Load(string protocolName)
    {
        var type = _storageProtocols[protocolName] ?? throw new ArgumentNullException(nameof(protocolName));
        return _serviceProvider.GetService(type) as IStorageProtocol;
    }

    public void Register(string protocolName, Type storageProtocolType)
    {
        _storageProtocols[protocolName] = storageProtocolType;
    }

}
