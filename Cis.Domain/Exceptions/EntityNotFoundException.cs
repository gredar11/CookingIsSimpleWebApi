using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Domain.Exceptions
{
    public class EntityNotFoundException<T> : NotFoundException
    {
        public EntityNotFoundException(int id) : base($"Object with type {typeof(T).Name} and id {id} is not in database")
        {
        }
    }
}
