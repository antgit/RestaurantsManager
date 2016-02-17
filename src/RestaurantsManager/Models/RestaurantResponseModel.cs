using System.Collections.Generic;

namespace RestaurantsManager.Models
{
    public class RestaurantResponseModel
    {
        public string ShortResultText { get; set; }
        public List<RestaurantModel> Restaurants { get; set; }
    }
}
