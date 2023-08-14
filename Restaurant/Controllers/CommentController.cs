using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.Interfaces;

namespace Restaurant.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpPost]
        public async Task<IActionResult> GetComments(int id)
        {

            var productComments = await _commentService.GetComments(id);
            return PartialView(productComments.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _commentService.Delete(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return Ok();
            }

            return View("Error", $"{response.Description}");
        }



        [HttpPost]
        public async Task<IActionResult> AddComment(int dishId, string text, CancellationToken cancellationToken)
        {

            string _author = User.Identity.Name;

            await _commentService.CreateAsync(dishId, _author, text, cancellationToken );
            return Ok();
        }
    }
}
