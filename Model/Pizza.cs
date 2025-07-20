using System.Collections.Generic;
using System.Linq;

namespace BlazingPizza
{
    /// <summary>
    /// Represents a customized pizza as part of an order
    /// </summary>
    public class Pizza
    {
        public const int DefaultSize = 12;
        public const int MinimumSize = 9;
        public const int MaximumSize = 17;

        public virtual int Id { get; set; }

        public virtual Order Order { get; set; }
        public virtual int OrderId { get; set; }

        public virtual PizzaSpecial Special { get; set; }

        public virtual int SpecialId { get; set; }

        public virtual int Size { get; set; }

        public virtual IList<PizzaTopping> Toppings { get; set; }

        public virtual decimal GetBasePrice()
        {
            return ((decimal)Size / (decimal)DefaultSize) * Special.BasePrice;
        }

        public virtual decimal GetTotalPrice()
        {
            return GetBasePrice();
        }

        public virtual string GetFormattedTotalPrice()
        {
            return GetTotalPrice().ToString("0.00");
        }
    }
}
