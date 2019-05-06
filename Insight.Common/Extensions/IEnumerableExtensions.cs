using System;
using System.Collections.Generic;
using System.Linq;
using Insight.Clients.Metadata;
using Insight.Clients.RestClients;
using Insight.Clients.Types;

namespace Insight.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IRestClient GetClient<T>(this IEnumerable<T> restClients, ClientType clientType)
            where T: Lazy<IRestClient, ClientMetadata>
        {
            IRestClient client = null;

            try
            {
                client = restClients
                    .First(source => source.Metadata.ClientType == clientType)
                    .Value;
            }
            catch (Exception ex)
            {
                //Implement logging here
                Console.WriteLine(ex);
            }

            return client;
        }
    }
}