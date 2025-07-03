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
            Map(x => x.OrderId).Not.Nullable();
            References(x => x.Special).Column("SpecialId").Not.Nullable();
            Map(x => x.Size).Not.Nullable();
            HasMany(x => x.Toppings).Cascade.All().Inverse().AsBag(); // Assuming Toppings is a collection of PizzaTopping
        }
    }
}
