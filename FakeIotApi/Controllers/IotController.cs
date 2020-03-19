using System.Threading.Tasks;
using FakeIotApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace FakeIotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IotController : ControllerBase
    {
        private readonly Repository _repo;

        public IotController(Repository repo)
        {
            _repo = repo;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IotDevice>> Get(int id)
        {
            var device = _repo.Read(id);
            await Task.Delay(device.LatencySeconds * 1000);
            return device;
        }
    }
}