using System.Text.Json.Serialization;

namespace Cats.API.Models
{
    /// <summary>
    /// User information
    /// </summary>
    public class User
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public Name Name { get; set; }
    }
}
