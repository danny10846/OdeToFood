using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private IRestaurantData restaurauntData;

        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantData restaurantData) {
            //Inject restaurant data into our constructor
            this.restaurauntData = restaurantData;
        }
        /// <summary>
        /// Our OnGet method takes in a restaurantId, which is supplied by the tag helper within our list cshtml
        /// </summary>
        /// <param name="restaurantId">We use this param to get the restaurant we require</param>
        /// <returns></returns>
        public IActionResult OnGet(int restaurantId)
        {
            //Use our restaurantData to use the GetById method with the restaurantId parameter within our html page
            //We can then bind to all the properties within Restaurant in our html page
            Restaurant = restaurauntData.GetById(restaurantId);
            //This handles bad requests
            if (Restaurant == null) return RedirectToPage("./NotFound");
            return Page();
        }
    }
}