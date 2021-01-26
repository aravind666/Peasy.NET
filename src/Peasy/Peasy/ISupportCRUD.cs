﻿using System.Collections.Generic;

namespace Peasy
{
    /// <inheritdoc cref="IDataProxy{T, TKey}"/>
    public interface ISupportCRUD<T, TKey> :
        ISupportGetAll<T>,
        ISupportGetByID<T, TKey>,
        ISupportInsert<T>,
        ISupportUpdate<T>,
        ISupportDelete<TKey>
    {
    }

    /// <summary>
    /// Represents a data abstraction that retrieves all domain objects or resources from a source.
    /// </summary>
    public interface ISupportGetAll<T>
    {
        /// <summary>
        /// Retrieves all domain objects or resources from a source.
        /// </summary>
        /// <returns>A list of resources.</returns>
        IEnumerable<T> GetAll();
    }

    /// <summary>
    /// Represents a data abstraction that retrieves a domain object or resource from a source specified by an identifier.
    /// </summary>
    public interface ISupportGetByID<T, TKey>
    {
        /// <summary>
        /// Retrieves a domain object or resource from a source specified by an identifier.
        /// </summary>
        /// <param name="id">The id of the resource to retrieve.</param>
        /// <returns>The retrieved resource.</returns>
        T GetByID(TKey id);
    }

    /// <summary>
    /// Represents a data abstraction that creates a new domain object or resource.
    /// </summary>
    public interface ISupportInsert<T>
    {
        /// <summary>
        /// Creates a new domain object or resource.
        /// </summary>
        /// <param name="resource">The resource to insert.</param>
        /// <returns>
        /// An updated representation of the created domain object or resource.
        /// </returns>
        T Insert(T resource);
    }

    /// <summary>
    /// Represents a data abstraction that updates an existing domain object or resource.
    /// </summary>
    public interface ISupportUpdate<T>
    {
        /// <summary>
        /// Updates an existing domain object or resource.
        /// </summary>
        /// <param name="resource">The resource to update.</param>
        /// <returns>
        /// An updated representation of the updated domain object or resource.
        /// </returns>
        T Update(T resource);
    }

    /// <summary>
    /// Represents a data abstraction that deletes a domain object or resource from a source specified by an identifier.
    /// </summary>
    public interface ISupportDelete<TKey>
    {
        /// <summary>
        /// Deletes a domain object or resource from a source specified by an identifier.
        /// </summary>
        /// <param name="id">The id of the resource to delete.</param>
        void Delete(TKey id);
    }
}
