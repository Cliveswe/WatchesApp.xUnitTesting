// -----------------------------------------------------------------------------
// File: Program.cs
// Summary: Entry point for the WatchesApp.Console project. Provides a console
//          interface for listing all watches and retrieving details by ID.
// <author> [Clive Leddy] </author>
// <created> [2025-06-11] </created>
// Notes: Demonstrates usage of the WatchService and WatchRepository layers.
//        Allows users to interact with the watch collection via the terminal.
// -----------------------------------------------------------------------------

using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Infrastructure.Repositories;

namespace WatchesApp.Terminal;

/// <summary>
/// Represents the entry point of the application, providing methods to list and retrieve watch details.
/// </summary>
/// <remarks>The <see cref="Program"/> class contains the main entry point of the application and methods for
/// interacting with a collection of watches. It allows users to list all available watches and retrieve details of a
/// specific watch by its ID. The application interacts with the user via the console.</remarks>
public class Program
{
    static readonly IWatchRepository watchService = new WatchService(new WatchRepository());
    static void Main(string[] args) {

        ListAllWatches();
        GetAllWatchesByID();

    }

    /// <summary>
    /// Prompts the user to enter a watch ID and retrieves the details of the watch with the specified ID.
    /// </summary>
    /// <remarks>This method interacts with the user via the console to input a watch ID and displays the
    /// details of the corresponding watch, including brand, model, price, release year, and availability
    /// status.</remarks>
    private static void GetAllWatchesByID() {
        int watchId;

        Console.WriteLine("Enter the ID of the watch you want to retrieve:");

        Console.WriteLine("Retrieving watch by ID...");
        Console.Write("Enter a watch id: ");
        watchId = int.Parse(Console.ReadLine() ?? "0");

        Watch watch = watchService.GetWatchByID(watchId);
        Console.WriteLine($"\nBrand: {watch.Brand}\nModel: {watch.Model}\nPrice: {watch.Price}\nYear: {watch.ReleaseYear}");
        Console.WriteLine("Is available: " + (watch.IsAvailable ? "Yes" : "No"));
    }

    /// <summary>
    /// Lists all watches in the collection, sorted by ID, brand, and model.
    /// </summary>
    /// <remarks>This method retrieves all watches from the underlying data source, sorts them by their ID, 
    /// brand, and model in ascending order, and outputs their details to the console.  The total number of watches is
    /// also displayed at the end.</remarks>
    public static void ListAllWatches() {
        var watchList = watchService.GetAllWatches()
            .OrderBy(watch => watch.Id) // Correctly sort the list by ID
            .ThenBy(watch => watch.Brand) // Then by brand
            .ThenBy(watch => watch.Model) // Then by brand model
            .ToList(); // Convert the IEnumerable to a List

        foreach(var watch in watchList) {
            Console.WriteLine($"ID: {watch.Id} Brand: {watch.Brand}, Model: {watch.Model}");
        }
        Console.WriteLine($"Total watches: {watchList.Count}");
        Console.WriteLine();
    }
}
