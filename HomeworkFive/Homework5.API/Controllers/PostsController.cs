using Homework5.API.Business;
using Homework5.API.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework5.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult GetAll()
        {
            var result = _postService.GetAllPosts();
            return Ok(result);
        }

        [HttpGet]
        [Route("UserPosts/{userId}")]
        public IActionResult GetUserPosts(int userId)
        {
            var result = _postService.GetUserPosts(userId);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPost(int id)
        {
            var result = _postService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddPost([FromBody] Post post)
        {
            _postService.AddPost(post);
            return Created("Post Added To Database.", post);
        }
    }
}
