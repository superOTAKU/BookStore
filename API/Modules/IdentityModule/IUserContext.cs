namespace API.Modules.IdentityModule;

public interface IUserContext
{
    IUser CurrentUser { get; }

}
