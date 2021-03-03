using System.Collections.Generic;
using System.Threading.Tasks;

namespace BirdWatcherMobileApp.Services
{
    public interface IBirdWatcherLogService<T, U>
    {
        Task<U> GetBirdLogAsync(long id);

        Task<T> GetBirdLogsAsync();

        Task<T> GetBirdLogsAsync(int page);
    }

    public interface IKnownBirdsService<T>
    {
        Task<T> GetKnownBirdAsync(long id);

        Task<IEnumerable<T>> GetKnownBirdsAsync();
    }

    public interface IBirdWatcherService<T>
    {
        Task<T> GetServerInfo();

        Task<T> GetServerInfo(string ServerAddress);
    }
}
