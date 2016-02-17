using System;

namespace RestaurantsManager.Infrastructure.Exceptions
{
    public class JustEatApiException: Exception
    {
        public JustEatApiException(string message) : base(message)
        {
            
        }

        public JustEatApiException(Exception e): base("An exception occurred during connection with JustEat Web API", e)
        {
            
        }
    }
}
