using Cis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IIngreditentRepository
    {
        Task<IEnumerable<Ingredient>> GetIngredients(int categoryId, bool trackChanges);
        Task<Ingredient> GetIngredientById(int categoryId, int id, bool trackChanges);
        void DeleteIngredientById(Ingredient ingredient);
        void CreateIngredient(int categoryId, Ingredient ingredient);

    }
}
