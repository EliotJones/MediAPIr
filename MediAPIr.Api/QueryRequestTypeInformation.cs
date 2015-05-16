namespace MediAPIr.Api
{
    using System;
    using System.Linq;
    using MediaAPIr.Api.Client;

    internal class QueryRequestTypeInformation
    {
        public Type QueryType { get; private set; }

        public Type ResultType { get; private set; }

        public QueryRequestTypeInformation(QueryRequest query)
        {
            this.QueryType = Type.GetType(query.QueryTypeName);
            this.ResultType = this.QueryType.GetInterfaces().Single(i => i.Name.Contains("IQuery")).GetGenericArguments()[0];
        }
    }
}