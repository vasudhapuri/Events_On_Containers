using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;

        public EventsController(EventContext context, IConfiguration config)
        {
            this._context = context;
            this._config = config;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByType(
            [FromQuery] int typeId = 0)
        {
            var items = await this._context.Events.Where(x => x.TypeId == typeId).ToListAsync();
            return Ok(items);
        }
    }
}
