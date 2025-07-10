using FluentNHibernate.Mapping;

namespace BlazingPizza.Data
{
    public class AddressMap: ClassMap<Address>
    {
        public AddressMap()
        {
            Table("Address"); 
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Nullable();
            Map(x => x.Line1).Nullable();
            Map(x => x.Line2).Nullable();
            Map(x => x.City).Not.Nullable();
            Map(x => x.Region).Not.Nullable();
            Map(x => x.PostalCode).Not.Nullable();


        }
    }
}
