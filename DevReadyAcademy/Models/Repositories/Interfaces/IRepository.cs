using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DevReadyAcademy.Models.Repositories.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {

        //void RefreshCache();

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();
        //IEnumerable<TEntity> GetAll(bool fromCache);
        TEntity Get(int id);

        //Find
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        //Add
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //Update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        //Remove
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        bool IsExist(int id);

    }
}
