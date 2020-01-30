using System;
using System.Threading.Tasks;

namespace TesteUol.Abstractions
{
    public interface IConnectivityService
    {
       public Task<bool> IsRemoteReachable(string host, int port);
    }
}
