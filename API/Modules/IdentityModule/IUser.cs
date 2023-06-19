namespace API.Modules.IdentityModule;

public interface IUser
{
    string Id { get; }

    string Name { get; }

    string? Email { get; }

    /// <summary>
    /// 是否管理员：管理员有对应的API范围，普通会员有对应的API范围
    /// </summary>
    bool Admin { get; }  

    ISet<IRole> Roles { get; }

}
