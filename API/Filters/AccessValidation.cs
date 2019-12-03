using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Newtonsoft.Json;
using Repository;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Filters
{
    public class AccessValidation
    {
        private Guid _accessToken;

        public AccessValidation(Guid accessToken)
        {
            _accessToken = accessToken;
        }

        public bool GetValidation()
        {
            var client = new RestClient("https://localhost:5001/api/validation");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Content-Length", "59");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "localhost:5000");
            request.AddHeader("Postman-Token", "0de55c72-6fd1-47a3-8202-cf08b521cdbe,7acc8c6c-9a0a-40fb-bf50-6e4421239c95");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.20.1");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n \"access_token\": \"" + _accessToken + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            string responseContent = response.Content.Replace("\"", "'");

            bool jsonResponse = JsonConvert.DeserializeObject<bool>(responseContent);

            return jsonResponse;
        }
    }
}
