using Cis.Domain.Models;
using Cis.Persistance;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<CisDbContext>();
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddMvc();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<CisDbContext>();
        //context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        context.Ingredients.Add(new Ingredient()
        {
            Id = 1,
            IngredientName = "Pepper",
            IngredientDescription = "Red vegetable. Spicy."
        });
        context.Ingredients.Add(new Ingredient()
        {
            Id = 2,
            IngredientName = "Tomato",
            IngredientDescription = "Red vegetable. Not spicy."
        });
        context.Ingredients.Add(new Ingredient()
        {
            Id = 3,
            IngredientName = "Potato",
            IngredientDescription = "Grows under the ground."
        });
        context.SaveChanges();
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
