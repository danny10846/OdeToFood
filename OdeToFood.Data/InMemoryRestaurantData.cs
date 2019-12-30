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
        /// Get All method we have implemented from the IRestaurantData interface 
        /// </summary>
        /// <returns>Returns a sorted list of restaurants</returns>
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null) {
            return from r in _restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
