using System.ComponentModel;

namespace CodePulse.API.Models.Enums
{
    public enum PostSortByEnum
    {
        [Description("Id")]
        Id = 1,
        [Description("Reads")]
        Reads = 2,
        [Description("Likes")]
        Likes = 3,
        [Description("Popularity")]
        Popularity = 4,
    }
}
