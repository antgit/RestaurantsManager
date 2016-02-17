using System.Collections.Generic;

namespace RestaurantsManager.Models
{
    public class RestaurantResponseModel
    {
        public string ShortResultText { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }
}
