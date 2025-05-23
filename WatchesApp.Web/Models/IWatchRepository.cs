// -----------------------------------------------------------------------------
// File: IWatchRepository.cs
// Summary: Interface for managing watch data — includes methods to get, add,
//          update, and delete watch records. Used by services and controllers.
// Author: [Clive Leddy]
// Created: [2025-05-23]
// Notes: Helps abstract data access logic for watches in the app.
// -----------------------------------------------------------------------------

namespace WatchesApp.Web.Models;

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
    /// Retrieves a watch by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the watch to retrieve. Must be a positive integer.</param>
    /// <returns>The <see cref="Watch"/> object with the specified identifier, or <see langword="null"/> if no watch with the
    /// given ID exists.</returns>
    Watch? GetWatchById(int id);

    /// <summary>
    /// Adds a watch to the collection of watches.
    /// </summary>
    /// <remarks>This method adds the specified <see cref="Watch"/> object to the collection. Ensure that the
    /// <paramref name="watch"/> parameter is properly initialized before calling this method.</remarks>
    /// <param name="watch">The watch to add. Must not be <see langword="null"/>.</param>
    void AddWatch(Watch watch);

    /// <summary>
    /// Updates the details of an existing watch.
    /// </summary>
    /// <remarks>This method modifies the properties of the specified watch. Ensure that the <paramref
    /// name="watch"/> object represents a valid and existing watch before calling this method.</remarks>
    /// <param name="watch">The <see cref="Watch"/> object containing the updated details. Must not be <see langword="null"/>.</param>
    void UpdateWatch(Watch watch);

    /// <summary>
    /// Deletes the watch with the specified identifier.
    /// </summary>
    /// <remarks>This method removes the watch from the underlying data store. If the specified watch does not
    /// exist, an exception is thrown.</remarks>
    /// <param name="id">The unique identifier of the watch to delete. Must be a positive integer.</param>
    void DeleteWatch(int id);
}
