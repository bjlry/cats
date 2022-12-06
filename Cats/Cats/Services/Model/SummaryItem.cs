using System.Text.Json.Serialization;
namespace Cats.API.Services.Model
{
    /// <summary>
    /// Summary Item
    /// </summary>
    public class SummaryItem
    {
        public string Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int UpVotes { get; set; }
    }
}
