using Restaraunt.DAL.Interfaces;
using Restaraunt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaraunt.DAL.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly ApplicationDbContext _db;

        public DishRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task Create(Dish entity)
        {
            await _db.Dishes.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<DishPhoto> GetAll()
        {
            return _db.DishPhotos;
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
    }
}
