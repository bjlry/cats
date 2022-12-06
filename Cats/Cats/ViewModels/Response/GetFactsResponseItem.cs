using Cats.API.Models;
using System.Text.Json.Serialization;

namespace Cats.API.ViewModels.Response
{
    public class GetFactsResponseItem
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("user")]
        public User User { get; set; }
        [JsonPropertyName("upVotes")]
        public int UpVotes { get; set; }
        [JsonPropertyName("userUpvoted")]
        public bool? UserUpvoted { get; set; }
    }
}
