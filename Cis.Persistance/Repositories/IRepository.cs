using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Persistance.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetEntity(int id);
        Task<List<T>> GetAllEntities();
        Task RemoveEntity(int id);
        Task UpdateEntity(T post);
        Task<int> AddEntity(T post);
        Task<int> SaveChangesAsync();
    }
}
