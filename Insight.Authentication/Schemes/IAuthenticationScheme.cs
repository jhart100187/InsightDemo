using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insight.Authentication.Schemes
{
    public interface IAuthenticationScheme
    {
        void ConfigureAuthentication(IServiceCollection services);

        string CreateToken();
    }
}
