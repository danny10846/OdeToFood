using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        /// <summary>
        /// We depend only on abstractions
        /// </summary>
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        //This attribute makes it so this property can be bound through the html page
        //Does not support Get by default, makes it two way binding
        [BindProperty(SupportsGet = true)]
        //The SearchTerm is the string that will persist in the search bar after we have pressed to search
        public string SearchTerm { get; set; }
        public string Message { get; set; }
        //Our list of Restaurants 
        public IEnumerable<Restaurant> Restaurants { get; set; }

        /// <summary>
        /// Our constructor assigns the properties our class depends on
        /// </summary>
        /// <param name="config"></param>
        /// <param name="restaurantData"></param>
        public ListModel(IConfiguration config, IRestaurantData restaurantData) {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        /// <summary>
        /// This is fired for HTTP get request. We can add parameters to this if we wish, and it will check values 
        /// within the razor pages
        /// </summary>
        public void OnGet()
        {
            
            //This accesses the appsettings.json global
            //Message we created
            Message = config["Message"];
            //Get our Restaurants from InMemoryRestaurantData
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}