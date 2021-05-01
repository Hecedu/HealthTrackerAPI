 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthTrackerAPI.Models
{
    public interface IRepository
    {
        public Task<IEnumerable<UserMealLog>> GetAllUserMealLogs();
        public Task<IEnumerable<UserMealLog>> GetUserMealLogs(string userId);
        public Task AddUserMealLogAsync(UserMealLog userMealLog);
        public Task AddUserMealLogsAsync(IEnumerable<UserMealLog> userMealLogs);
        public Task DeleteUserMealLogAsync(UserMealLog userMealLog);
        public Task DeleteUserMealLogsAsync(string userId);

        public Task<IEnumerable<UserActivityLog>> GetAllUserActivityLogs();
        public Task<IEnumerable<UserActivityLog>> GetUserActivityLogs(string userId);
        public Task AddUserActivityLogAsync(UserActivityLog userActivityLog);
        public Task AddUserActivityLogsAsync(IEnumerable<UserActivityLog> userActivityLogs);
        public Task DeleteUserActivityLogAsync(UserActivityLog userActivtyLog);
        public Task DeleteUserActivityLogsAsync(string userId);
    }
}
