using API.Infrastructures.DataAccesses;
using API.Modules.AclModule;
using API.Modules.AttachModule.StorageProtocols;

namespace API.Modules.AttachModule.Extensions;

public static class AttachServiceCollectionExtension
{

    public static IServiceCollection AddAttachService(this IServiceCollection services)
    {
        services.AddScoped<IAttachRepository, AttachRepository>();
        services.AddSingleton<IStorageProtocolLoader, StorageProtocolLoader>();
        services.AddScoped<IAttachService, AttachService>();
        Console.WriteLine("Attach Service Registered");
        return services;
    }

    public static IServiceCollection AddLocalFileStorageProtocol(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(new LocalFileStorageProtocolConfig
        {
            BaseDir = configuration["LocalFileStorageProtocol:BaseDir"] ?? throw new ArgumentNullException("base dir not set"),
        });
        services.AddTransient<IStorageProtocol, LocalFileStorageProtocol>();
        //注入实现类，避免每次实例化所有的Protocol
        services.AddTransient<LocalFileStorageProtocol>();
        Console.WriteLine("LocalFileStorageProtocol Added");
        return services;
    }

}
