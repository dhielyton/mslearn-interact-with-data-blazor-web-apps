using FluentNHibernate.Mapping;

namespace BlazingPizza.Data
{
    public class ToppingMap:ClassMap<Topping>
    {
        public ToppingMap()
        {
            Table("Toppings");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Price).Not.Nullable();
        }
    }
   
}
