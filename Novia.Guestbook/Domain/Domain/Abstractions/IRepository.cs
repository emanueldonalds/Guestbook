using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.Guestbook.Domain.Abstractions
{
	 /// <summary> 
    /// Represents that the implemented classes are repositories, a marker. 
    /// </summary> 
    public interface IRepository
    { }
    
    public interface IRepository<TEntity, TKey> : IRepository
        where TKey : IEquatable<TKey> 
        where TEntity : IEntity<TKey>
    {
        TEntity GetById(TKey id);
        TEntity GetSingleBySpec(ISpecification<TEntity> spec);
        IEnumerable<TEntity> ListAll();
        IEnumerable<TEntity> List(ISpecification<TEntity> spec);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
    public interface IRepository<TEntity> : IRepository<TEntity, int> 
        where TEntity : IEntity<int>
    {
    }
}
