namespace MediAPIr.Models
{
    using System.Collections.Generic;
    using Cqrs;

    public class HomeModel
    {
        public IList<Rapper> Rappers { get; set; }

        public string SearchTerm { get; set; }

        public Rapper SearchResult { get; set; }
    }
}