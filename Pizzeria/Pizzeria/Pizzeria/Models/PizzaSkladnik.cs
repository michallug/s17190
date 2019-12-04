using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class PizzaSkladnik
    {
        public int IdPizza { get; set; }
        public int IdSkladnik { get; set; }

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual Skladnik IdSkladnikNavigation { get; set; }
    }
}
