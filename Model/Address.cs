
namespace BlazingPizza
{
    public class Address
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Line1 { get; set; }

        public virtual string Line2 { get; set; }

        public virtual string City { get; set; }

        public virtual string Region { get; set; }

        public virtual string PostalCode { get; set; }
    }
}
