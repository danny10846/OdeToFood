using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants {
    public class EditModel : PageModel {

        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper) {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        //Initially void, we changed to IActionResult so we can return a page given a null Restaurant
        //We've made restaurantId nullable, so that we can enter the edit page get method from List page
        public IActionResult OnGet(int? restaurantId) {

            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            //If we have an id, find restaurant by id
            if (restaurantId.HasValue) {
                Restaurant = restaurantData.GetById(restaurantId.Value);
            }
            //Else create a mock restaurant
            else {
                Restaurant = new Restaurant();
            }
            if (Restaurant == null) {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost() {

            if (ModelState.IsValid) {
                Restaurant = restaurantData.Update(Restaurant);
                restaurantData.Commit();
                //Post redirect get pattern, allows us to exit from the post page. Anonymous type allows us to pass an object
                return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
            }
            //We have to get the cuisines on post again, our application is stateless, have to account for each state of the app            
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            return Page();
        }
    }
}