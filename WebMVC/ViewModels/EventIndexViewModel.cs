using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.ViewModels
{
    public class EventIndexViewModel
    {
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
        public IEnumerable<EachEvent> EventItems { get; set; }
        public Paginationinfo Paginationinfo { get; set; }

        public int? TypeFilterApplied { get; set; }
        public int? LocationFilterApplied { get; set; }
    }
}
