using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Napoj
    {
        public Napoj()
        {
            NapojZamowienie = new HashSet<NapojZamowienie>();
        }

        public int IdNapoj { get; set; }
        public string Nazwa { get; set; }
        public int Ilosc { get; set; }
        public double Cena { get; set; }

        public virtual ICollection<NapojZamowienie> NapojZamowienie { get; set; }
    }
}
