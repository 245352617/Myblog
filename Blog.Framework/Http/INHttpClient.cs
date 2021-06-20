using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Http
{
    public interface INHttpClient
    {
        TDto SendAsync<TDto>(HttpMethod method, string url, string data = "", Dictionary<string, string> headers = null, int timeout = 0, string contentType = "text/json");
    }

    public interface INHttpClientFactory<IT, T> where T : class, IT where IT : class
    {
        IT CreateHttpClient();
    }
    public interface INHttpClientFactory : INHttpClientFactory<INHttpClient, NHttpClient>
    {

    }
}
