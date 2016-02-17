using System.Collections.Generic;

namespace RestaurantsManager.Models
{
    public class ResponseModel
    {
        public string ShortResultText { get; set; }
        public List<RestaurantModel> Restaurants { get; set; }
    }
}
