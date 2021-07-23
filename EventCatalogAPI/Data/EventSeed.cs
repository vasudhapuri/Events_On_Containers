using Microsoft.EntityFrameworkCore;
using EventCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public static class EventSeedcs
    {
        public static void Seed(EventContext eventContext)
        {
            eventContext.Database.Migrate();
            if (!eventContext.EventLocations.Any())
            {
                eventContext.EventLocations.AddRange(GetEventLocations());
                eventContext.SaveChanges();
            }
            if (!eventContext.EventTypes.Any())
            {
                eventContext.EventTypes.AddRange(GetEventTypes());
                eventContext.SaveChanges();
            }
            if (!eventContext.Events.Any())
            {
                eventContext.Events.AddRange(GetEvents());
                eventContext.SaveChanges();
            }
        }

        public static IEnumerable<EventLocation> GetEventLocations()
        {
            return new List<EventLocation>
            {
                new EventLocation
                {
                    City = "Redmond"
                },
                new EventLocation
                {
                    City = "Kirkland"
                },
                new EventLocation
                {
                    City="Bellevue"
                },
                new EventLocation
                {
                    City="Renton"
                },
                new EventLocation
                {
                    City="Seattle"
                },
                 new EventLocation
                {
                    City="Bothell"
                },
                  new EventLocation
                {
                    City="Kenmore"
                },
                   new EventLocation
                {
                    City="Sammamish"
                },
                    new EventLocation
                {
                    City="Issaquah"
                },
                      new EventLocation
                {
                    City="Woodinville"
                      }
                };

        }
        public static IEnumerable<EventType> GetEventTypes()
        {
            return new List<EventType>
            {
                new EventType
                {
                    TypeName = "Music"
                },
                new EventType
                {
                    TypeName = "Food & Drink"
                },
                new EventType
                {
                    TypeName="Charity & Causes"
                },
                new EventType
                {
                    TypeName="Health & Fitness"
                },
                new EventType
                {
                    TypeName="Movies & Plays"
                },
                 new EventType
                {
                    TypeName="Career Fairs"
                },
                  new EventType
                {
                    TypeName="Online"
                },
                   new EventType
                {
                    TypeName="Free"
                }

            };

        }
        private static IEnumerable<EachEvent> GetEvents()
        {
            return new List<EachEvent>()
            {

                new EachEvent { TypeId = 4, LocationId = 1, Description = "Try it, taste it, adopt it", EventName = "Be A Vegan:Beginner", Price = 0.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1", Address="Araya's vegan cafe hut", Likes=10, Date=new DateTime(2021, 09, 09, 10, 10, 00 ), Zip="98034" },
                new EachEvent { TypeId = 1, LocationId = 2, Description = "Get high at Trinity Nightclub", EventName = "SunTan Disco", Price = 35.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2", Address="Rose hill hall",Likes=2,  Date=new DateTime(2021, 09, 11, 21, 00, 00 ) ,Zip="98033"  },
                new EachEvent { TypeId = 3, LocationId = 3, Description = "You have already won gold medal", EventName = "Pinkathon", Price = 10.50M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3", Address="Bellevue stadium",Likes=0,  Date=new DateTime(2021, 09, 05, 10, 30, 00 ), Zip="98009"},
                new EachEvent { TypeId = 3, LocationId = 10, Description = "Dine for a cause", EventName = "Foundation Hitech Fundraiser", Price = 12.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4", Address="Boys and girls club,84th street", Date=new DateTime(2021, 09, 06, 10, 10, 00 ), Zip="98033" },
                new EachEvent { TypeId = 2, LocationId = 5, Description = "Wine, Yoga and Fun", EventName = "Heritage Brunch", Price = 40.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" , Address="Novotel, Seattle",Likes=7,  Date=new DateTime(2021, 09, 22, 12, 30, 00 ), Zip="98016" },
                new EachEvent { TypeId = 7, LocationId = 6, Description = "Get placed at your dream job", EventName = "Primier Virtual Tech", Price = 50.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6", Address="Remote" ,Likes =2,  Date=new DateTime(2021, 08, 22, 11, 30, 00 ), Zip="98011" },
                new EachEvent { TypeId = 2, LocationId = 7, Description = "Saturday brunch with friends and family!", EventName = "Eat All You Can", Price = 50.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7" , Address="Sea high, golf street, Kenmore", Likes=3,  Date=new DateTime(2021, 09, 09, 13, 00, 00 ), Zip="99027" },
                new EachEvent { TypeId = 4, LocationId = 10, Description = "Powerpacked Yoga, meditation and Zumba", EventName = "Summer Fitness Expo", Price = 15.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8", Address="Brit's dance academy",  Likes=9,  Date=new DateTime(2021, 08, 25, 11, 00, 00 ) , Zip="98816"},
                new EachEvent { TypeId = 5, LocationId = 2, Description = "Get caught, get lost in the workd of Shakespeare", EventName = "Shakespeare", Price = 10.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9", Address="Great Lake stadium, Kirkland", Likes=8, Date=new DateTime(2021, 09, 13, 20, 15, 00 ) , Zip="98033"},
                new EachEvent { TypeId = 2, LocationId = 4, Description = "Achieve your culinary dreams", EventName = "Bakethon2.0", Price = 12.50M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10" , Address="Sasha's palace kitchen", Likes=1,  Date=new DateTime(2021, 09, 09, 17, 00, 00 ) , Zip="98331"},
                new EachEvent { TypeId = 6, LocationId = 8, Description = "Be an all rounder, get hired at the best!", EventName = "Hitech Job Expo", Price = 25.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11" , Address="Sea hawks stadium, Sammamish", Likes=0,  Date=new DateTime(2021, 08, 10, 10, 10, 00 ) , Zip="98074" },
                new EachEvent { TypeId = 7, LocationId = 1, Description = "A pricesless vegan experience", EventName = "CookVegan", Price = 20.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12", Address="Remote",  Likes=3,Date=new DateTime(2021, 08, 25, 09, 30, 00 ), Zip="98008" },
                new EachEvent { TypeId = 5, LocationId = 3, Description = "The most loved and breathtaking play of the year", EventName = "Elequent", Price = 30.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13" , Address="Grandeur indoor Park", Likes=5,  Date=new DateTime(2021, 09, 30, 19, 00, 00 ), Zip="98008" },
                new EachEvent { TypeId = 1, LocationId = 9, Description = "Massive Fridays with DJ Samuel", EventName = "Summer Star Electric", Price = 70.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14", Address="Q Nighclub", Likes=11,  Date=new DateTime(2021, 08, 30, 21, 30, 00 ), Zip="98029" },
                new EachEvent { TypeId = 8, LocationId = 1, Description = "Come.. take part, start the change", EventName = "Peace Youth Peloton", Price = 0.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15", Address="Redmond high school, 46th Ave",Likes=9,  Date=new DateTime(2021, 09, 14, 07, 30, 00 ), Zip="98053" }
                };
        }

    }
}
