using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Domain.Exceptions
{
    public class IngredientNotFoundException:NotFoundException
    {
        public IngredientNotFoundException(int id):base($"Ingredient with id = {id} not found in database")
        {

        }
    }
}
