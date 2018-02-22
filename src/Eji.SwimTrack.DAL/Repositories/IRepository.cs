using Eji.SwimTrack.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Eji.SwimTrack.DAL.Repositories
{
    public interface IRepository<T> where T: EntityBase
    {
        int Count { get; }
        bool HasChanges { get; }
        T Find(int? id);
        T GetFirst();
        Task<T> GetFirstAsync();
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetRange(int skip, int take);
        int Add(T entity, bool persist = true);
        Task<int> AddAsync(T entity, bool persist = true);
        int AddRange(IEnumerable<T> entities, bool persist = true);
        Task<int> AddRangeAsync(IEnumerable<T> entities, bool persist = true);
        int Update(T entity, bool persist = true);
        int UpdateRange(IEnumerable<T> entities, bool persist = true);
        int Delete(T entity, bool persist = true);
        int DeleteRange(IEnumerable<T> entities, bool persist = true);
        int Delete(int id, byte[] timeStamp, bool persist = true);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
