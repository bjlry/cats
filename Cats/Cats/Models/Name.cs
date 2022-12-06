using System.Text.Json.Serialization;

namespace Cats.API.Models
{
    /// <summary>
    /// User Name information
    /// </summary>
    public class Name
    {
        [JsonPropertyName("first")]
        public string First { get; set; }
        [JsonPropertyName("last")]
        public string Last { get; set; }
    }
}
