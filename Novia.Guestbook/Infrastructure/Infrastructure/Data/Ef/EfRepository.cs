using Microsoft.EntityFrameworkCore;
using Novia.Guestbook.Domain.Abstractions;
using Novia.Guestbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Novia.Guestbook.Infrastructure.Data.Ef
{
    /// <summary>
    /// "There's some repetition here - couldn't we have some the sync methods call the async?"
    /// https://blogs.msdn.microsoft.com/pfxteam/2012/04/13/should-i-expose-synchronouswrappers-for-asynchronous-methods/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfRepository<TDbContext, TEntity, TIEntity> : IRepository<TIEntity>
        where TIEntity : IEntity<int>
        where TEntity : Entity, TIEntity
        where TDbContext : EfDbContext
    {
        protected readonly TDbContext mDbContext;

        public EfRepository(TDbContext dbContext)
        {
            mDbContext = dbContext;
        }

        public virtual TIEntity GetById(int id)
        {
            return mDbContext.Set<TEntity>().Find(id);
        }

        public TIEntity GetSingleBySpec(ISpecification<TIEntity> spec)
        {
            return List(spec).FirstOrDefault();
        }

        public IEnumerable<TIEntity> ListAll()
        {
            return mDbContext.Set<TEntity>().AsEnumerable();
        }
        public IEnumerable<TIEntity> List(ISpecification<TIEntity> spec)
        {
            ISpecification<TEntity> specification = spec as ISpecification<TEntity>;

            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = specification.Includes
                .Aggregate(mDbContext.Set<TEntity>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = specification.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                    .Where(specification.Criteria)
                        .AsEnumerable();
        }
        public TIEntity Add(TIEntity entity)
        {
            mDbContext.Set<TEntity>().Add(entity as TEntity);
            mDbContext.SaveChanges();
            return entity;
        }
        public void Update(TIEntity entity)
        {
            mDbContext.Entry(entity as TEntity).State = EntityState.Modified;
            mDbContext.SaveChanges();
        }

        public void Delete(TIEntity entity)
        {
            mDbContext.Set<TEntity>().Remove(entity as TEntity);
            mDbContext.SaveChanges();
        }
    }
}
