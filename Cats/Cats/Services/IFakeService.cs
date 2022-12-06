using Microsoft.AspNetCore.Connections;
using Cats.API.Models;

namespace Cats.Services
{
    /// <summary>
    /// Fake service used for the broken API
    /// </summary>
    public interface IFakeService
    {
        /// <summary>
        /// Fake GetFacts service to get all Facts info
        /// </summary>
        /// <returns></returns>
        Task<IList<Fact>> GetFacts();
    }
}
