using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Services
{
    public interface IEventService
    {
        Task<Event>GetEventItemsAsync(int page, int size, int? type, int? location);
        Task<IEnumerable<SelectListItem>> GetTypesAsync(); //to fill event type dropdown
        Task<IEnumerable<SelectListItem>> GetLocationsAsync(); //to fill event location dropdown
    }
}
