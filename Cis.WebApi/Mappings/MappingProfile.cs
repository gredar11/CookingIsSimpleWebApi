using AutoMapper;
using Cis.Domain.Models;
using Shared;
using Shared.CreationDto;
using Shared.GetResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.WebApi.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RecipeCategoryCreationDto, RecipeCategory>();
            CreateMap<RecipeCategory, RecipeCategoryDto>();
            CreateMap<FoodCategory, FoodCategoryDto>();
            CreateMap<FoodCategoryForCreationDto, FoodCategory>();
            CreateMap<FoodCategoryForUpdateDto, FoodCategory>();
            CreateMap<IngredientForCreationDto, Ingredient>();
            CreateMap<Ingredient, IngredientDto>();
        }
    }
}
