using CodePulse.API.Models.Domain;
using CodePulse.API.Reposotories.Interface;
using CodePulse.API.Settings;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace CodePulse.API.Reposotories.Implementation
{
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly AppSettings _appSettings;

        public PostService(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public async Task<IEnumerable<Post>> GetPosts(string tags)
        {
           var url = $"{_appSettings.ApiBaseUrl}/posts?tag={tags}";

           var response = await _httpClient.GetAsync(url);

            var postResponse = await response.Content.ReadFromJsonAsync<PostResponse>();

            return postResponse!.Posts!;
        }
    }
}
