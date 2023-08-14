using Restaurant.DAL.Interfaces;
using Restaurant.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _db;

        public CartRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task Create(Cart entity)
        {
            await _db.Carts.AddAsync(entity);

        }

        public IQueryable<Cart> GetAll()
        {
            return _db.Carts;
        }

        public async Task Delete(Cart entity)
        {
            _db.Carts.Remove(entity);

        }

        public async Task<Cart> Update(Cart entity)
        {
            _db.Carts.Update(entity);


            return entity;
        }
    }
}
