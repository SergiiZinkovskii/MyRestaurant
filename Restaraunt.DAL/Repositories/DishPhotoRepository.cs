using Restaurant.DAL.Interfaces;
using Restaurant.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repositories
{
    public class DishPhotoRepository : IDishPhotoRepository
    {
        private readonly ApplicationDbContext _db;

        public DishPhotoRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task Create(DishPhoto entity)
        {
            await _db.DishPhotos.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<DishPhoto> GetAll()
        {
            return _db.DishPhotos;
        }

        public async Task Delete(DishPhoto entity)
        {
            _db.DishPhotos.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<DishPhoto> Update(DishPhoto entity)
        {
            _db.DishPhotos.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
