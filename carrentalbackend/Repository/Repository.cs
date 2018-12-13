using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext Context;
        public Repository(DbContext context)
        {
            Context = context;

        }
        public void AddRange(IEnumerable<TEntity> entity)
        {
            Context.Set<TEntity>().AddRange(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void DeleteAtRange(IEnumerable<TEntity> entity)
        {
            Context.Set<TEntity>().RemoveRange(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().Where(expression).ToList();
        }

        //Finns problem med denna method , Problem med assambly filen
        public TEntity FindByID(int Id)
        {
            return Context.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAllWhere(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().DefaultIfEmpty().Where(expression).ToList();
        }

        public IRepository<T> GetRepository<T>(T entity) where T : BaseEntity
        {
            return new Repository<T>(Context);
        }

        public TEntity Insert(TEntity entity)
        {
            entity.SetDate();
            Context.Set<TEntity>().Add(entity);
            return entity;
        }

        public TEntity SingelOrDafault(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().DefaultIfEmpty().Where(expression).FirstOrDefault();
        }
    }
}
