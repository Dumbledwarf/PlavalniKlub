using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Skupina
    {
        public int SkupinaID { get; set; }
        public int UciteljID { get; set; }
        public int BazenID { get; set; }
        public int ProgaID { get; set; }
        public int Ura { get; set; }
        public ICollection<Izvedba> Izvedbe { get; set; }
        public ICollection<Plavalec> Plavalci { get; set; }

        public Ucitelj Ucitelj { get; set; }
        public Bazen Bazen { get; set; }
    }
}