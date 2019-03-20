using System;
using System.Collections.Generic;
using System.Text;
namespace Novia.Guestbook.Domain.Abstractions
{
    /// <summary>
    /// Marker interface to mark a entity
    /// Represents that the implemented classes are domain entities.
    /// </summary>
    public interface IEntity
    {
    }

    /// <summary>
    /// Marker interface to mark a entity
    /// Represents that the implemented classes are domain entities.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity key.</typeparam>
    public interface IEntity<TKey> : IEntity
    where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the identifier of the entity.
        /// </summary>
        /// <value>
        /// The identifier of the entity.
        /// </value>
        TKey Id { get; set; }
    }
}