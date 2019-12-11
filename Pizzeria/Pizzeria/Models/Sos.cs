using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Sos
    {
        public Sos()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdSos { get; set; }
        public string Nazwa { get; set; }
        public double Cena { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
