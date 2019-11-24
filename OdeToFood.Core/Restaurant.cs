using System;

namespace OdeToFood.Core {
    /// <summary>
    /// A simple model of a restaurant
    /// </summary>
    public class Restaurant {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
