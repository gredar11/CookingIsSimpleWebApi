using Cis.Domain.Models;
using Cis.Persistance;
using Cis.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<CisDbContext>();
builder.Services.AddPersistance(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<CisDbContext>();
        //context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
    catch (Exception)
    {
        throw;
    }
}

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
//app.MapGet("/", () => "Hello World!");

app.Run();
