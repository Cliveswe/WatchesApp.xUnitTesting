// -----------------------------------------------------------------------------
// File: IWatchRepository.cs
// Summary: Interface for watch data operations — allows fetching all watches
//          and adding new ones to the collection.
// <author> [Clive Leddy] </author>
// <created> [2025-05-23] </created>
// Notes: Meant to be implemented by services handling watch storage logic.
// -----------------------------------------------------------------------------

using Domain.Entities;

namespace Application.Interfaces;

/// <summary>
/// Defines a repository for managing a collection of watches.
/// </summary>
/// <remarks>This interface provides methods for retrieving and adding watches to a collection. Implementations
/// of this interface are responsible for managing the underlying storage  and retrieval mechanisms. The order of
/// watches in the collection is not guaranteed.</remarks>
public interface IWatchRepository
{
    /// <summary>
    /// Retrieves all watches available in the collection.
    /// </summary>
    /// <remarks>This method does not guarantee the order of the returned watches. Callers should enumerate
    /// the collection to access the individual <see cref="Watch"/> instances.</remarks>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Watch"/> objects representing all watches. The collection will be
    /// empty if no watches are available.</returns>
    IEnumerable<Watch> GetAllWatches();

    /// <summary>
    /// Adds a watch to the collection of watches.
    /// </summary>
    /// <remarks>This method adds the specified <see cref="Watch"/> object to the collection. Ensure that the
    /// <paramref name="watch"/> parameter is properly initialized before calling this method.</remarks>
    /// <param name="watch">The watch to add. Must not be <see langword="null"/>.</param>
    void AddWatch(Watch watch);
}
