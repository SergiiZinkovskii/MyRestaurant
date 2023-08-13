using Restaurant.DAL.Interfaces;
using Restaurant.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task Create(Order entity)
        {
            await _db.Orders.AddAsync(entity);
        }

        public IQueryable<Order> GetAll()
        {
            return _db.Orders;
        }

        public async Task Delete(Order entity)
        {
            _db.Orders.Remove(entity);
            
        }

        public async Task<Order> Update(Order entity)
        {
            _db.Orders.Update(entity);
            

            return entity;
        }
    }
}
