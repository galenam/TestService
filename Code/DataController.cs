using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestService
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IEntityService _entityService;
        private readonly ITransferService _transferService;
        public DataController(ILogger<DataController> logger, IEntityService entityService, ITransferService transferService)
        {
            _entityService = entityService;
            _transferService = transferService;
        }

        [HttpPost]
        public IActionResult Post([FromQuery] string json)
        {
            var entity = _transferService.Create(json);
            if (entity == null)
            {
                return BadRequest();
            }
            return Ok(_entityService.Add(entity));
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
            {
                return BadRequest();
            }
            var entity = _entityService.Get(guid);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(_transferService.Transfer(entity));
        }
    }
}