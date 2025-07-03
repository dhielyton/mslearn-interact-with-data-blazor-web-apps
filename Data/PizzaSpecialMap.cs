using FluentNHibernate.Mapping;

namespace BlazingPizza.Data
{
    public class PizzaSpecialMap : ClassMap<PizzaSpecial>
    {
        public PizzaSpecialMap()
        {

            Table("PizzaSpecial"); // Table name in the database

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description).Nullable();
            Map(x => x.BasePrice).Not.Nullable();
            Map(x => x.ImageUrl).Nullable();
           
        }
    }
}
