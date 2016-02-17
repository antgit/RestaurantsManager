using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using RestaurantsManager.Infrastructure;
using RestaurantsManager.Repositories;

namespace RestaurantsManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestaurantRepository _restaurantRepository;
        private readonly ObjectToJsonSerializer _objectToJsonSerializer;

        public HomeController(
            RestaurantRepository restaurantRepository,
            ObjectToJsonSerializer objectToJsonSerializer)
        {
            _restaurantRepository = restaurantRepository;
            _objectToJsonSerializer = objectToJsonSerializer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurants(string outcode)
        {
            var restaurants = await _restaurantRepository.Get(outcode);
            var json = _objectToJsonSerializer.Serialize(restaurants);

            return Content(json, "application/json");
        }
    }
}
