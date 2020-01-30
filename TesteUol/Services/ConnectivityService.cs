using System;
using System.Threading.Tasks;
using Plugin.Connectivity;
using TesteUol.Abstractions;

namespace TesteUol.Services
{
    public class ConnectivityService : IConnectivityService
    {
        public async Task<bool> IsRemoteReachable(string host, int port)
        {
            return await CrossConnectivity.Current.IsRemoteReachable(host, port);
        }
    }
}

