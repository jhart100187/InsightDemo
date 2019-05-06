using Autofac;
using Autofac.Extensions.DependencyInjection;
using Insight.Container.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Insight.Container
{
    public class AutofacContainerConfigurer
    {
        public IContainer Container { get; private set; }

        private ContainerBuilder Builder { get; set; }

        public AutofacContainerConfigurer()
        {
            Builder = new ContainerBuilder();
        }

        public IContainer Build()
        {
            Container = Builder.Build();

            return Container;
        }

        public AutofacContainerConfigurer RegisterModules()
        {
            Builder.RegisterModule(new ClientsModule());

            return this;
        }

        public AutofacContainerConfigurer PopulateServices(IServiceCollection services)
        {
            Builder.Populate(services);
            
            return this;
        }
    }
}
