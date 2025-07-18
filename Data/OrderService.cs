
namespace BlazingPizza.Data
{
    public class OrderService
    {
        private readonly NHibernate.ISession _session;

        public OrderService(NHibernate.ISession session)
        {
            _session = session;
        }

        public async Task AddAsync(Order order)
        {
            try
            {
                using var transaction = _session.BeginTransaction();

                if (order.DeliveryAddress != null)
                    await _session.SaveAsync(order.DeliveryAddress);
                await _session.SaveAsync(order);
                foreach (var pizza in order.Pizzas)
                {
                    pizza.OrderId = order.OrderId; // Ensure the OrderId is set
                    pizza.Toppings = null;
                    await _session.SaveAsync(pizza);
                }
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Order> GetOrders()
        {
            return _session.Query<Order>().ToList();
        }
    }
}
