using Microsoft.EntityFrameworkCore;

namespace BlazeDirect.Data
{
    public class PeopleService
    {
        private readonly ApplicationDbContext _context;

        public PeopleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetPeopleAsync()
        {
            return await _context.People
               // .Where(p => p.IsActive) // Assuming you want only active people
                .ToListAsync();
        }
    }


}
