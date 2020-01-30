using System;
using System.Threading.Tasks;
using RestSharp;
using TesteUol.Abstractions;

namespace TesteUol.Services
{
    public class RestServices : IRestService
    {
        public Task<IRestResponse> Get()
        {
            var client = new RestClient($"https://api.darksky.net/forecast/8cdfe5016e2c5632b2f1e060380b873a/37.8267,-122.4233");
           

            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");

            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, (response) =>
            {
                taskCompletionSource.SetResult(response);
            });

            return taskCompletionSource.Task;
        }
    }
}

