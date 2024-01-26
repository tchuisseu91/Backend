using CodePulse.API.Reposotories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService) {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery]string tags, [FromQuery] string? sortBy = "Id", [FromQuery] string? direction ="Asc" )
        {
            if(string.IsNullOrWhiteSpace(tags)) 
                return BadRequest("tags parameter is required");


            if (sortBy != null && sortBy != "Id" && sortBy != "Reads" && sortBy != "Likes" && sortBy != "Popularity")
                return BadRequest("sortBy parameter is invalid");

            if (direction != null && direction != "Asc" && direction != "Desc")
                return BadRequest("direction parameter is invalid");

            // call the service
            var response = await _postService.GetPosts(tags);

            // sort the result according to sortBy and direction parameters
            var result = direction == "Asc" ? response.OrderBy(o => o.GetType().GetProperty(sortBy!)!.GetValue(o))
                : response.OrderByDescending(o => o.GetType().GetProperty(sortBy!)!.GetValue(o));

            // return distinct to avoid having the same post two times
            var distinctPosts = result.Distinct().ToList();


            return Ok(distinctPosts);
        }
    }
}
