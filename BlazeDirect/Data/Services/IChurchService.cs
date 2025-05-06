using Microsoft.EntityFrameworkCore;

namespace BlazeDirect.Data.Services
{
    public interface IChurchService: IDisposable
    {
        Task<List<Church>> GetAllChurchAsync();
        Task<Church> GetChurchByIdAsync(int Id);
        Task<Church> AddChurchAsync(Church church);
        Task<Church> UpdateChurchAsync(Church church);        
    }
    public class ChurchService : IChurchService, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        public ChurchService(ApplicationDbContext dbContext)
        {
            if (_dbContext is null)
                _dbContext = dbContext;
        }
        public Task<Church> AddChurchAsync(Church church)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Church>> GetAllChurchAsync()
        {
            var churches = await _dbContext.Churches.ToListAsync();
            return churches;
        }

        public async Task<Church> GetChurchByIdAsync(int Id)
        {
            var churches = await _dbContext.Churches.FindAsync(Id);
            return churches;            
        }
        
        public Task<Church> UpdateChurchAsync(Church church)
        {
            throw new NotImplementedException();
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
