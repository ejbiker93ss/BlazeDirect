// Services/UserLevelService.cs
using Microsoft.EntityFrameworkCore;

namespace BlazeDirect.Data.Services
{
    public interface IUserLevelService
    {
        /// <summary>
        /// Retrieves all available UserLevel records.
        /// </summary>
        Task<List<UserLevel>> GetUserLevelsAsync();
    }
    public class UserLevelService : IUserLevelService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserLevelService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserLevel>> GetUserLevelsAsync()
        {
            return await _dbContext.UserLevels
                                   .AsNoTracking()
                                   .ToListAsync();
        }
    }
}
