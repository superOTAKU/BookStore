using API;
using API.Commons.DataAccesses;
using API.Infrastructures.DataAccesses;
using API.Infrastructures.MediatRConfigurations.Behaviors;
using API.Modules.AclModule.Extensions;
using API.Modules.AttachModule.Extensions;
using API.Modules.BookModule;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//配置依赖注入容器...

//注入DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("BookStore");
});
//注入工作单元
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//repositories
builder.Services.AddScoped<IBookRepository, BookRepository>();
//注入Acl控制相关组件
builder.Services.AddAclService();
//注入附件服务相关组件
builder.Services.AddAttachService();
//注册本地文件存储协议
builder.Services.AddLocalFileStorageProtocol(builder.Configuration);
//CQRS支持
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
})
    .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
    .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateRequestBehavior<,>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//扫描注册相关组件
app.AddAclPolicies();
app.RegisterStorageProtocols();

app.UseAuthorization();

app.MapControllers();

DataSeed.Seed(app);

app.Run();
