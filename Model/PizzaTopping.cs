namespace BlazingPizza
{
    public class PizzaTopping
    {
        public virtual int Id { get; set; }
        public virtual Topping Topping { get; set; }

        public virtual int ToppingId { get; set; }
        
        public virtual int PizzaId { get; set; }
    }
}
