# Project Insight (Demo)

### About:
Insight will be a web service that connects to a third-party web service for stock exchange data, 
and will use said data in conjunction with a machine learning library in order to predict possible future outcomes of the stock exchange.

### Disclaimer:
This repository is just a demo branch of the Insight project. This demo branch only shows the foundation work that I have implemented for the Inisght project,
as that is all that I have coded so far for the overall project.

### Assemblies:
    -Insight.API: Assembly containing the logic for creating and starting the web service

    -Insight.Authentication: Assembly containing the logic for setting up the Authentication scheme to be used 
    by the web service

    -Insight.Clients: Assembly containing the various Types of custom clients. As of right now, the only client 
    implemented is a wrapper for a third-party Rest client. However, in future work clients for
    internal services will be implemented.

    -Insight.Common: Assembly containing Types that will be commonly used by other Types in other assemblies.

    -Insight.Container: Assembly containing the logic for creating an Autofac IoC container,
    and registering Modules

    -Insight.UnitTests: Assembly containing the logic for running Unit Tests.
