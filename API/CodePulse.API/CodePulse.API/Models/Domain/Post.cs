namespace CodePulse.API.Models.Domain
{
    public class Post
    {
        public int Id { get; set; }
        public string Author { get; set; }= string.Empty;
        public int AuthorId { get; set; }
        public int Likes { get; set; }
        public double Popularity { get; set; }
        public long Reads { get; set; }
        public string[] Tags { get; set; } = new string[] { };
    }
}
