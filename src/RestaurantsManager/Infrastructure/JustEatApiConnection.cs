using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestaurantsManager.Infrastructure.Exceptions;

namespace RestaurantsManager.Infrastructure
{
    public class JustEatApiConnection
    {
        public async Task<string> MakeRequest(string resource, Dictionary<string, string> @params)
        {
            try
            {
                return await MakeRequestInternal(resource, @params);
            }
            catch (JustEatApiException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new JustEatApiException(e);
            }
        }

        private static async Task<string> MakeRequestInternal(string resource, Dictionary<string, string> @params)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://public.je-apis.com/");
                client.DefaultRequestHeaders.Add("Accept-Tenant", "uk");
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-GB"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "VGVjaFRlc3RBUEk6dXNlcjI=");
                client.DefaultRequestHeaders.Host = "public.je-apis.com";

                var paramString = string.Join(" & ", @params.Select(p => $"{p.Key}={p.Value}"));
                var uri = $"{resource}?{paramString}";

                using (var response = await client.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        throw new JustEatApiException("Response status is not success");
                    }
                }
            }
        }
    }
}
