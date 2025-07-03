using NHibernate;
using NHibernate.Linq;
namespace BlazingPizza.Data
{
    public class PizzaService
    {
        private NHibernate.ISession _session;

        public PizzaService(NHibernate.ISession session)
        {
            _session = session;
        }

        public async Task<List<PizzaSpecial>> GetAsync()
        {
            return   ( await _session.Query<PizzaSpecial>().ToListAsync()).OrderByDescending(x => x.BasePrice).ToList();
        }

        public async Task AddAsync(PizzaSpecial pizza)
        {
            using var transaction = _session.BeginTransaction();
            await _session.SaveAsync(pizza);
            await transaction.CommitAsync();
        }
    }
}
