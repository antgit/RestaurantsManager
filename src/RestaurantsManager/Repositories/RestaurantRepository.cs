﻿using System.Collections.Generic;
using RestaurantsManager.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

        public async Task<List<Restaurant>> Get(string outcode)
        {
            var json = await _justEatApiConnection.MakeRequest("restaurants", new Dictionary<string, string> { {"q", outcode} });

            var data = JsonConvert.DeserializeObject<RestaurantResponseModel>(json);
            
            return data.Restaurants;
        }
    }
}
