using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class IngredientCollectionBadRequest:BadRequestException
    {
        public IngredientCollectionBadRequest():base("Ingredients collection sent from a client is null")
        {

        }
    }
}
