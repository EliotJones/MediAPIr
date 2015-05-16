namespace MediAPIr.Cqrs
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetAllRappers : IQuery<Rapper[]>
    {
    }

    public class GetAllRappersHandler : IQueryHandler<GetAllRappers, Rapper[]>
    {
        private readonly IEnumerable<Rapper> rapperData; 

        public GetAllRappersHandler(IEnumerable<Rapper> rapperData)
        {
            this.rapperData = rapperData;
        }

        public async Task<Rapper[]> Send(GetAllRappers query)
        {
            // We have no real async work here but this would be a database/web service call.
            return rapperData.ToArray();
        }
    }
}
