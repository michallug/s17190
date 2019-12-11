using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class SposobPlatnosci
    {
        public SposobPlatnosci()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdPlatnoscTyp { get; set; }
        public string Rodzaj { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
