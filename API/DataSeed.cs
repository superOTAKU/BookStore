using API.Infrastructures.DataAccesses;
using API.Modules.BookModule.Domains;

namespace API;

public class DataSeed
{
    public static void Seed(IHost host)
    {
        var services = host.Services;
        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
        if (!dbContext.Authors.Any())
        {
            dbContext.Authors.Add(new Author
            {
                Name =  "尾田荣一郎",
                Description = "海贼王作者",
                Nationality = "JPN",
                CreateTime = DateTime.UtcNow,
                UpdateTime = DateTime.UtcNow
            });
        }
        dbContext.SaveChanges();
        Console.WriteLine("Seed Data Finish");
    }
}
