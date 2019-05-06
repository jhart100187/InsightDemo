using System;
using Insight.Authentication.Schemes;
using Insight.Authentication.Types.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Insight.Common.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IAuthenticationScheme scheme)
        {
            scheme.ConfigureAuthentication(services);
            
            return services;
        }
    }
}