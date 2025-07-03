using FluentNHibernate.Mapping;

namespace BlazingPizza.Data
{
    public class PizzaToppingMap:ClassMap<PizzaTopping>
    {
        public PizzaToppingMap()
        {
            Table("PizzaToppings"); // Table name in the database
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.PizzaId).Column("PizzaId").Not.Nullable(); // Foreign key to Pizza
            References(x => x.Topping).Column("ToppingId").Not.Nullable(); // Foreign key to Topping
        }

       
    }
}
