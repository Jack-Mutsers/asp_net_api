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

namespace API.External
{
    public class CurlConnector
    {
        private Guid _accessToken;

        public CurlConnector(Guid accessToken)
        {
            _accessToken = accessToken;
        }

        public CurlConnector()
        {

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

        public UserDto AddUser(User userEntity)
        {
            var client = new RestClient("https://localhost:5001/api/user");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n \"username\": \"" + userEntity.username + "\",\n \"password\": \"" + userEntity.password + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            string responseContent = response.Content.Replace("\"", "'");

            var jsonResponse = JsonConvert.DeserializeObject<UserDto>(responseContent);

            return jsonResponse;
        }

        public string UpdateUser(string password, Guid token)
        {
            var client = new RestClient("https://localhost:5001/api/user/" + token);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Postman-Token", "d7e4bfbd-db67-4c70-b173-c2d6dd14bcf1");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n \"password\": \""+ password +"\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            string responseContent = response.Content.Replace("\"", "'");

            var jsonResponse = JsonConvert.DeserializeObject<string>(responseContent);

            return jsonResponse;
        }
        
        public string DeleteUser(Guid id)
        {
            var client = new RestClient("https://localhost:5001/api/user/"+ id);
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Postman-Token", "310db248-3017-4111-9c53-018f20b5dcf9");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            string responseContent = response.Content.Replace("\"", "'");

            var jsonResponse = JsonConvert.DeserializeObject<string>(responseContent);

            return jsonResponse;
        }

        public Guid Login(User userEntity)
        {
            var client = new RestClient("https://localhost:5001/api/user/login");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "efcb9d6f-2cab-42ba-82de-6cd5aa0159b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n \"username\": \"" + userEntity.username + "\",\n \"password\": \"" + userEntity.password + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            string responseContent = response.Content.Replace("\"", "'");

            Guid jsonResponse = JsonConvert.DeserializeObject<Guid>(responseContent);

            return jsonResponse;
        }
    }
}
