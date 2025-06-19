using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // Sample model
        public class SampleItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        // Action method with a specific name and route
        [HttpGet("everything")]
        public async Task<IActionResult> GetSampleItems()
        {
            await Task.Delay(500); // Simulated async delay

            var data = new List<SampleItem>
            {
                new SampleItem { Id = 1, Name = "Item One" },
                new SampleItem { Id = 2, Name = "Item Two" },
                new SampleItem { Id = 3, Name = "Item Three" }
            };

            return Ok(data);
        }
    }
}
