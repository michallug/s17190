using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            PizzaSkladnik = new HashSet<PizzaSkladnik>();
        }

        public int IdSkladnik { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<PizzaSkladnik> PizzaSkladnik { get; set; }
    }
}
