using System;
using System.Collections.Generic;
using System.Text;

using Novia.Guestbook.Domain.Abstractions;

namespace Novia.Guestbook.Domain.Entities
{
    /// <summary>
    /// Entity base class (Handles equality and identity)
    /// </summary>
    /// <typeparam name="TKey">The type of the key of the entity.</typeparam>
    public abstract class Entity<TKey> : IEquatable<Entity<TKey>>, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {

        public virtual TKey Id { get; set; }
        

        public Entity()
            : base()
        {
            Id = default(TKey);
        }

        public Entity(TKey id)
        {
            Id = id;
        }

        /// <summary>
        /// Check if this entity is transient, ie, without identity at this moment
        /// </summary>
        /// <returns>True if entity is transient, else false</returns>
        public bool IsTransient()
        {
            return Equals(Id, default(TKey));
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; 
        /// otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Entity<TKey> other)
        {
            if (other == null)
                return false;

            // Handle the case of comparing two NEW objects    
            var otherIsTransient = Equals(other.Id, default(TKey));
            var currentIsTransient = Equals(Id, default(TKey));

            if (otherIsTransient && currentIsTransient)
                return ReferenceEquals(other, this);

            return other.Id.Equals(Id);
        }


        /// <summary>
        /// Equality
        /// </summary>
        public override bool Equals(object obj)
        {
            var other = obj as Entity<TKey>;

            return Equals(other);
        }
        /// <summary>
        /// Gets the hash code for an object based on the given id
        /// </summary>
        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<TKey>.Default.GetHashCode(Id);
        }


        /// <summary>
        /// Equal operator
        /// </summary>
        public static bool operator ==
            (Entity<TKey> x, Entity<TKey> y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// Not equal operator
        /// </summary>
        public static bool operator !=
            (Entity<TKey> x, Entity<TKey> y)
        {
            return !(x == y);
        }

    }

    // Using non-generic integer types for simplicity and to ease caching logic
    public abstract class Entity : Entity<int>
    {

    }
}
