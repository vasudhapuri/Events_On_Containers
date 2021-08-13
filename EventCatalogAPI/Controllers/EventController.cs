﻿using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;
            private readonly IConfiguration _config;
        //private readonly _config;
        public EventController (EventContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Items([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 6)
        {
            var itemsCount = _context.Events.LongCountAsync();
            var items = await _context.Events
                  //.OrderBy (c=>c.EventName)
                  .Skip(pageIndex * pageSize)
                  .Take(pageSize)
                  .ToListAsync();

            items = ChangePictureUrl(items);
            var model = new PaginatedItemsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
        };

            return Ok(model);
        }

        [HttpGet("[action]/type/{TypeId}/location/{LocationId}")]
        public async Task<IActionResult> Items(
           int? typeId, int? locationId,
            [FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 6 )
          
        {
            var query = (IQueryable<EachEvent>)_context.Events;
            if(typeId.HasValue)
            {
                query = query.Where(c=>c.TypeId == typeId);
            }

            if(locationId.HasValue)
            {
                query = query.Where(c => c.LocationId == locationId);
            }
            var itemsCount = query.LongCountAsync();
            var items = await query
                  //.OrderBy (c=>c.EventName)
                  .Skip(pageIndex * pageSize)
                  .Take(pageSize)
                  .ToListAsync();

            items = ChangePictureUrl(items);
            var model = new PaginatedItemsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };

            return Ok(model);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByType(
            [FromQuery] int typeId = 0)
        {
            var items = await this._context.Events.Where(x => x.TypeId == typeId).ToListAsync();
            return Ok(items);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByLocation(
        [FromQuery] int locationId = 0)
        {
            var items = await this._context.Events.Where(x => x.LocationId == locationId).ToListAsync();
            return Ok(items);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventTypes()
        {
           var types= await _context.EventTypes.ToListAsync();
            return Ok(types);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventLocations()
        {
            var locations = await _context.EventLocations.ToListAsync();
            return Ok(locations);
        }


        private List<EachEvent> ChangePictureUrl(List<EachEvent> items)
        {
            items.ForEach(item=>
            item.PictureUrl=
            item.PictureUrl.Replace(
                "http://externalcatalogbaseurltobereplaced", _config["ExternalCatalogUrl"]));
            return items;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByZipCode(
           [FromQuery] string zipcode = "0")
        {
            var items = await this._context.Events.Where(x => x.Zip == zipcode).ToListAsync();
            return Ok(items);
        }

    }
}
