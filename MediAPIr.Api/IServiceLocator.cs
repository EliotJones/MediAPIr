namespace MediAPIr.Api
{
    using System;
    using System.Collections.Generic;
    using Cqrs;

    internal interface IServiceLocator
    {
        object Resolve(Type serviceType);
    }

    internal class NaiveLocator : IServiceLocator
    {
        private readonly Dictionary<Type, object> services; 

        public NaiveLocator()
        {
            this.services = new Dictionary<Type, object>();

            services.Add(typeof(IQueryHandler<GetAllRappers, Rapper[]>), new GetAllRappersHandler(new Data()));
            services.Add(typeof(IQueryHandler<GetRapperByName, Rapper>), new GetRapperByNameHandler(new Data()));
        }

        public object Resolve(Type serviceType)
        {
            return services[serviceType];
        }
    }
}