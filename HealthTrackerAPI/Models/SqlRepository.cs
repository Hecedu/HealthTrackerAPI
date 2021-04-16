using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthTrackerAPI.Models
{
    public class SqlRepository : IRepository
    {
        private readonly ApplicationDbContext context;

        //Task<IEnumerable<Post>> IRepository.PostList => throw new NotImplementedException();

        public SqlRepository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //Meal Log Actions
        public async Task AddUserMealLogAsync(UserMealLog userMealLog)
        {
            context.UserMealLogs.Add(userMealLog);
            await context.SaveChangesAsync();
        }
        public async Task AddUserMealLogsAsync(IEnumerable<UserMealLog> userMealLogs)
        {
            context.UserMealLogs.AddRange(userMealLogs);
            await context.SaveChangesAsync();
        }
        public async Task DeleteUserMealLogAsync(UserMealLog userMealLog)
        {
           context.UserMealLogs.Remove(userMealLog);
           await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<UserMealLog>> GetAllUserMealLogs()
        {
            return await EntityFrameworkQueryableExtensions.ToListAsync(context.UserMealLogs);
        }
        public async Task<IEnumerable<UserMealLog>> GetUserMealLogs(string userId)
        {
            return await context.UserMealLogs.Where(log => log.UserId == userId).ToListAsync();
        }

        //Activity Logs Actions
        public async Task AddUserActivityLogAsync(UserActivityLog userActivityLog)
        {
            context.UserActivityLogs.Add(userActivityLog);
            await context.SaveChangesAsync();
        }
        public async Task AddUserActivityLogsAsync(IEnumerable<UserActivityLog > userActivityLogs)
        {
            context.UserActivityLogs.AddRange(userActivityLogs);
            await context.SaveChangesAsync();
        } 
        public async Task DeleteUserActivityLogAsync(UserActivityLog userActivityLog)
        {
            context.UserActivityLogs.Remove(userActivityLog);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<UserActivityLog>> GetAllUserActivityLogs()
        {
            return await EntityFrameworkQueryableExtensions.ToListAsync(context.UserActivityLogs);
        }
        public async Task<IEnumerable<UserActivityLog>> GetUserActivityLogs(string userId)
        {
            return await context.UserActivityLogs.Where(log => log.UserId == userId).ToListAsync();
        }
    }
}
