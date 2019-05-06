using System;
using System.Collections.Generic;
using Insight.Clients.Types;

namespace Insight.Clients.RestClients
{
    public interface IRestClient
    {
        IRestClient CreateClient(string hostUrl);

        IRestClient CreateRequest(string resource, HTTPMethod method);
        
        IRestClient AddAuthentication();

        IRestClient AddHeader(string header, string value);

        IRestClient AddBody(object bodyObject);

        T Execute<T>() where T : new();
    }
}