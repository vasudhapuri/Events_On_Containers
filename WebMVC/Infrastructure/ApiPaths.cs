using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public static class ApiPaths
    {
        public static class Event
        {
            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}eventtypes";
            }
            public static string GetAllLocations(string baseUri)
            {
                return $"{baseUri}eventlocations";
            }
            public static string GetAllEvents(string baseUri, int page, int take, int? type, int? location)
            {
                var filterQs = string.Empty;
                //if (type.HasValue || location.HasValue)
                //{
                //    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                //    var locationQs = (location.HasValue) ? location.Value.ToString() : "null";
                //    filterQs = $"/type/{typeQs}/location/{locationQs}";
                //}
                //return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
                if (type.HasValue || location.HasValue)
                {
                  return $"{baseUri}items/filtered?typeId={type}&locationId={location}&pageIndex={page}&pageSize={take}";
                }
                else if (type.HasValue)
                {
                    return $"{baseUri}items/filtered?typeId={type}&pageIndex={page}&pageSize={take}";
                }
                else if (location.HasValue)
                {
                    return $"{baseUri}items/filtered?locationId={location}&pageIndex={page}&pageSize={take}";
                }
                return $"{baseUri}items?pageIndex={page}&pageSize={take}";
            }
        }
    }
}

