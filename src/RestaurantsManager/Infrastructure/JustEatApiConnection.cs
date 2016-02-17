using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestaurantsManager.Infrastructure.Exceptions;

namespace RestaurantsManager.Infrastructure
{
    public class JustEatApiConnection
    {
        public async Task<string> MakeRequest()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://public.je-apis.com/");
                client.DefaultRequestHeaders.Add("Accept-Tenant", "uk");
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-GB"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "VGVjaFRlc3RBUEk6dXNlcjI=");
                client.DefaultRequestHeaders.Host = "public.je-apis.com";

                using (var response = await client.GetAsync("restaurants?q=se19"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                }
            }

            throw new JustEatApiException();
        }
    }
}
