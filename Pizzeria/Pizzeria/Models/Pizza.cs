using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaSkladnik = new HashSet<PizzaSkladnik>();
            PizzaZamowienie = new HashSet<PizzaZamowienie>();
        }

        public int IdPizza { get; set; }
        public string Nazwa { get; set; }
        public string Dodatek { get; set; }
        public double Cena { get; set; }
        public string PodwojneCiasto { get; set; }
        public int Spersonalizowana { get; set; }

        public virtual ICollection<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual ICollection<PizzaZamowienie> PizzaZamowienie { get; set; }
    }
}
