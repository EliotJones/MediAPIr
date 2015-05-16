namespace MediAPIr.Cqrs
{
    using System.Threading.Tasks;

    public interface IQuery<TReturn>
    {
    }

    public interface IQueryHandler<TQuery, TReturn> where TQuery : IQuery<TReturn>
    {
        Task<TReturn> Send(TQuery query);
    }
}
