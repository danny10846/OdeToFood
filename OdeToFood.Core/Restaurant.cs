using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core {
    /// <summary>
    /// A simple model of a restaurant
    /// </summary>
    public class Restaurant {
        
        public int Id { get; set; }

        //Attribute validates our name
        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(225)]
        public string Location { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}
