namespace MediaAPIr.Api.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MediAPIr.Cqrs;
    using Newtonsoft.Json;

    public class ApiClient : IDisposable
    {
        private readonly HttpClient client;

        public ApiClient()
        {
            this.client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:52553/");
        }

        public async Task<TResult> Send<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var request = new QueryRequest
            {
                QueryData = JsonConvert.SerializeObject(query),
                QueryTypeName = typeof(TQuery).AssemblyQualifiedName
            };

            var response = await client.PostAsJsonAsync("api/Query/Send", request);

            return await response.Content.ReadAsAsync<TResult>();
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
