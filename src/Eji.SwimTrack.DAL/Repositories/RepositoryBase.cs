using Eji.SwimTrack.DAL.EntityFramework;
using Eji.SwimTrack.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eji.SwimTrack.DAL.Repositories
{
    /// <summary>
    /// Base class for all repositories, provides core CRUD
    /// </summary>
    public abstract class RepositoryBase<T> : IDisposable, IRepository<T> where T : EntityBase, new ()
    {
        protected readonly SwimTrackContext Db;
        protected DbSet<T> Table;
        bool disposed = false;

		public SwimTrackContext Context => Db;

        public int Count => Table.Count();

        public bool HasChanges => Db.ChangeTracker.HasChanges();

        protected RepositoryBase()
        {
            Db = new SwimTrackContext();
            Table = Db.Set<T>();
        }

        protected RepositoryBase(DbContextOptions<SwimTrackContext> options) 
        {
            Db = new SwimTrackContext(options);
            Table = Db.Set<T>();
        }

		public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {

            }

            Db.Dispose();
            disposed = true;
        }

        public T Find(int? id)
        {
            return Table.Find(id);
        }

        public Task<T> FindAsync(int? id)
        {
            return Table.FindAsync(id);
        }

        public T GetFirst()
        {
            return Table.FirstOrDefault();
        }

        public Task<T> GetFirstAsync()
        {
            return Table.FirstOrDefaultAsync();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Table;
        }

        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return Task<IEnumerable<T>>.Run(() => GetAll());
        }

        internal IEnumerable<T> GetRange(IQueryable<T> query, int skip, int take)
        {
            return query.Skip(skip).Take(take);
        }

        public virtual IEnumerable<T> GetRange(int skip, int take)
        {
            return GetRange(Table, skip, take);
        }

        public virtual int Add(T entity, bool persist = true)
        {
            Table.Add(entity);
            return persist ? SaveChanges() : 0;
        }

        public virtual async Task<int> AddAsync(T entity, bool persist = true)
        {
            await Table.AddAsync(entity);

            return persist ? await SaveChangesAsync() : 0;
        }

        public int AddRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.AddRange(entities);
            return persist ? SaveChanges() : 0;
        }

        public async Task<int> AddRangeAsync(IEnumerable<T> entities, bool persist = true)
        {
            await Table.AddRangeAsync(entities);

            return persist ? await SaveChangesAsync() : 0;
        }

        public virtual int Update(T entity, bool persist = true)
        {
            Table.Update(entity);
            return persist ? SaveChanges() : 0;
        }

        public int UpdateRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.UpdateRange(entities);
            return persist ? SaveChanges() : 0;
        }

        public int Delete(T entity, bool persist = true)
        {
			EntityEntry entry = Db.Entry(entity);
			if (entry.State == EntityState.Detached)
			{
				entry.State = EntityState.Deleted;
			}
            Table.Remove(entity);
            return persist ? SaveChanges() : 0;
        }

        public int DeleteRange(IEnumerable<T> entities, bool persist = true)
        {
            Table.RemoveRange(entities);
            return persist ? SaveChanges() : 0;
        }

        public int Delete(int id, byte[] timeStamp, bool persist = true)
        {
            T entry = GetEntryFromChangeTracker(id);
            if (entry != null)
            {
                if (entry.Timestamp == timeStamp)
                {
                    return Delete(entry, persist);
                }

                throw new Exception("Unable to delete due to concurrency violation");
            }

            Db.Entry(new T { Id = id, Timestamp = timeStamp }).State = EntityState.Deleted;
            return persist ? SaveChanges() : 0;
        }

        public Task<int> SaveChangesAsync()
        {
            try
            {
                return Db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (RetryLimitExceededException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public int SaveChanges()
        {
            try
            {
                return Db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (RetryLimitExceededException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        internal T GetEntryFromChangeTracker(int? id)
        {
            return Db.ChangeTracker.Entries<T>().Select((EntityEntry e) => (T)e.Entity).FirstOrDefault(x => x.Id == id);
        }
    }
}
