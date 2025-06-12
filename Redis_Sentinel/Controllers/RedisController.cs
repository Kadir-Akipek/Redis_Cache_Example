using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redis_Sentinel.Services;

namespace Redis_Sentinel.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RedisController : ControllerBase
	{
		//localhost:4200/api/redis/setvalue/name/gencay
		[HttpGet("[action]/{key}/{value}")]
		public async Task<IActionResult> SetValue(string key, string value)
		{
			var redis = await RedisService.RedisMasterDatabase();
			await redis.StringSetAsync(key, value);	
			return Ok(value);
		}

		//localhost:4200/api/redis/getvalue/name
		[HttpGet("[action]/{key}")]
		public async Task<IActionResult> GetValue(string key)
		{
			var redis = await RedisService.RedisMasterDatabase();
			var data = await redis.StringGetAsync(key);
			return Ok(data.ToString());
		}
	}
}
