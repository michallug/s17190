using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            NapojZamowienie = new HashSet<NapojZamowienie>();
            PizzaZamowienie = new HashSet<PizzaZamowienie>();
        }

        public int IdZamowienie { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Ulica { get; set; }
        public int NrDomu { get; set; }
        public int? NrMieszkania { get; set; }
        public DateTime TerminDostawy { get; set; }
        public int? IdSos { get; set; }
        public int? IdPlatnoscTyp { get; set; }
        public int? IdDostawcy { get; set; }

        public virtual Dostawa IdDostawcyNavigation { get; set; }
        public virtual SposobPlatnosci IdPlatnoscTypNavigation { get; set; }
        public virtual Sos IdSosNavigation { get; set; }
        public virtual ICollection<NapojZamowienie> NapojZamowienie { get; set; }
        public virtual ICollection<PizzaZamowienie> PizzaZamowienie { get; set; }
    }
}
