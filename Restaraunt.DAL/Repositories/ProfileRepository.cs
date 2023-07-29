using Restaraunt.DAL.Interfaces;
using Restaraunt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaraunt.DAL.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext _db;

        public ProfileRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task Create(Profile entity)
        {
            await _db.Profiles.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Profile> GetAll()
        {
            return _db.Profiles;
        }

        public async Task Delete(Profile entity)
        {
            _db.Profiles.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Profile> Update(Profile entity)
        {
            _db.Profiles.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
