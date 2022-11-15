using Cis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Persistance.EntityConfigurations
{
    public class AmountOfIngredientConfiguration : IEntityTypeConfiguration<AmountOfIngredient>
    {
        public void Configure(EntityTypeBuilder<AmountOfIngredient> builder)
        {
            builder.HasKey(x => new { x.RecipeId, x.IngredientId });
            builder.HasOne(x => x.Recipe).WithMany(x => x.Ingredients).HasForeignKey(x => x.RecipeId);
            builder.HasOne(x => x.Ingredient).WithMany(x => x.Recipes).HasForeignKey(x => x.IngredientId);
            builder.HasCheckConstraint("Amount", "Amount >= 0.0 and Amount <= 10000.0");

        }
    }
}
