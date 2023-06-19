namespace API.Modules.IdentityModule;

public interface IRole
{
    string Name { get; }

    ISet<string> Permissions { get; }

}
