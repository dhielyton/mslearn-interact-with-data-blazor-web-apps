namespace BlazingPizza
{
    public class Topping
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual decimal Price { get; set; }

        public virtual string GetFormattedPrice() => Price.ToString("0.00");
    }
}
