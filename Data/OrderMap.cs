using FluentNHibernate.Mapping;

namespace BlazingPizza.Data
{
    public class OrderMap:ClassMap<Order>
    {
        public OrderMap()
        {
            Table("Order"); // Table name in the database
            Id(x => x.OrderId).GeneratedBy.Identity();
            Map(x => x.UserId).Nullable();
            Map(x => x.CreatedTime).Not.Nullable();
            References(x => x.DeliveryAddress).Column(nameof(Order.DeliveryAddressId));
            HasMany(x => x.Pizzas).Table("Pizza").KeyColumn("OrderId");
                
        }
    }
}
