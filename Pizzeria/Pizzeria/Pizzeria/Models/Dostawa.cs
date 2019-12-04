using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Dostawa
    {
        public Dostawa()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdDostawcy { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
