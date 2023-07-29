using Restaraunt.DAL.Interfaces;
using Restaraunt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaraunt.DAL.Repositories
{
    public class CartRepository : ICartRepository
    {
        public Task Create(Cart entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Cart entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Cart> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Cart> Update(Cart entity)
        {
            throw new NotImplementedException();
        }
    }
}
