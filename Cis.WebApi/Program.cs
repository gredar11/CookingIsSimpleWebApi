using Cis.Domain.Models;
using Cis.Persistance;
using Cis.WebApi.ActionFilters;
using Cis.WebApi.Extensions;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddPersistance(builder.Configuration);
//builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddControllers(config => 
        { 
            config.RespectBrowserAcceptHeader = true; 
            config.ReturnHttpNotAcceptable = true;
            config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
        })
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddScoped<ValidationFilterArrtibute>();

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerManager>();

app.UseCustomExceptionHandler(logger);

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


NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
    new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
    .Services.BuildServiceProvider()
    .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
    .OfType<NewtonsoftJsonPatchInputFormatter>().First();