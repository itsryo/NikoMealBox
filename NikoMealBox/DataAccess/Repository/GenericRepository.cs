using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using NikoMealBox.DataAccess.Interface;
using NikoMealBox.Models.DataTable;

namespace NikoMealBox.DataAccess.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public  DbContext Context;

        public DbSet<TEntity> Set => Context.Set<TEntity>();


        public GenericRepository(DbContext context)
        {
            if (this.Context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            Context = context;
        }
        public void Insert(TEntity entities)
        {
            Set.Add(entities);
            entities.CreateTime = DateTime.Now;
            SaveChanges();
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            Set.AddRange(entities);
            SaveChanges();

        }

        public void Update(TEntity entities)
        {
            Context.Entry(entities).State = EntityState.Modified;
            entities.EditTime = DateTime.Now;
            SaveChanges();
        }

        public void Delete(TEntity entities)
        {
            Context.Entry(entities).State = EntityState.Modified;
            entities.IsDelete = true;
            entities.EditTime = DateTime.Now;
            SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Set.AsQueryable();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}