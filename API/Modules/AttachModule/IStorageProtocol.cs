namespace API.Modules.AttachModule;

public interface IStorageProtocol
{

    string Save(Stream stream);

    Stream Load(string url);

}
