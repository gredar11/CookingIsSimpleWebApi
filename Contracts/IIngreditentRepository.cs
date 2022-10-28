using Cis.Domain.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IIngreditentRepository
    {
        void CreateIngredient(int categoryId, Ingredient ingredient);
        Task<IEnumerable<Ingredient>> GetCollectionByIds(int categoryId, IEnumerable<int> ids, bool trackChanges);
        Task<PagedList<Ingredient>> GetIngredients(int categoryId, IngredientParameters ingredientParameters, bool trackChanges);
        Task<Ingredient> GetIngredientById(int categoryId, int id, bool trackChanges);
        void UpdateIngredient(Ingredient ingredient);
        void DeleteIngredientById(Ingredient ingredient);
        Task<IEnumerable<AmountOfIngredient>> GetIngredientsOfReceip(int receipId, bool trackChanges);
    }
}
