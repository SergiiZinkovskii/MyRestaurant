using Restaurant.DAL.Interfaces;
using Restaurant.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task Create(User entity)
        {
            await _db.Users.AddAsync(entity);
            
        }

        public IQueryable<User> GetAll()
        {
            return _db.Users;
        }

        public async Task Delete(User entity)
        {
            _db.Users.Remove(entity);
            
        }

        public async Task<User> Update(User entity)
        {
            _db.Users.Update(entity);
            

            return entity;
        }
    }
}
