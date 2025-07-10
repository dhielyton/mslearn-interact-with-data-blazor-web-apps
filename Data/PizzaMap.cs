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
            HasMany(x => x.Toppings).Cascade.All(); // Assuming Toppings is a collection of PizzaTopping
            
            
        }
    }
}
