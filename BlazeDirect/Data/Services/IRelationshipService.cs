using Microsoft.EntityFrameworkCore;
using System;

namespace BlazeDirect.Data.Services
{
    public interface IRelationshipService:IDisposable
    {
        Task<List<Relationship>> GetAllRelationshipAsync();
        Task<List<Relationship>> GetAllRelationshipByPersonIdAsync(int personId);        
        Task<Relationship> GetRelationshipByIdAsync(int Id);
        Task<Relationship> AddRelationshipAsync(Relationship relationship);
        Task<Relationship> UpdateRelationshipAsync(Relationship relationship);

        Task<List<RelationshipType>> GetAllRelationshipTypeAsync();
        Task<RelationshipType> GetRelationshipTypeByIdAsync(int Id);
        Task<RelationshipType> AddRelationshipTypeAsync(RelationshipType relationshipType);
        Task<RelationshipType> UpdateRelationshipTypeAsync(RelationshipType relationshipType);
    }
    public class RelationshipService : IRelationshipService, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        public RelationshipService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Relationship>> GetAllRelationshipAsync()
        {
            var relationships = await _dbContext.Relationships.ToListAsync();
            return relationships;
        }
        public async Task<List<Relationship>> GetAllRelationshipByPersonIdAsync(int personId)
        {
            var relationships = await _dbContext.Relationships.Include(x=>x.RelationshipType).Where(x=>x.PersonId== personId).ToListAsync();
            return relationships;
        }
        public async Task<Relationship> GetRelationshipByIdAsync(int Id)
        {
            var relationship = await _dbContext.Relationships.FindAsync(Id);
            return relationship;
        }
        public async Task<Relationship> AddRelationshipAsync(Relationship relationship)
        {
            await _dbContext.Relationships.AddAsync(relationship);
            await _dbContext.SaveChangesAsync();
            return relationship;
        }
        public async Task<Relationship> UpdateRelationshipAsync(Relationship relationship)
        {
            _dbContext.Entry(relationship).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return relationship;
        }
        public async Task<List<RelationshipType>> GetAllRelationshipTypeAsync()
        {
            var relationshipTypes = await _dbContext.RelationshipTypes.ToListAsync();
            return relationshipTypes;
        }

        public async Task<RelationshipType> GetRelationshipTypeByIdAsync(int Id)
        {
            var relationshipTypes = await _dbContext.RelationshipTypes.FindAsync(Id);
            return relationshipTypes;
        }
        public async Task<RelationshipType> AddRelationshipTypeAsync(RelationshipType relationshipType)
        {
            await _dbContext.RelationshipTypes.AddAsync(relationshipType);
            await _dbContext.SaveChangesAsync();
            return relationshipType;
        }

        public async Task<RelationshipType> UpdateRelationshipTypeAsync(RelationshipType relationshipType)
        {
            _dbContext.Entry(relationshipType).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return relationshipType;
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
