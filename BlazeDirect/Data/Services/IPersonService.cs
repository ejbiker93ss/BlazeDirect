using Microsoft.EntityFrameworkCore;
using MudBlazor;

namespace BlazeDirect.Data.Services
{
    public interface IPersonService : IDisposable
    {
        Task<List<Person>> GetAllPersonAsync();
        Task<Person> GetPersonByIdAsync(int Id);
        Task<Person> AddPersonAsync(Person person);
        Task<Person> UpdatePersonAsync(Person person);       
    }
    public class PersonService : IPersonService, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        public PersonService(ApplicationDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public async Task<List<Person>> GetAllPersonAsync()
        {
            var persons =await _dbContext.People.ToListAsync();
            return persons;
        }

        public async Task<Person> GetPersonByIdAsync(int Id)
        {
            var person = await _dbContext.People.FindAsync(Id);
            return person;
        }

        public async Task<Person> AddPersonAsync(Person person)
        {
            await _dbContext.People.AddAsync(person);
            await _dbContext.SaveChangesAsync();
            return person;
        }
        public async Task<Person> UpdatePersonAsync(Person person)
        {
            _dbContext.Entry(person).State = EntityState.Modified;
           await _dbContext.SaveChangesAsync();
           // _dbContext.People.Update(person);
           // _dbContext.SaveChanges();

            return person;
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
