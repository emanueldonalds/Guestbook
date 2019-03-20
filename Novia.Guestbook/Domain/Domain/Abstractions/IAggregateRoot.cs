using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.Guestbook.Domain.Abstractions
{
    // <summary>
    /// Represents that the implemented classes are aggregate roots, a marker.
    /// </summary>
    public interface IAggregateRoot
    {
    }

    /// <summary>
    /// Represents that the implemented classes are aggregate roots, a marker.
    /// </summary>
    /// <typeparam name="TKey">The type of the aggregate root key.</typeparam>
    public interface IAggregateRoot<TKey> : IEntity<TKey>, IAggregateRoot
    where TKey : IEquatable<TKey>
    {
    }
}

