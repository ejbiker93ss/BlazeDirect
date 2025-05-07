using Microsoft.EntityFrameworkCore;

namespace BlazeDirect.Data.Services
{
    public interface IUserService
    {
        // Method to retrieve a list of users  
        Task<List<ApplicationUser>> GetUsersAsync();

        // Method to update a user  
        Task<bool> LinkPersonToUser(ApplicationUser user);

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

        public async Task<List<ApplicationUser>> GetUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
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