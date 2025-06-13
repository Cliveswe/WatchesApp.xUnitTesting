// -----------------------------------------------------------------------------
// File: WatchService.cs
// Summary: Service class that provides a higher-level interface for managing
//          watches by delegating operations to an IWatchRepository implementation.
// <author> [Clive Leddy] </author>
// <created> [2025-05-23] </created>
// Notes: Acts as a wrapper around IWatchRepository. Handles business logic and
//        abstracts repository details from consumers. No longer manages data storage
//        or singleton instance directly.
// -----------------------------------------------------------------------------


using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

/// <summary>
/// Provides functionality to manage and retrieve watch entities.
/// </summary>
/// <remarks>This service acts as a wrapper around an <see cref="IWatchRepository"/> implementation,  delegating
/// operations such as adding and retrieving watches. It is designed to abstract  the underlying repository and provide
/// a higher-level interface for managing watches.</remarks>
/// <param name="repository"></param>
public class WatchService(IWatchRepository repository) : IWatchRepository
{
    /// <summary>
    /// Adds a new watch to the repository.
    /// </summary>
    /// <remarks>This method stores the provided watch in the underlying repository. Ensure that the watch
    /// object  is properly initialized before calling this method.</remarks>
    /// <param name="watch">The watch to add. Cannot be null.</param>
    public void AddWatch(Watch watch) {
        repository.AddWatch(watch);
    }

    /// <summary>
    /// Retrieves all watches from the repository.
    /// </summary>
    /// <remarks>This method provides a read-only view of the watches stored in the repository.</remarks>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Watch"/> objects representing all watches in the repository. The
    /// collection will be empty if no watches are available.</returns>
    public IEnumerable<Watch> GetAllWatches() {
        return repository.GetAllWatches();
    }

    /// <summary>
    /// Retrieves a watch by its unique identifier.
    /// </summary>
    /// <param name="watchId">The unique identifier of the watch to retrieve. Must be a valid, non-negative integer.</param>
    /// <returns>The <see cref="Watch"/> object corresponding to the specified <paramref name="watchId"/>.</returns>
    /// <exception cref="ArgumentException">Thrown if no watch is found with the specified <paramref name="watchId"/>.</exception>
    public Watch GetWatchByID(int watchId) {
        var watch = repository.GetWatchByID(watchId);
        if(watch == null) {
            throw new ArgumentException($"No watch found with ID {watchId}", nameof(watchId));
        }
        return watch;
    }
}
