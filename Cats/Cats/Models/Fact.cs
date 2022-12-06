using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Cats.API.Models
{
    /// <summary>
    /// Fact information
    /// </summary>
    [Serializable]
    public class Fact
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }
        
        public int UpVotes { get; set; }
        public bool? UserUpvoted { get; set; }
        public bool Used { get; set; }
        public string Source { get; set; }
        public bool Deleted { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int V { get; set; }
        public User User { get; set; }
        public Status Status { get; set; }
    }
}