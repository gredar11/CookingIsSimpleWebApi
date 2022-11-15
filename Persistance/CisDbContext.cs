using Domain.Models;
using Persistance.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class CisDbContext:DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<AmountOfIngredient> AmountOfIngredients { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public CisDbContext(DbContextOptions<CisDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RecipeCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new FoodCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AmountOfIngredientConfiguration());
            modelBuilder.Entity<Ingredient>().HasOne(x => x.Category).WithMany(x => x.Ingredients).HasForeignKey(x => x.CategoryId);
        }
    }
}
