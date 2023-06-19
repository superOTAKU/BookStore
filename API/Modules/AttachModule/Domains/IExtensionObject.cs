namespace API.Modules.AttachModule.Domains
{
    public interface IExtensionObject
    {
        string Type { get; }

        string Encode();
    }
}
