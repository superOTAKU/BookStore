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


//��������ע������...

//ע��DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("BookStore");
});
//ע�빤����Ԫ
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//repositories
builder.Services.AddScoped<IBookRepository, BookRepository>();
//ע��Acl����������
builder.Services.AddAclService();
//ע�븽������������
builder.Services.AddAttachService();
//ע�᱾���ļ��洢Э��
builder.Services.AddLocalFileStorageProtocol(builder.Configuration);
//CQRS֧��
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

//ɨ��ע��������
app.AddAclPolicies();
app.RegisterStorageProtocols();

app.UseAuthorization();

app.MapControllers();

DataSeed.Seed(app);

app.Run();
