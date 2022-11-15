using Domain.Models;
using Persistance;
using WebApi.ActionFilters;
using WebApi.Extensions;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NLog;
using Persistance;

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
builder.Services.ConfigureSwagger();

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerManager>();

app.UseCustomExceptionHandler(logger);

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<CisDbContext>();
        context.Database.Migrate();
        //context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
    catch (Exception)
    {
        throw;
    }
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Cooking is simple Web API");
});
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();

NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
    new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
    .Services.BuildServiceProvider()
    .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
    .OfType<NewtonsoftJsonPatchInputFormatter>().First();