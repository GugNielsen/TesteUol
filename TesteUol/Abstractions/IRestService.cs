using System;
using System.Threading.Tasks;
using RestSharp;

namespace TesteUol.Abstractions
{
    public interface IRestService 
    {
        Task<IRestResponse> Get();
    }
}
