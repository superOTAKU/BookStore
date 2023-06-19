using API.Modules.AttachModule.Attributes;

namespace API.Modules.AttachModule.StorageProtocols;

public class LocalFileStorageProtocolConfig
{
    public string BaseDir { get; set; } = null!;

}

[StorageProtocol(LocalFileStorageProtocol.Name)]
public class LocalFileStorageProtocol : IStorageProtocol
{
    public const string Name = "LocalFile";

    private readonly LocalFileStorageProtocolConfig _config;

    public LocalFileStorageProtocol(LocalFileStorageProtocolConfig config)
    {
        _config = config;
    }

    public Stream Load(string url)
    {
        return File.OpenRead(url);
    }

    public string Save(Stream stream)
    {
        var fullPath = Path.Combine(_config.BaseDir, Guid.NewGuid().ToString());
        using var fs = File.Create(fullPath);
        stream.CopyTo(fs);
        return fullPath;
    }

}
