using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpPost("add")]
        public IActionResult Add(Comment comment)
        {
            comment.CreatedAt = DateTime.Now;
            comment.UpdatedAt = DateTime.Now;
            _commentService.Add(comment);
            return Ok(comment);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var comments= _commentService.GetAll();
            return Ok(comments);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var commentToDelete=_commentService.GetById(id);
            _commentService.Delete(id);
            return Ok(commentToDelete);
        }

        [HttpPut("update")]
        public IActionResult Put(int id)
        {
            var commentToUpdate = _commentService.GetById(id);
            commentToUpdate.UpdatedAt = DateTime.Now;
            return Ok(commentToUpdate);
        }

        [HttpGet("getCommentById")]
        public IActionResult Get(int id)
        {

            var comment = _commentService.GetById(id);
            return Ok(comment);
        }
    }
}
