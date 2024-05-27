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
        public IActionResult Update(int CommentId, int DormitoryId, String CommentContent, int UserId, DateTime CreatedAt, DateTime UpdatedAt)
        {
            var commentToUpdate = _commentService.GetById(CommentId);
            _commentService.Update(CommentId, DormitoryId, CommentContent, UserId, CreatedAt, UpdatedAt);
            commentToUpdate= _commentService.GetById(CommentId);
            commentToUpdate.UpdatedAt = DateTime.Now;
            return Ok(commentToUpdate);
        }

        [HttpGet("getCommentById")]
        public IActionResult Get(int id)
        {

            var comment = _commentService.GetById(id);
            return Ok(comment);
        }

        [HttpGet("getCommentByDormitoryId")]
        public IActionResult GetCommentByDormitoryId(int id)
        {
            var comment= _commentService.GetCommentByDormitoryId(id);
            return Ok(comment);
        }

        [HttpGet("getAllCommentByDormitoryId")]
        public IActionResult GetAllCommentByDormitoryId(int dormId)
        {
            var commentList = _commentService.GetAllCommentsByDormitoryId(dormId);
            return Ok(commentList);
        }
    }
}
