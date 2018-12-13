using Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Delete(TEntity entity);
        void DeleteAtRange(IEnumerable<TEntity> entity);
        TEntity Insert(TEntity entity);
        void AddRange(IEnumerable<TEntity> entity);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllWhere(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        TEntity SingelOrDafault(Expression<Func<TEntity, bool>> expression);
        TEntity FindByID(int Id);
        IRepository<T> GetRepository<T>(T entity) where T : BaseEntity;








    }
}
