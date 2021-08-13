using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _service;
        public EventController(IEventService service)
        {
            _service = service;
        }

    
        public async Task<IActionResult> Index(int? page, int? typeFilterApplied, int? locationFilterApplied)
        {
            var itemsOnPage = 10;

            var catalog = await _service.GetEventItemsAsync(page ?? 0, itemsOnPage, typeFilterApplied, locationFilterApplied);
            var vm = new EventIndexViewModel
            {
                Types = await _service.GetTypesAsync(),
                Locations = await _service.GetLocationsAsync(),
                EventItems = catalog.Data,
                Paginationinfo = new Paginationinfo
                {
                    TotalItems = catalog.Count,
                    ItemsPerPage = catalog.PageSize,
                    ActualPage = page ?? 0,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage)
                },
                TypeFilterApplied = typeFilterApplied ?? 0,
                LocationFilterApplied = locationFilterApplied ?? 0
            };

            return View(vm);
        }
    }
}
