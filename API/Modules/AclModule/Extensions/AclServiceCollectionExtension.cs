using API.Infrastructures.DataAccesses;

namespace API.Modules.AclModule.Extensions;

/// <summary>
/// 添加扩展，以注册Acl服务
/// </summary>
public static class AclServiceCollectionExtension
{
    public static IServiceCollection AddAclService(this IServiceCollection services)
    {
        services.AddScoped<IAclRecordRepository, AclRecordRepository>();
        services.AddSingleton<IAclPolicyManager, AclPolicyManager>();
        services.AddScoped<IAclService, AclService>();
        services.Scan(scan =>
        {
            scan.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(classes => classes.AssignableTo<IAclPolicy>())
                .AsImplementedInterfaces()
                .AsSelf()
                .WithTransientLifetime();
        });
        Console.WriteLine("Acl Service Registered");
        return services;
    }
}
