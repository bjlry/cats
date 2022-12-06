using Cats.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cats.Controllers
{
    /// <summary>
    /// Controller for Cats API
    /// </summary>
    [ApiController]
    [Route("cats")]
    public class CatController : ControllerBase
    {
        private readonly ICatService _catService;

        public CatController(ICatService catService)
        {
            _catService = catService;
        }

        /// <summary>
        /// API to create csv file that shows the full name for each user and the total number of upvotes(across all facts) for each user.
        /// </summary>
        /// <returns>Csc file created in directory define in appsetting.json</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = "GetCsv")]
        public IActionResult GetCsv()
        {
            return Ok(_catService.CreateCsv());
        }
    }
}