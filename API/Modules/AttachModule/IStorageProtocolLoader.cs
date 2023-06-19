namespace API.Modules.AttachModule;

public interface IStorageProtocolLoader
{
    IStorageProtocol? Load(string protocolName);

    void Register(string protocolName, Type type);

}
