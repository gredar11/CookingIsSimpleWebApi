using Cis.Domain.Models;
using Cis.Persistance.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Persistance
{
    public class CisDbContext:DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public CisDbContext(DbContextOptions<CisDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.Entity<Ingredient>().HasOne(x => x.Category).WithMany(x => x.Ingredients).HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 4,
                    IngredientName = "Pumpkin",
                    IngredientDescription = "Orange"
                },
                new Ingredient
                {
                    Id = 5,
                    IngredientName = "Pickle",
                    IngredientDescription = "Salty and green"
                }, new Ingredient
                {
                    Id = 6,
                    IngredientName = "Carrot",
                    IngredientDescription = "Bugs Bunny likes it."
                });
        }
    }
}
