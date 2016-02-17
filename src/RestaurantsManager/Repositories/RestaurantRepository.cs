using System.Collections.Generic;
using RestaurantsManager.Models;
using System.Threading.Tasks;
using RestaurantsManager.Infrastructure;

namespace RestaurantsManager.Repositories
{
    public class RestaurantRepository
    {
        private readonly JustEatApiConnection _justEatApiConnection;

        public RestaurantRepository(JustEatApiConnection justEatApiConnection)
        {
            _justEatApiConnection = justEatApiConnection;
        }

        public async Task<List<RestaurantModel>> Get(string outcode)
        {
            var data = await _justEatApiConnection.MakeRequest();

            return null;
        }
    }
}
