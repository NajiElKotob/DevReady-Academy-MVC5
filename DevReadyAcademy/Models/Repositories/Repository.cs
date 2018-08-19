using DevReadyAcademy.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Caching;
using System.Web;

namespace DevReadyAcademy.Models.Repositories
{   
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

    
        public Repository(DbContext context)
        {
            Context = context;
        }

        /*
        public void RefreshCache()
        {
            MemoryCache memoryCache = MemoryCache.Default;
            memoryCache.Remove(typeof(TEntity).Name);
        }

        public IEnumerable<TEntity> GetAll(bool fromCache)
        {
            MemoryCache memoryCache = MemoryCache.Default;

            if (fromCache == true)
            {
                var cachedData = (List<TEntity>)memoryCache[typeof(TEntity).Name];
                if (cachedData == null)
                {
                    memoryCache[typeof(TEntity).Name] = Context.Set<TEntity>().ToList();
                }
            }
            else
            {
                return GetAll();
            }


            return (List<TEntity>)memoryCache[typeof(TEntity).Name];
        }
        */

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }




        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }


        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
           
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
           
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
           
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
           
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                Update(item);
            }
           
        }

        public bool IsExist(int id)
        {
            return Context.Set<TEntity>().Find(id) != null;
        }
    }
}