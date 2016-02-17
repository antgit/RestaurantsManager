using System.Collections.Generic;
using System.IO;
using System.Net;
using RestaurantsManager.Models;

namespace RestaurantsManager.Repositories
{
    public class RestaurantRepository
    {
        private const string ApiRoot = "https://public.je-apis.com/restaurants";

        public List<RestaurantModel> Get(string outcode)
        {
            var request = MakeRequest(outcode + "?q=se19");
            var response = request.GetResponse();
            using (var responseStream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(responseStream))
                {
                    var data = streamReader.ReadToEnd();
                }
            }

            return null;
        }

        private WebRequest MakeRequest(string url)
        {
            var request = WebRequest.Create(url);
            request.Headers.Add("Accept-Tenant", "uk");
            request.Headers.Add("Accept-Language", "en-GB");
            request.Headers.Add("Authorization", "Basic VGVjaFRlc3RBUEk6dXNlcjI=");
            request.Headers.Add("Host", "public.je-apis.com");

            return request;
        }
    }
}
