using Microsoft.EntityFrameworkCore;

namespace BlazeDirect.Data.Services
{
    public interface IUserService
    {
        // Method to retrieve a list of users  
        Task<List<ApplicationUser>> GetUsersAsync();

        // Method to update a user  
        Task<bool> LinkPersonToUser(ApplicationUser user);
        Task<bool> UpdateUserAsync(ApplicationUser user);
        // Method to retrieve users by PersonID
        Task<List<ApplicationUser>> GetUsersByPersonIdAsync(int personId);
    }
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            // load the tracked entity
            var existing = await _dbContext.Users.FindAsync(user.Id);
            if (existing == null)
                return false;

            // copy over only the fields you want to allow editing
            existing.FirstName = user.FirstName;
            existing.LastName = user.LastName;
            existing.UserLevelID = user.UserLevelID;

            // commit
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ApplicationUser>> GetUsersAsync()
        {
            return await _dbContext.Users
                .Include(u => u.UserLevel)
                .ToListAsync();
        }

        public async Task<bool> LinkPersonToUser(ApplicationUser user)
        {
            var existingUser = await _dbContext.Users.FindAsync(user.Id);
            if (existingUser != null)
            {
                existingUser.PersonID = user.PersonID;

                _dbContext.Users.Update(existingUser);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ApplicationUser>> GetUsersByPersonIdAsync(int personId)
        {
            return await _dbContext.Users
                .Where(user => user.PersonID == personId)
                .ToListAsync();
        }
    }
}