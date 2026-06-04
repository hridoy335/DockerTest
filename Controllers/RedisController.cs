using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace DockerTestProject.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RedisController : ControllerBase
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisController(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        [HttpGet("ping")]
        public async Task<IActionResult> Ping()
        {
            var db = _redis.GetDatabase();

            await db.StringSetAsync("test-key", "Hello Redis");

            var value = await db.StringGetAsync("test-key");

            return Ok(value.ToString());
        }
    }
}

