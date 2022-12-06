using Microsoft.AspNetCore.Mvc;

namespace Cats.Services
{
    /// <summary>
    /// Cat service interface to interact with Cats entities
    /// </summary>
    public interface ICatService
    {
        /// <summary>
        /// Create Csv shows the full name for each user and the total number of upvotes(across all facts) for each user.
        /// </summary>
        /// <returns>success or failure</returns>
        Task<bool> CreateCsv();
    }
}
