using AutoMapper;
using Cats.API.ViewModels.Response;
using Cats.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cats.Controllers
{
    /// <summary>
    /// fake API Controller for the broken API
    /// </summary>
    [ApiController]
    [Route("fake")]
    public class FakeAPIController : ControllerBase
    {
        private readonly IFakeService _fakeService;
        private readonly IMapper _mapper;
        public FakeAPIController(IFakeService fakeService, IMapper mapper)
        {
            _fakeService = fakeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Fake GetFacts API for the broken API
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("")]
        public async Task<IActionResult> GetFacts()
        {
            var facts = await _fakeService.GetFacts();

            if (facts == null)
                return BadRequest("Unable to get facts");

            var responseDtos = new List<GetFactsResponseItem>();
            foreach (var fact in facts)
            {
                var responseDto = _mapper.Map<GetFactsResponseItem>(fact);
                responseDtos.Add(responseDto);
            }
            return Ok(facts);
        }
    }
}
