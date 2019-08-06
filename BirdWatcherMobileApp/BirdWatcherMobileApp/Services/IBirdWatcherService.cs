using System.Collections.Generic;
using System.Threading.Tasks;

namespace BirdWatcherMobileApp.Services
{
    public interface IBirdWatcherLogService<T>
    {
        Task<T> GetBirdLogAsync(long id);

        Task<IEnumerable<T>> GetBirdLogsAsync();
    }

    public interface IBirdExampleService<T>
    {
        Task<T> GetKnownBirdAsync(long id);

        Task<IEnumerable<T>> GetKnownBirdsAsync();
    }

    public interface IBirdWatcherService<T>
    {
        Task<T> GetServerInfo();
    }
}
