using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DAL
{
    public class UserRepository<T> : IRepository<T> where T :class
    {
        private UsageContext Context;
        private DbSet<T> DbSet;
        public UserRepository(UsageContext Context)
        {
            this.Context = Context;
            if (!Context.Database.Exists())
                Context.Database.Create();
            DbSet = Context.Set<T>();
        }

        public void Clear()
        {
            DbSet.RemoveRange(DbSet);
            Context.SaveChanges();

        }
        public void Delete(int Id)
        {
            DbSet.Remove(DbSet.Find(Id));
            Context.SaveChanges();
        }
        public void Delete(T Item)
        {
            Context.Entry(Item).State = EntityState.Deleted;
            Context.SaveChanges();
        }
        public void Add(T Item)
        {
            DbSet.Add(Item);
            Context.SaveChanges();
        }
        public void Modify(T Item)
        {
            Context.Entry(Item).State = EntityState.Modified;
            Context.SaveChanges();
        }
        public void Modify(int Id, T Item)
        {
            Context.Entry(Item).State = EntityState.Modified;
            Context.SaveChanges();
        }
        public T Get(int Id)
        {
            return DbSet.Find(Id);
        }

        public T GetByPosition(int Position)
        {
            return DbSet.ToList()[Position];
        }

        public List<T> GetAll()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public List<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbSet;
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
