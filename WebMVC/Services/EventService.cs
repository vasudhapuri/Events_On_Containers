using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace WebMVC.Services
{
    public class EventService : IEventService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _client;
        public EventService (IConfiguration config, IHttpClient client)
            
            {
             _baseUrl = $"{config["CatalogUrl"]}/api/event/"; //reading domain name(localhost:7004) from configuration
            _client = client;
            }

        public async Task<Event> GetEventItemsAsync(int page, int size, int? type, int? location)
        {
       var eventItemsUri= ApiPaths.Event.GetAllEvents(_baseUrl, page, size, type, location);
           var dataString= await _client.GetStringAsync(eventItemsUri);
            return JsonConvert.DeserializeObject<Event>(dataString);
        }

        public async Task<IEnumerable<SelectListItem>> GetLocationsAsync()
        {
            var locationUri = ApiPaths.Event.GetAllLocations(_baseUrl);
            var dataString = await _client.GetStringAsync(locationUri);
            var items = new List<SelectListItem> //SelectListItem meand dropdown items
            {
                new SelectListItem
                {
                    Value=null, //value is the id behind the scenes wch will be null for "All"
                    Text="All",
                    Selected = true //default selected
                }
            };

            var locations = JArray.Parse(dataString);
            foreach (var location in locations)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = location.Value<string>("id"),
                        Text = location.Value<string>("city")
                    });
            }
            return items;
        }
    

        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            var typeUri = ApiPaths.Event.GetAllTypes(_baseUrl);
            var dataString = await _client.GetStringAsync(typeUri);
            var items = new List<SelectListItem> //SelectListItem meand dropdown items
            {
                new SelectListItem
                {
                    Value=null, //value is the id behind the scenes wch will be null for "All"
                    Text="All",
                    Selected = true //default selected
                }
            };

            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value =type.Value<string>("id"),
                        Text = type.Value<string>("typeName")
                    });
            }
            return items;
        }
    }
}
