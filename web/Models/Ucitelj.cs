using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Ucitelj
    {
        public int UciteljID { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public DateTime DatumRojstva { get; set; }
        public int UrnaPostavka { get; set; }
        public ICollection<Skupina> Skupine { get; set; }
        public ICollection<Izvedba> Izvedbe { get; set; }
    }
}