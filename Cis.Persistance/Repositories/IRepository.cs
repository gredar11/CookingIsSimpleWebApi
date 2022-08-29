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
        T GetEntity(int id);
        List<T> GetAllEntities();
        void RemoveEntity(int id);
        void UpdateEntity(T post);
        void AddEntity(T post);
        Task<bool> SaveChangesAsync();
    }
}
