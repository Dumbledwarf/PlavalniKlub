using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Plavalec
    {
        public Plavalec(string ime, string priimek, DateTime datumRojstva, int skupinaID)
        {
            Ime = ime;
            Priimek = priimek;
            DatumRojstva = datumRojstva;
            SkupinaID = skupinaID;
        }

        public int PlavalecID { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public DateTime DatumRojstva { get; set; }
        public int SkupinaID { get; set; }
        public ApplicationUser Uporabnik { get; set; }

        public Skupina Skupina {get; set;}
    }
}