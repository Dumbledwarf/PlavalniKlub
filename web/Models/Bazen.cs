using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Bazen
    {
        public int BazenID { get; set; }
        public string Ime { get; set; }
        public string Naslov { get; set; }
        public ICollection<Skupina> Skupine { get; set; }
    }
}