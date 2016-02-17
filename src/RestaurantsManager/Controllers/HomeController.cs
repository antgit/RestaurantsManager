using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            var restaurants = await _restaurantRepository.Get("se19");

            return View();
        }
    }
}
