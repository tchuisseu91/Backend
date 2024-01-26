using CodePulse.API.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Reposotories.Interface
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPosts(string tags);
    }
}
