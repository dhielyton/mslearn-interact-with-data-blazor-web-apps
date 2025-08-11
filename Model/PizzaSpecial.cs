namespace BlazingPizza
{
    /// <summary>
    /// Represents a pre-configured template for a pizza a user can order
    /// </summary>
    public class PizzaSpecial
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual decimal BasePrice { get; set; }

        public virtual string Description { get; set; }

        public virtual string ImageUrl { get; set; }
        public  virtual int? FixedSize { get; set; }

        public virtual string GetFormattedBasePrice() => BasePrice.ToString("0.00");
    }
}
