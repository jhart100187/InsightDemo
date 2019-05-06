using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Insight.Clients.Types;
using Insight.Clients.Metadata;
using Insight.Clients.RestClients;

namespace Insight.Container.Modules
{
    public class ClientsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new RestSharpClient())
                .WithMetadata<ClientMetadata>(configuration =>
                    configuration.For(metadata => metadata.ClientType, ClientType.RestClient))
                .As<IRestClient>();

        }
    }
}