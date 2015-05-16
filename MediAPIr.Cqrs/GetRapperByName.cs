namespace MediAPIr.Cqrs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetRapperByName : IQuery<Rapper>
    {
        public string Name { get; private set; }

        public GetRapperByName(string name)
        {
            Name = name;
        }
    }

    public class GetRapperByNameHandler : IQueryHandler<GetRapperByName, Rapper>
    {
        private readonly IEnumerable<Rapper> rappers;

        public GetRapperByNameHandler(IEnumerable<Rapper> rappers)
        {
            this.rappers = rappers;
        }

        public async Task<Rapper> Send(GetRapperByName query)
        {
            return rappers.FirstOrDefault(r => r.Name.Equals(query.Name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
