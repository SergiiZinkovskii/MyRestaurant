using System;
using System.Threading.Tasks;
using Restaurant.DAL.Interfaces;
using Restaurant.DAL.Repositories;

namespace Restaurant.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _db = dbContext;
            CartRepository = new CartRepository(_db);
            CommentRepository = new CommentRepository(_db);
            DishRepository = new DishRepository(_db);
            DishPhotoRepository = new DishPhotoRepository(_db);
            OrderRepository = new OrderRepository(_db);
            ProfileRepository = new ProfileRepository(_db);
            UserRepository = new UserRepository(_db);
        }

        public ICartRepository CartRepository { get; private set; }
        public ICommentRepository CommentRepository { get; private set; }
        public IDishRepository DishRepository { get; private set; }
        public IDishPhotoRepository DishPhotoRepository { get; private set; }
        public IOrderRepository OrderRepository { get; private set; }
        public IProfileRepository ProfileRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
