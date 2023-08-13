namespace Restaurant.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICartRepository CartRepository { get; }
        ICommentRepository CommentRepository { get; }
        IDishRepository DishRepository { get; }
        IDishPhotoRepository DishPhotoRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProfileRepository ProfileRepository { get; }
        IUserRepository UserRepository { get; }
        Task CommitAsync();
    }
}