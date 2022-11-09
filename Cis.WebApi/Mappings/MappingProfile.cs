using AutoMapper;
using Cis.Domain.Models;
using Shared;
using Shared.CreationDto;
using Shared.GetResponseDto;
using Shared.UpdatingDto;
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
            CreateMap<AmountOfIngredient, AmountOfIngredientDto>().ReverseMap();
            CreateMap<RecipeIngredientAddingDto, AmountOfIngredient>();
            CreateMap<Recipe, RecipeDto>().ReverseMap();
            CreateMap<RecipeCreationDto, Recipe>();
            CreateMap<FoodCategory, FoodCategoryDto>();
            CreateMap<FoodCategoryForCreationDto, FoodCategory>();
            CreateMap<FoodCategoryForUpdateDto, FoodCategory>().ReverseMap();
            CreateMap<IngredientForCreationDto, Ingredient>();
            CreateMap<RecipeCategoryUpdateDto, RecipeCategory>();
            CreateMap<IngredientForUpdateDto, Ingredient>().ReverseMap();
            CreateMap<AmountOfIngredientToAddIntoRecipeDto, AmountOfIngredient>();
            var ingredientMap = CreateMap<Ingredient, IngredientDto>();
            ingredientMap.ForMember(dest => dest.FoodCategoryName, opt => opt.MapFrom(src => src.Category.NameOfCategory));
            //ingredientMap.ReverseMap();
        }
    }
}
