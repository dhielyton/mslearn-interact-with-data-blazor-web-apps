using FluentNHibernate.Mapping;
using NHibernate.Cfg.XmlHbmBinding;

namespace BlazingPizza.Data
{
    public class PizzaMap: ClassMap<Pizza>
    {
         public PizzaMap()
        {
            Table("Pizza"); // Table name in the database
            Id(x => x.Id).GeneratedBy.Identity();
            References(x => x.Special).Column(nameof(Pizza.SpecialId)).Not.Nullable();
            Map(x => x.Size).Not.Nullable();
            HasMany(x => x.Toppings).Cascade.None(); // Assuming Toppings is a collection of PizzaTopping
            References(x => x.Order).Column(nameof(Pizza.OrderId)).Nullable().Cascade.None();
            Map(x => x.OrderId).Column(nameof(Pizza.OrderId)).ReadOnly(); // Foreign key to Order

        }
    }
}
