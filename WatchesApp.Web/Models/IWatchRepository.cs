namespace WatchesApp.Web.Models;

public interface IWatchRepository
{
    IEnumerable<Watch> GetAllWatches();
    Watch? GetWatchById(int id);
    void AddWatch(Watch watch);
    void UpdateWatch(Watch watch);
    void DeleteWatch(int id);
}
