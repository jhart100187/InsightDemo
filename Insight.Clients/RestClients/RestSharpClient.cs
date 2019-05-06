using System;
using System.Collections.Generic;
using Insight.Clients.Types;
using RestSharp;

namespace Insight.Clients.RestClients
{
    public class RestSharpClient : IRestClient
    {
        private RestClient Client { get; set; }
        
        private RestRequest Request { get; set; }
        
        public IRestClient CreateClient(string hostUrl)
        {
            Client = new RestClient(hostUrl);
            
            return this;
        }
        
        public IRestClient CreateRequest(string resource, HTTPMethod method)
        {
            Request = new RestRequest(resource, (Method) method);
            
            return this;
        }

        public IRestClient AddHeader(string header, string value)
        {
            Request.AddHeader(header, value);
            
            return this;
        }

        public IRestClient AddBody(object bodyObject)
        {
            Request.AddJsonBody(bodyObject);

            return this;
        }

        public IRestClient AddAuthentication()
        {
            return this;
        }

        public T Execute<T>() where T: new()
        {
            var response = (T)Client.Execute<T>(Request);

            return response;
        }
    }
}