using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wedding.Backend.Domain
{
    public class Package
    {
        public int _id { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; } // url all'immagine
        public float TotalPrice { get; set; } //prezzo totale
        public IEnumerable<Contributor> Contributors { get; set; }
        public float TotalPaid { get; set; } //già pagato
        public float Rest { get; set; } // differenza al totale
        public float Median { get; set; } //valore medio tra 0 e rest
        public bool Soldout { get; set; } // totalpaid
    }
}