using Fundamentos_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fundamentos_MVC.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name="Scoot´s Pizza", Cuisine = CusineType.Italian},
                new Restaurant {Id = 2, Name="Tersiguels", Cuisine = CusineType.French},
                new Restaurant {Id = 3, Name="Mango Grove", Cuisine = CusineType.Indian}
            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }
        public void Update (Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if(existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;

            }
        }
        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
            
        }
    }
}
