using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Interfaces;
using Restaurant.DAL.Repositories;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Enum;
using Restaurant.Domain.Response;
using Restaurant.Domain.ViewModel;
using Restaurant.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Services.Services
{
    public class CommentService : ICommentService

    {
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDishRepository _dishRepository;
        

        public CommentService(IUserRepository userRepository, ICommentRepository commentRepository, IDishRepository dishRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
            _dishRepository = dishRepository;
        }

        public async Task<IResponse<Comment>> CreateAsync(int dishId, string author, string text, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                DishId = dishId,
                Text = text,
                Author = author
            };

            var dish = await _dishRepository.Find(dishId, cancellationToken);
            if (dish == null)
            {
                return new Response<Comment>
                {
                    Description = "Dish not found",
                    StatusCode = StatusCode.DishNotFound
                };
            }

            comment.Dish = dish;

            await _commentRepository.Create(comment);
            await _unitOfWork.CommitAsync();

            return new Response<Comment>
            {
                Description = "Comment added",
                StatusCode = StatusCode.OK,
                Data = comment
            };
        }


        public async Task<IResponse<bool>> Delete(int id)
        {
            try
            {
                var dish = await _commentRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (dish == null)
                {
                    return new Response<bool>()
                    {
                        Description = "Dish not found",
                        StatusCode = StatusCode.DishNotFound,
                        Data = false
                    };
                }

                await _commentRepository.Delete(dish);
                await _unitOfWork.CommitAsync();

                return new Response<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>()
                {
                    Description = $"[DeleteComment] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }




        public async Task<Response<IEnumerable<CommentViewModel>>> GetComments(int dishId)
        {
            var comments = await _commentRepository.GetAll()
                .Where(c => c.DishId == dishId)
                .ToListAsync();
            var commentViewModels = comments.Select(c => new CommentViewModel
            {
                Id = c.Id,
                DishId = c.DishId,
                Text = c.Text,
                Author = c.Author
            });
            return new Response<IEnumerable<CommentViewModel>>
            {
                Data = commentViewModels,
                Description = "Comment added",
                StatusCode = StatusCode.OK
            };
        }
    }
}
