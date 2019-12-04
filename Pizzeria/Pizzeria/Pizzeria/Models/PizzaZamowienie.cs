using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class PizzaZamowienie
    {
        public int IdZamowienie { get; set; }
        public int IdPizza { get; set; }

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual Zamowienie IdZamowienieNavigation { get; set; }
    }
}
