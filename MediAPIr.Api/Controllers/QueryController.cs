namespace MediAPIr.Api.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using Cqrs;
    using MediaAPIr.Api.Client;
    using Newtonsoft.Json;

    public class QueryController : ApiController
    {
        private readonly IServiceLocator serviceLocator;

        public QueryController()
        {
            serviceLocator = new NaiveLocator();
        }

        public async Task<object> Send(QueryRequest query)
        {
            var typeInformation = new QueryRequestTypeInformation(query);

            var queryObject = JsonConvert.DeserializeObject(query.QueryData, typeInformation.QueryType);

            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(typeInformation.QueryType, typeInformation.ResultType);

            var handler = serviceLocator.Resolve(handlerType);

            var sendMethodInfo = handlerType.GetMethod("Send");

            return await (dynamic)sendMethodInfo.Invoke(handler, new[] { queryObject });
        }
    }
}