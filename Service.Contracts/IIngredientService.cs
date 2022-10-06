﻿using Cis.Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientDto>> GetIngredientsByFoodCategory(int foodCategoryId, bool trackChanges);
        Task<IngredientDto> GetIngredientByCategory(int categoryId, int ingredientId, bool trackChanges);
        Task DeleteIngredient(int categoryId, int ingredientId, bool trackChanges);
        Task<IngredientDto> CreateIngredientForCategory(int categoryId, IngredientForCreationDto forCreationDto, bool trackChanges);
        Task UpgradeIngredientForCategory(int categoryId, int ingredientId, IngredientForUpdateDto updateDto, bool trackChanges);


    }
}
