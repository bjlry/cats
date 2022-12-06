using Cats.API.Models;

namespace Cats.Services
{
    /// <summary>
    /// Fake service implementation 
    /// </summary>
    public class FakeService : IFakeService
    {
        /// <summary>
        /// Fake service to return some fake data, the real data should be returned from DB
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Fact>> GetFacts()
        {
            var facts = new List<Fact>();
            // Fake data 1
            var name = new Name();
            name.First = "Kasimir";
            name.Last = "Schulz";

            var user = new User();
            user.Id = "58e007480aac31001185ecef";
            user.Name = name;

            var fact1 = new Fact();
            fact1.Id = "58e008ad0aac31001185ed0c";
            fact1.Text = "The frequency of a domestic cat's purr is the same at which muscles and bones repair themselves.";
            fact1.Type = "cat";
            fact1.UpVotes = 11;
            fact1.UserUpvoted = null;
            fact1.User = user;
            facts.Add(fact1);

            // Fake data 2
            var fact2 = new Fact();
            fact2.Id = "58e008ad0aac31001185ed0c";
            fact2.Text = "The frequency of a domestic cat's purr is the same at which muscles and bones repair themselves.";
            fact2.Type = "cat";
            fact2.UpVotes = 2;
            fact2.UserUpvoted = null;
            fact2.User = user;
            facts.Add(fact2);

            // Fake data 3
            var name3 = new Name();
            name3.First = "John";
            name3.Last = "Smith";

            var user3 = new User();
            user3.Id = "48e007480aac31001185ecef";
            user3.Name = name3;
            var fact3 = new Fact();
            fact3.Id = "48e008ad0aac31001185ed0c";
            fact3.Text = "The frequency of a domestic cat's purr is the same at which muscles and bones repair themselves.";
            fact3.Type = "cat";
            fact3.UpVotes = 3;
            fact3.UserUpvoted = null;
            fact3.User = user3;
            facts.Add(fact3);

            return facts;
        }
    }
}
