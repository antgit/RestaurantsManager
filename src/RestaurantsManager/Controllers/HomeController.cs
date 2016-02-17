using Microsoft.AspNet.Mvc;
using RestaurantsManager.Repositories;

namespace RestaurantsManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestaurantRepository _restaurantRepository;

        public HomeController(RestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
