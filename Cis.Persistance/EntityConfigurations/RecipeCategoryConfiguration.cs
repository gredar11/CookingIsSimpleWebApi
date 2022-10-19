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
    public class RecipeCategoryConfiguration : IEntityTypeConfiguration<RecipeCategory>
    {
        public void Configure(EntityTypeBuilder<RecipeCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Recipes).WithOne(x => x.RecipeCategory).HasForeignKey(x => x.RecipeCategoryId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
