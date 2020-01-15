using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data {
    public class InMemoryRestaurantData : IRestaurantData {
        //List of restaurants
        List<Restaurant> _restaurants;

        /// <summary>
        /// Constructor initialises the list with a bunch of restaurants
        /// </summary>
        public InMemoryRestaurantData() {
            _restaurants = new List<Restaurant>() {
                new Restaurant{Id = 1, Name="Scott's Pizza", Location="Hasland", Cuisine=CuisineType.Italian},
                new Restaurant{Id = 2, Name="Danny's Indian", Location="Brookfield", Cuisine=CuisineType.Indian},
                new Restaurant{Id = 3, Name="Pete's Burritos", Location="Hasland", Cuisine=CuisineType.Mexican}
            };
        }
        /// <summary>
        /// Save this method for when we use a real data source, presumably database.
        /// </summary>
        /// <returns></returns>
        public int Commit() {
            return 0;
        }

        public Restaurant GetById(int id) {
            return _restaurants.SingleOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Get All method we have implemented from the IRestaurantData interface 
        /// </summary>
        /// <returns>Returns a sorted list of restaurants</returns>
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null) {
            return from r in _restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        /// <summary>
        /// Method to update the restaurant that has been edited by the user on the page
        /// </summary>
        /// <param name="updatedRestaurant"></param>
        /// <returns></returns>
        public Restaurant Update(Restaurant updatedRestaurant) {
            var restaurant = _restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null) {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
    }
}
