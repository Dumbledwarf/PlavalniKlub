using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Plavalec
    {
        public int PlavalecID { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public DateTime DatumRojstva { get; set; }
        public int SkupinaID { get; set; }

        public Skupina Skupina {get; set;}
    }
}