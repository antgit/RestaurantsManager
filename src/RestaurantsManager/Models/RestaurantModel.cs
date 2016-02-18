namespace RestaurantsManager.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CuisineTypes { get; set; }
        public float RatingStars { get; set; }
        public bool IsOpenNow { get; set; }
    }
}
