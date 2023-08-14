using Restaurant.Domain.Entity;
using Restaurant.Domain.Response;
using Restaurant.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.Interfaces
{
    public interface ICommentService
    {
        Task<IResponse<Comment>> CreateAsync(int dishId, string autor, string text, CancellationToken cancellationToken);
        Task<Response<IEnumerable<CommentViewModel>>> GetComments(int dishId);
        Task<IResponse<bool>> Delete(int id);
    }
}
