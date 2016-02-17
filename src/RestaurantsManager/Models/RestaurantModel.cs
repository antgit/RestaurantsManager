using System.Collections.Generic;

namespace RestaurantsManager.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CuisineType> CuisineTypes { get; set; }
        public float RatingStars { get; set; }
    }
}
