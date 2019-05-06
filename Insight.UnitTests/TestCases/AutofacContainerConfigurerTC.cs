using System.Linq;
using Autofac;
using Autofac.Core;
using Insight.Clients.Metadata;
using Insight.Clients.RestClients;
using Insight.Clients.Types;
using Insight.Container;
using Insight.Container.Modules;
using NUnit.Framework;

namespace Insight.UnitTests.TestCases
{
    public class AutofacContainerConfigurerTC
    {
        private AutofacContainerConfigurer _autofacConfigurer { get; set; }
        
        [SetUp]
        public void Setup()
        {
            _autofacConfigurer = new AutofacContainerConfigurer();
            _autofacConfigurer.RegisterModules().Build();
        }

        [TearDown]
        public void TearDown()
        {
            _autofacConfigurer.Container.Dispose();
        }
        
        [Test]
        public void ShouldRegisterServices()
        {
            var numberOfServicesRegistered = _autofacConfigurer.Container.ComponentRegistry
                .Registrations
                .SelectMany(componentRegistration => componentRegistration.Services)
                .Count();
            
            Assert.That(numberOfServicesRegistered, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldBuildContainer()
        {
            Assert.That(_autofacConfigurer.Container, Is.Not.Null);
        }
    }
}