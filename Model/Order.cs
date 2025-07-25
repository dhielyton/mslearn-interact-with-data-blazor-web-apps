using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazingPizza
{
    public class Order
    {
        public virtual int OrderId { get; set; }

        public virtual string UserId { get; set; }

        public virtual DateTime CreatedTime { get; set; }

        public virtual Address DeliveryAddress { get; set; } = new Address();
        public virtual int? DeliveryAddressId { get; set; }

        public virtual IList<Pizza> Pizzas { get; set; } = new List<Pizza>();

        public virtual decimal GetTotalPrice() => Pizzas.Sum(p => p.GetTotalPrice());

        public virtual string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");
    }
}
