using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Interfaces;
using Restaurant.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly ApplicationDbContext _db;

        public DishRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<Dish?> Find(long id, CancellationToken cancellationToken)
        {
            return await GetAll()
                .Include(p => p.DishPhotos) 
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task Create(Dish entity)
        {
            await _db.Dishes.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Dish> GetAll()
        {
            return _db.Dishes;
        }

        public async Task Delete(Dish entity)
        {
            _db.Dishes.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Dish> Update(Dish entity)
        {
            _db.Dishes.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        IQueryable<Dish> IBaseRepository<Dish>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
