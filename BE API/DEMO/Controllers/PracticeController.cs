using DEMO.Model;
using DEMO.Service;
using Microsoft.AspNetCore.Mvc;

namespace DEMO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PracticeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<PracticeController> _logger;

        public PracticeController(ILogger<PracticeController> logger)
        {
            _logger = logger;
        }

        [Route("GetDogImageAsync")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DogImageRes))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDogImgAsync()
        {
            try
            {
                var dogImage = await HttpHelperExternal.GetTAsync<DogImageRes>("https://dog.ceo/api/breeds/image/random");
                return Ok(dogImage);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [Route("GetDuckImageAsync")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DuckImageRes))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDuckImgAsync()
        {
            try
            {
                var duckImage = await HttpHelperExternal.GetTAsync<DuckImageRes>("https://random-d.uk/api/v2/random");
                return Ok(duckImage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("GetCatFactsAsync")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CatFactsReq))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCatFactsAsync(string lang)
        {
            try
            {
                var catFacts = await HttpHelperExternal.GetTAsync<CatFactsReq>($"https://meowfacts.herokuapp.com/?lang={lang}");
                return Ok(catFacts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}