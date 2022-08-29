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
        public CisDbContext(DbContextOptions<CisDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
        }
    }
}
