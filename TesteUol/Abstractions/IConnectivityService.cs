using System;
using System.Threading.Tasks;

namespace TesteUol.Abstractions
{
    public interface IConnectivityService
    {
        Task<bool>IsRemoteReachable(string host, int port);
    }
}
